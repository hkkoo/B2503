/*
 *  Author: MoonChang Chae (Future Systems Inc.) 
 *  Author-orientation: Athony La Forge (Validity Systems Inc.) 
 */

using System;
using System.Collections;
using System.Threading;
using System.IO;

namespace Future.Logger
{
    
    public enum logLevel
    {
        Critical = 0,
        Error,
        Warn,
        Info,
        Debug,
        All,
        MaxLog
    }


    /// <summary>
    /// Represents a log message
    /// </summary>
    public struct LoggerMessage
    {
        public logLevel level;
        public string level_desc;
        public string tag;
        public string message;
        public long time;
    }

    /// <summary>
    /// Abstract class responsible managing (in the form or a queue) and dispatching log messages
    /// to their appropriate source.  The basic premises is that everything from a file writers, 
    /// to an e-mailer, to an syslog interface, to a db interface, etc... could be implemented and the only
    /// thing the implementer would need to worry about was the interface.
    /// </summary>
    public abstract class LoggerEventHandler
    {
        private bool alive = false;
        private Queue q = null;
        private Thread dispatch = null;
        protected string[] logLevelDescriptors = null;

        public LoggerEventHandler()
        {
            q = Queue.Synchronized(new Queue(1000));
            start();
        }

        /// <summary>
        /// Starts the execution of the Handler (e.g. Queue goes live)
        /// </summary>
        public void start()
        {
            //It's already alive, nothing to do
            if (alive) return;

            //Make sure this is the only place where alive is set to true
            alive = true;
            dispatch = new Thread(new ThreadStart(dispatchMessages));
            dispatch.Start();
        }

        /// <summary>
        /// Stops the execution of the Handler gracefully (e.g. everything in the queue is
        /// dispatched, but nothing can be added to it)
        /// </summary>
        public void shutdown()
        {
            //Nothing to do
            if (!alive) return;

            alive = false;
            Monitor.Enter(q);
            Monitor.PulseAll(q);
            Monitor.Exit(q);
        }

        /// <summary>
        /// Will immediately shutdown the thread without cleaning up or clearing
        /// out the queue.  Consequently this is not the recommended way to terminate.
        /// </summary>
        public void abort()
        {
            if (!alive) return;

            alive = false;
            dispatch.Abort();
        }

        /// <summary>
        /// This is the worker method where the messages get dispatched
        /// </summary>
        protected void dispatchMessages()
        {
            //int max = 0;
            while (alive)
            {
                while ((q.Count != 0) && alive)
                {
                    //if(q.Count > max)max = q.Count;
                    log((LoggerMessage)q.Dequeue());
                }

                if ((alive) && (q.Count == 0))
                {
                    Monitor.Enter(q);
                    if (q.Count == 0) Monitor.Wait(q);
                    Monitor.Exit(q);
                }
            }

            //You will only reach this code if you are exiting the program
            //This block ensures the messages that were queued up will get dumped
            while (q.Count != 0)
            {
                log((LoggerMessage)q.Dequeue());
            }

            //Do any special shutdown you need to do
            onShutdown();

            //Remove thread reference so you don't have object leak
            dispatch = null;
        }

        /// <summary>
        /// Responsible for queuing the log message
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="level"></param>
        /// <param name="level_desc"></param>
        /// <param name="message"></param>
        public void log(string tag, logLevel level, string level_desc, string message)
        {
            if (!alive) return;

            LoggerMessage lm = new LoggerMessage();
            lm.message = message;
            lm.tag = tag;
            lm.level = level;
            lm.level_desc = level_desc;
            lm.time = System.DateTime.Now.ToFileTime();

            q.Enqueue(lm);

            Monitor.Enter(q);
            Monitor.PulseAll(q);
            Monitor.Exit(q);
        }

        /// <summary>
        /// User implementable log method (e.g. what actions they need to take to perform
        /// a "log" operation, like logging to a file for example).
        /// </summary>
        /// <param name="message"></param>
        protected abstract void log(LoggerMessage message);

