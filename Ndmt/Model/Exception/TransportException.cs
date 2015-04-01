using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevExpress.Xpo.DB.Exceptions;
using ManagedUPnP;
using Starksoft.Net.Ftp;

namespace Ndmt.Model
{
    [Serializable]
    class TransportException : System.Exception
    {
        public enum TransportErrorCode : int
        {
            UPNP_ERROR = 0x0010,
            FTP_ERROR = 0x0020,
            DATABASE_LINK_ERROR = 0x0030,
            WAIT_FOR_MOUNTED_SIGNAL_OVERTIME = 0x0140,
            USB_BUSY = 0x0050
        }

        public const string MultipleLinkAttemptFailed = @"多次尝试连接设备失败";
        public const string WaitForCanMountSignalOvertime = @"等待设备连接响应超时";

        public TransportException(string message, string source, TransportErrorCode code, Exception innerException = null)
            : base(message, innerException)
        {
            this.mecCode = code;
            this.Source = source;
            LogHelper.LogHere("TransportException",message, source, code);
        }

        public TransportException(UPnPException upnpex, string source)
            : this(upnpex.Message, source, TransportErrorCode.UPNP_ERROR, upnpex)
        {
        }

        public TransportException(FtpException ftpex, string source)
            : this(ftpex.Message, source, TransportErrorCode.FTP_ERROR, ftpex)
        {
        }

        public TransportException(SqlExecutionErrorException sqlex, string source)
            : this(sqlex.Message, source, TransportErrorCode.DATABASE_LINK_ERROR, sqlex)
        {
        }


        #region Protected Locals

        /// <summary>
        /// The TransportErrorCode for the error
        /// </summary>
        protected TransportErrorCode mecCode;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the underlying TransportErrorCode
        /// </summary>
        public TransportErrorCode Code
        {
            get
            {
                return mecCode;
            }
        }

        #endregion
    }
}
