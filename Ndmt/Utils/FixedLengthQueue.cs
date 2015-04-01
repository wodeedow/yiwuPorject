using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ndmt.Utils
{
    public class FixedLengthQueue<T> : Queue<T>, INotifyPropertyChanged
    {
        /// <summary>
        /// 固定大小的队列初始化
        /// </summary>
        /// <param name="length"></param>
        public FixedLengthQueue(int length) :base(length + 1)
        {
            this.capacity = length;
        }

        /// <summary>
        /// 覆盖原有Enqueue以保证不超出capacity
        /// </summary>
        /// <param name="item"></param>
        new public void Enqueue(T item)
        {
            base.Enqueue(item);
            while (this.Count > this.capacity)
            {
                base.Dequeue();
            }
            NotifyPropertyChanged("Joint");
        }

        /// <summary>
        /// 队列容量
        /// </summary>
        public int Capacity
        {
            get { return this.capacity; } 
        }

        private int capacity;

        /// <summary>
        /// 实现INotifyPropertyChanged接口
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public delegate string ItemToString(T item);
        public ItemToString ToStringDelegateImpl;

        public delegate IEnumerable<T> QueueFilter(FixedLengthQueue<T> queue);
        public QueueFilter FilterDelegateImpl
        {
            get { return this.filterDelImpl; }
            set
            {
                filterDelImpl = value;
                NotifyPropertyChanged("Joint");
            }
        }
        private QueueFilter filterDelImpl;

        private String[] ToReadableArray()
        {
            try
            {
                ItemToString i2s = ToStringDelegateImpl.GetInvocationList().First() as ItemToString;
                IEnumerable<string> subset;
                if (FilterDelegateImpl != null)
                {
                    QueueFilter qf = FilterDelegateImpl.GetInvocationList().First() as QueueFilter;
                    subset = from it in qf(this)
                             select i2s(it);
                }
                else
                {
                    subset = from it in this
                             select i2s(it);
                }
                return subset.ToArray<String>();
            }
            catch { }
            return new String[0];
        }

        /// <summary>
        /// 将队列中内容输出
        /// </summary>
        public string Joint
        {
            get
            {
                return (this.Count == 0) ? String.Empty : String.Join("\n", ToReadableArray());
            }
        }
    }
}