        /// <summary>
        /// User implementable, meant for cleanup when the thread is stopped (e.g. if you need to
        /// close files, db connections, etc...)
        /// </summary>
        protected abstract void onShutdown();
    }

    /// <summary>
    /// Simple To File Logger.  All messages a written out to a flat text file.
    /// </summary>
    public class BasicFileLogEventHandler : LoggerEventHandler
    {
        StreamWriter stream = null;
        bool append = true;
        private string filename;
        private long last_flush_time = 0;
        private long diff_flush_time = 10000000; // 100 msec flush at least after
        private long max_file_length; // 1Mbyte
        private int num_file_save; // add circular backup

        public BasicFileLogEventHandler(String filename,
            long max_file_length = 1024*1024, int num_file_save = 4)
        {
            if (filename != null)
            {
                FileMode fm;

                if (append) fm = FileMode.Append;
                else fm = FileMode.Create;

                this.filename = filename;
                this.max_file_length = max_file_length;
                this.num_file_save = num_file_save;

                FileStream fs = new FileStream(filename, fm, FileAccess.Write, FileShare.Read);
                stream = new StreamWriter(fs, System.Text.Encoding.UTF8, 4096);
            }
        }
        private void rename_circular()
        {
            string nname;
            int i = num_file_save;
            string fname = filename + "." + i.ToString();
            if (System.IO.File.Exists(fname))
                System.IO.File.Delete(fname);
            for (i = num_file_save - 1; i >= 1; --i)
            {
                fname = filename + "." + i.ToString();
                nname = filename + "." + (i + 1).ToString();
                if (System.IO.File.Exists(nname))
                    System.IO.File.Delete(nname);
                if (System.IO.File.Exists(fname))
                    System.IO.File.Move(fname, nname);
            }
            nname = filename + "." + (1).ToString();
            if (System.IO.File.Exists(nname))
                System.IO.File.Delete(nname);
            if (System.IO.File.Exists(filename))
                System.IO.File.Move(filename, nname);
        }
        private void makeNew()
        {
            onShutdown();
            rename_circular();
            FileMode fm = FileMode.Create;
            FileStream fs = new FileStream(filename, fm, FileAccess.Write, FileShare.Read);
            stream = new StreamWriter(fs, System.Text.Encoding.UTF8, 4096);
        }

        private void checkFlush(long cur_time)
        {
            if (cur_time - last_flush_time > diff_flush_time)
            {
                stream.Flush();
                last_flush_time = cur_time;
                if (stream.BaseStream.Length >= max_file_length)
                {
                    makeNew();
                }
            }
        }

        override protected void log(LoggerMessage message)
        {
            if (stream == null) return;
            string time = System.DateTime.FromFileTime(message.time).ToString();
            string test = "[" + time + " [" + message.level + ":" + message.level_desc + " (" + message.tag + ")] " + message.message + " ]\r\n";
            stream.Write("[" + time + " [" + message.level + ":" + message.level_desc + " (" + message.tag + ")] " + message.message + " ]\r\n");
            checkFlush(message.time);
        }

        protected override void onShutdown()
        {
            if (stream != null)
            {
                stream.Flush();
                stream.Close();
            }
        }

        /// <summary>
        /// Flag to append the text file.  If this flag is not set it will overwrite.
        /// </summary>
        /// <param name="flag"></param>
        public void setAppend(bool flag)
        {
            this.append = flag;
        }

        /// <summary>
        /// Get's append flag
        /// </summary>
        /// <returns></returns>
        public bool getAppend()
        {
            return append;
        }
    }

    /// <summary>
    /// Primary class responsbile for logging.  This class is a combination between a singleton
    /// and a regular class to allow for the developers to have more customability.
    /// 
    /// One thing worth mentioning, the only thing that this system will not allow developers to
    /// customize is the use of consecutive integers for log levels starting at 0.  Developers are
    /// free to use however many levels they want, define them however they want, however... that is the
    /// one limitation I am comfortable placing on them.
    /// </summary>
    public class Logger
    {
        private static Logger logger;
        protected static string[] logLevelDesc = null;

