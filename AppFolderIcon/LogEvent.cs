// <copyright file="LogEvent.cs" company="PublicDomain.com">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace AppFolderIcon
{
    // Directives
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Log event.
    /// </summary>
    public class LogEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppFolderIcon.LogEvent"/> class.
        /// </summary>
        public LogEvent()
        {
            // Parameterless cnostructor
        }

        public void WriteEvent(string eventTitle, string eventBody)
        {
            // Declare string buffer
            StringBuilder stringBuilder = new StringBuilder();

            // Event body
            stringBuilder.AppendLine("----------");
            stringBuilder.AppendLine($"Event: {eventTitle}");
            stringBuilder.AppendLine($"{eventBody}");

            // Log to disk
            File.AppendAllText("AppFolderIcon-EventLog.txt", stringBuilder.ToString());
        }
    }
}
