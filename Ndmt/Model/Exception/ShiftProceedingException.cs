using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.Xpo.DB.Exceptions;

namespace Ndmt.Model
{
    [Serializable]
    public class ShiftProceedingException : Exception
    {
        public const string ErrorString = @"机台号有误或订单未找到";

        public ShiftProceedingException(string message, string source, Exception innerException = null)
            : base(message, innerException)
        {
            this.Source = source;
            LogHelper.LogHere("ShiftProceedingException", message, source);
        }

        public ShiftProceedingException(FileNotFoundException filex, string source)
            : this(filex.Message, source, filex)
        {
        }

    }
}
