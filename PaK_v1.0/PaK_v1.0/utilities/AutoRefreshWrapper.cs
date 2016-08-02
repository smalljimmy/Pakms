using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaK_v1._0.utilities
{
    public class AutoRefreshWrapper<T> : IEnumerable<T>, INotifyRefresh
        where T : EntityObject
    {
        private IEnumerable<T> objectQuery;
        public AutoRefreshWrapper(ObjectQuery<T> objectQuery, RefreshMode refreshMode)
        {
            this.objectQuery = objectQuery;
            objectQuery.Context.AutoRefresh(refreshMode, this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return objectQuery.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void OnRefresh()
        {
            try
            {
                if (this.CollectionChanged != null)
                    CollectionChanged(this,
                      new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Error in OnRefresh: {0}", ex.Message);
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