        protected LoggerEventHandler[][] leh;
        protected logLevel max = logLevel.Critical;
        protected logLevel levels = logLevel.Critical;
        protected LoggerEventHandler defaultHandler = null;

        /// <summary>
        /// With this constructor the developer is responsible for defining what
        /// they want the logger to do (in the defaultHandler).
        /// </summary>
        /// <param name="levels"></param>
        /// <param name="defaultHandler"></param>
        public Logger(logLevel levels, LoggerEventHandler defaultHandler)
        {
            init(levels, defaultHandler);
        }

        /// <summary>
        /// Opens up a standard to file logger with the specified number of log levels.
        /// </summary>
        /// <param name="levels"></param>
        /// <param name="filename"></param>
        public Logger(logLevel levels, string filename, 
            long max_file_length = 1024*1024, int num_file_save = 4)
        {
            init(levels, new BasicFileLogEventHandler(filename, max_file_length, num_file_save));
        }

        /// <summary>
        /// User specifies only the number of log levels they require.  They are still obligated
        /// (assuming they want the logger to do something) to add a handler.
        /// </summary>
        /// <param name="levels"></param>
        public Logger(logLevel levels)
        {
            init(levels, null);
        }

        /// <summary>
        /// Takes the current object and places it as the internal singleton reference
        /// </summary>
        /// <returns></returns>
        public Logger promoteToStatic()
        {
            logger = this;
            return logger;
        }

