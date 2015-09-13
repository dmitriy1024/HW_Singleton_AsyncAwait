using System;
using System.IO;

namespace WebApp
{
    public enum MessageType
    {
        Warn,
        Error,
        Info
    }

    public class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger(), true);
        private static readonly object _locker = new object();

        private Logger() { }

        public static Logger Instance
        {
            get { return _instance.Value; }
        }

        public void Write(Exception e, MessageType messType = MessageType.Info)
        {
            WriteToFile(String.Format("{0} - {1} - {2} - {3}", messType, DateTime.Now, e.GetType(), e.Message));
        }

        public void Write(Exception e, string message, MessageType messType = MessageType.Info)
        {
            WriteToFile(String.Format("{0} - {1} - {2} - {3}", messType, DateTime.Now, e.GetType(), message));
        }

        public void Write(string message, MessageType messType = MessageType.Info)
        {
            WriteToFile(String.Format("{0} - {1} - {2}", messType, DateTime.Now, message));
        }

        private void WriteToFile(string str)
        {
            StreamWriter writer = new StreamWriter(@"D:\log.txt",true);
            writer.WriteLine(str);
            writer.Close();
        }
    }
}