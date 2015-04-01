using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model.Events
{
    /// <summary>
    /// 设备机台名更改参数
    /// </summary>
    public class FriendlyNameChangedEventArgs : EventArgs
    {
        private string mOldFriendlyName;
        private string mNewFriendlyName;

        public FriendlyNameChangedEventArgs(string oldFriendlyName, string newFriendlyName) :
            base()
        {
            this.mNewFriendlyName = newFriendlyName;
            this.mOldFriendlyName = oldFriendlyName;
        }

        public string OldFriendlyName
        {
            get { return this.mOldFriendlyName; }
        }

        public string NewFriendlyName
        {
            get { return this.mNewFriendlyName; }
        }
    }

}