        /// <summary>
        /// The singleton can get set in two ways:
        /// 
        /// 1.) The developer promotes their class to be the Logger object inside the singleton
        /// 2.) We decide for them what their class is going to look like
        /// </summary>
        /// <returns></returns>
        public static Logger singleton(string logfile = null,
            long max_file_length = 1024*1024, int num_file_save = 4)
        {
            if (logger == null)
            {
                //use defaults
                if (logfile == null)
                    logfile = DateTime.Now.ToShortDateString().Replace(@"/", @"-").Replace(@"\", @"-") + ".log";
                logger = new Logger(logLevel.MaxLog, logfile, max_file_length, num_file_save);
                logLevelDesc = new string[(int)logLevel.MaxLog];
                logLevelDesc[(int)logLevel.Critical] = "V_CRITICAL";
                logLevelDesc[(int)logLevel.Error] = "V_ERROR";
                logLevelDesc[(int)logLevel.Warn] = "V_WARN";
                logLevelDesc[(int)logLevel.Info] = "V_INFO";
                logLevelDesc[(int)logLevel.Debug] = "V_DEBUG";
                logLevelDesc[(int)logLevel.All] = "V_ALL";
            }
            return logger;
        }

        /// <summary>
        /// Effectively the constructor (so no code would have to be repeated).  Consequently
        /// if one were to try to put this block inside the constructor matching the signature and
        /// then referenced it with :this(levels, defaultHandler) in the other constructors MS
        /// has a bit of a fit.  Dunno...this works, don't really care.
        /// </summary>
        /// <param name="levels"></param>
        /// <param name="defaultHandler"></param>
        private void init(logLevel levels, LoggerEventHandler defaultHandler)
        {
            this.levels = levels;
            this.defaultHandler = defaultHandler;
            this.max = levels - 1;

            leh = new LoggerEventHandler[(int)levels][];

            LoggerEventHandler[] handler = new LoggerEventHandler[1];

            handler[0] = defaultHandler;

            for (int i = 0; i < (int)levels; i++)
            {
                leh[i] = handler;
            }
        }


        /// <summary>
        /// This is the maximum level which will trigger logging.
        /// </summary>
        /// <param name="min"></param>
        public void setMaximumLogLevel(logLevel max)
        {
            this.max = max;
        }

        /// <summary>
        /// Retrieve maximum logging level (note: this is not the total number of levels, but rather
        /// the upper bound where an action will or won't take placed based on the log level)
        /// </summary>
        /// <returns></returns>
        public logLevel getMaximumLogLevel()
        {
            return max;
        }

        /// <summary>
        /// Retreives the default handler if one is set
        /// </summary>
        /// <returns></returns>
        public LoggerEventHandler getDefaultLoggerEventHandler()
        {
            return this.defaultHandler;
        }

        /// <summary>
        /// Adds a customized log handler to each log level
        /// </summary>
        /// <param name="handler"></param>
        public void addSpecialLoggerToAllLevels(LoggerEventHandler handler)
        {
            if (handler == null) return;

            for (int lv = 0; lv < (int)this.levels; lv++)
            {
                addSpecialLogger((logLevel)lv, handler);
            }
        }

        /// <summary>
        /// Adds a customized logger handler (e.g. log to file) to a specific level.
        /// Note: You can have (n log handlers assuming your system has the resources)
        /// </summary>
        /// <param name="level"></param>
        /// <param name="handler"></param>
        public void addSpecialLogger(logLevel level, LoggerEventHandler handler)
        {
            if (level < levels)
            {
                if (leh[(int)level] != null)
                {
                    int size = leh[(int)level].Length + 1;
                    LoggerEventHandler[] temp = new LoggerEventHandler[size];

                    for (int i = 0; i < leh[(int)level].Length; i++)
                    {
                        temp[i] = leh[(int)level][i];
                    }

                    temp[size - 1] = handler;

                    leh[(int)level] = temp;
                }
                else
                {
                    leh[(int)level] = new LoggerEventHandler[1];
                    leh[(int)level][0] = handler;
                }
            }
        }

        /// <summary>
        /// Sugared method to add a simple file handler method
        /// </summary>
        /// <param name="level"></param>
        /// <param name="filename"></param>
        public void addSpecialLogger(logLevel level, string filename,
            long max_file_length = 1024*1024, int num_file_save = 4)
        {
            addSpecialLogger(level, new BasicFileLogEventHandler(filename, max_file_length, num_file_save));
        }

        /// <summary>
        /// Invokes all appropriate log event handlers with the message
        /// </summary>
        /// <param name="level"></param>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public void log(logLevel level, string tag, string message)
        {
            if ((level <= max) && (level < levels) && (leh[(int)level] != null))
            {
                for (int i = 0; i < leh[(int)level].Length; i++)
                {
                    if (logLevelDesc == null)
                    {
                        if (leh[(int)level][i] != null)
                            leh[(int)level][i].log(tag, level, "", message);
                    }
                    else
                    {
                        if (leh[(int)level][i] != null)
                            leh[(int)level][i].log(tag, level, logLevelDesc[(int)level], message);
                    }
                }
            }
        }

        /// <summary>
        /// Invokes the shutdown method for all log handlers
        /// </summary>
        public void shutdown()
        {
            //This is not the most efficient, really I'd like to add a collection
            //in this class and loop through it (save some repeats), also allow for some other neet stuff.
            for (int level = 0; level < leh.Length; level++)
            {
                for (int i = 0; i < leh[level].Length; i++)
                {
                    if (leh[level][i] != null) leh[level][i].shutdown();
                }
            }
        }
    }

    /***
    /// <summary>
    /// Test class, by no means a unit test, but more for experimenting
    /// </summary>
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Logger logger = new Logger(3, "test.txt");
            Logger logger = Logger.singleton("mytest.log");
            logger.addSpecialLogger(logLevel.Critical, "mytest-Critical.log", 1024 * 10, 6);
            logger.addSpecialLogger(logLevel.Error, "mytest-Error.log", 1024 * 5);

            for (int x = 0; x < 100; x++)
            {
                for (int i = 0; i < 100; i++)
                {
                    logger.log((logLevel)(i % (int)logLevel.MaxLog), "TEST", "message " + i);
                }
                Thread.Sleep(50);
            }
            Thread.Sleep(1100);
            System.Console.WriteLine("{0}", DateTime.Now.ToFileTime() / 10000);
            logger.log(logLevel.Critical, "Critical TEST", "message 1");
            logger.log(logLevel.Error, "Error TEST", "message 2");
            logger.log(logLevel.Warn, "Warn TEST", "message 3");
            //System.Console.ReadLine();
            logger.shutdown();
        }
    }
    ***/

}
