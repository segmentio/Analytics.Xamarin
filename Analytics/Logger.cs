﻿using Segment.Model;

namespace Segment
{
    /// <summary>
    /// Analytics Logging
    /// </summary>
    public class Logger
    {

        /// <summary>
        /// The logging level of the message
        /// </summary>
        public enum Level
        {
            DEBUG,
            INFO,
            WARN,
            ERROR
        }

        /// <summary>
        /// A logging event handler.   
        /// </summary>
        /// <param name="level">The <see cref="Segment.Logger.Level"/> of the log event (debug, info, warn, error)</param>
        /// <param name="message">The log message</param>
        /// <param name="args">Optional arguments for the message</param>
        public delegate void LogHandler(Level level, string message, Dict args);
        public static event LogHandler Handlers;

        private static void _Log(Level level, string message, Dict args)
        {
            Handlers?.Invoke(level, message, args);
        }

        internal static void Debug(string message)
        {
            _Log(Level.DEBUG, message, null);
        }

        internal static void Debug(string message, Dict args)
        {
            _Log(Level.DEBUG, message, args);
        }

        internal static void Info(string message)
        {
            _Log(Level.INFO, message, null);
        }

        internal static void Info(string message, Dict args)
        {
            _Log(Level.INFO, message, args);
        }
        internal static void Warn(string message)
        {
            _Log(Level.WARN, message, null);
        }

        internal static void Warn(string message, Dict args)
        {
            _Log(Level.WARN, message, args);
        }
        internal static void Error(string message)
        {
            _Log(Level.ERROR, message, null);
        }

        internal static void Error(string message, Dict args)
        {
            _Log(Level.ERROR, message, args);
        }
     
    }
}
