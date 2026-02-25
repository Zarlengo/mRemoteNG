using System;

namespace ExternalConnectors
{
    /// <summary>
    /// Notification bridge that allows external connectors to send messages to the host application.
    /// This avoids direct dependencies on mRemoteNG types.
    /// </summary>
    public static class NotificationBridge
    {
        /// <summary>
        /// Callback for sending informational messages.
        /// Set by the host application at startup.
        /// </summary>
        public static Action<string, bool>? ShowInformation { get; set; }

        /// <summary>
        /// Callback for sending warning messages.
        /// Set by the host application at startup.
        /// </summary>
        public static Action<string, bool>? ShowWarning { get; set; }

        /// <summary>
        /// Callback for sending error messages.
        /// Set by the host application at startup.
        /// </summary>
        public static Action<string, bool>? ShowError { get; set; }

        /// <summary>
        /// Callback for sending debug messages.
        /// Set by the host application at startup.
        /// </summary>
        public static Action<string>? ShowDebug { get; set; }

        /// <summary>
        /// Callback for sending exception messages.
        /// Set by the host application at startup.
        /// </summary>
        public static Action<string, Exception, bool>? ShowException { get; set; }
    }
}
