using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Ndmt.Model;

namespace Ndmt.Utils
{
    public class SearchableBindingList<T> : BindingList<T>
    {
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            Predicate<T> pred = delegate(T item)
            {
                if (prop.GetValue(item).Equals(key))
                    return true;
                else
                    return false;
            };
            List<T> list = Items as List<T>;
            if (list == null)
                return -1;
            return list.FindIndex(pred);

            //for (int i = 0; i < Count; i++)
            //{
            //    T item = this[i];
            //    if (property.GetValue(item).Equals(key))
            //    {
            //        return i;
            //    }
            //}
            //return -1; // Not found
        }
        //https://www.assembla.com/code/EZakaz/dA1rQWPXWr3A4Uab7jnrAJ/nodes/EZakaz/Core/Common/SortableBindingList.cs?rev=1
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemoveItemEventArgs> RemovingItem;

        /// <summary>
        /// 重载删除功能
        /// </summary>
        /// <param name="index"></param>
        protected override void RemoveItem(int index)
        {
            OnRemovingItem(new RemoveItemEventArgs(this[index]));
            base.RemoveItem(index);
        }

        protected virtual void OnRemovingItem(RemoveItemEventArgs args)
        {
            if (RemovingItem != null)
                RemovingItem(this, args);
        }


        /// <summary>
        /// 
        /// </summary>
        public class RemoveItemEventArgs : EventArgs
        {
            private readonly T removedItem;

            public T RemovedItem
            {
                get { return removedItem; }
            }

            public RemoveItemEventArgs(T removedItem)
            {
                this.removedItem = removedItem;
            }
        }

    }
}
