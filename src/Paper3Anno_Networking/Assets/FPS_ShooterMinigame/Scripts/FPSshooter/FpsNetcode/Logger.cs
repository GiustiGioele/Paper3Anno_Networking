using UnityEngine;

namespace FPShooter
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lockObject = new object();

        // Private constructor to prevent instantiation from outside
        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        public void LogInfo(string message)
        {
            Debug.Log(message);
        }
    }

}
