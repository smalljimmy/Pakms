﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using System.Configuration;

namespace PaK_v1._0.utilities
{
    public static class ServiceBrokerUtility
    {
        private static List<string> connectionStrings = new List<string>();
        private const string sqlDependencyCookie = "MS.SqlDependencyCookie";
        private static ObjectContext ctx;
        private static RefreshMode refreshMode;
        private static readonly Dictionary<string, IEnumerable> collections = new Dictionary<string, IEnumerable>();

        static public void AutoRefresh(this ObjectContext ctx,
                      RefreshMode refreshMode, IEnumerable collection)
        {
            var csInEF = ctx.Connection.ConnectionString;
            var csName = csInEF.Replace("name=", "").Trim();
            var csForEF = ConfigurationManager.ConnectionStrings[csName].ConnectionString; 
            var newConnectionString = new
              System.Data.EntityClient.EntityConnectionStringBuilder
                    (csForEF).ProviderConnectionString;
            if (!connectionStrings.Contains(newConnectionString))
            {
                connectionStrings.Add(newConnectionString);
                SqlDependency.Start(newConnectionString);
            }
            ServiceBrokerUtility.ctx = ctx;
            ServiceBrokerUtility.refreshMode = refreshMode;
            AutoRefresh(collection);
        }

        static public void AutoRefresh(IEnumerable collection)
        {
            var oldCookie = CallContext.GetData(sqlDependencyCookie);
            try
            {
                var dependency = new SqlDependency();
                collections.Add(dependency.Id, collection);
                CallContext.SetData(sqlDependencyCookie, dependency.Id);
                dependency.OnChange += dependency_OnChange;
                ctx.Refresh(refreshMode, collection);
            }
            finally
            {
                CallContext.SetData(sqlDependencyCookie, oldCookie);
            }
        }

        static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info == SqlNotificationInfo.Invalid)
            {
                Debug.Print("SqlNotification:  A statement was provided that cannot be notified.");
                return;
            }
            try
            {
                var id = ((SqlDependency)sender).Id;
                IEnumerable collection;
                if (collections.TryGetValue(id, out collection))
                {
                    collections.Remove(id);
                    AutoRefresh(collection);
                    var notifyRefresh = collection as INotifyRefresh;
                    if (notifyRefresh != null)
                        System.Windows.Application.Current.Dispatcher.BeginInvoke(
                          (Action)(notifyRefresh.OnRefresh));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Error in OnChange: {0}", ex.Message);
            }
        }
    }
}
