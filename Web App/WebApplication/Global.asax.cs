using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //    string path = @"C:\"; //watch
            //    FileSystemWatcher fs = new FileSystemWatcher(path);

            //    fs.EnableRaisingEvents = true; // must be set to true
            //    fs.IncludeSubdirectories = true;

            //    fs.NotifyFilter = NotifyFilters.Attributes |
            //      NotifyFilters.CreationTime |
            //      NotifyFilters.DirectoryName |
            //      NotifyFilters.FileName |
            //      NotifyFilters.LastAccess |
            //      NotifyFilters.LastWrite |
            //      NotifyFilters.Security |
            //      NotifyFilters.Size;

            //    //    fs.Changed += new FileSystemEventHandler(fs_Changed);
            //    fs.Renamed += new RenamedEventHandler(fs_Renamed);
            //    fs.Created += new FileSystemEventHandler(OnChanged);
            //    fs.Deleted += new FileSystemEventHandler(OnChanged);


            //    Application.Add("watcher", fs);
            //}
            //public static void OnChanged(object sender, FileSystemEventArgs e)
            //{
            //    WatcherChangeTypes wct = e.ChangeType;
            //    if (wct.ToString() == "Created")
            //    {
            //        string path = @"C:\Users\hp\Desktop\Logs.txt";
            //        File.AppendAllText(path, e.Name + " created " + ";" + Environment.NewLine);
            //    }
            //    else if (wct.ToString() == "Deleted")
            //    {
            //        string path = @"C:\Users\hp\Desktop\Logs.txt";
            //        File.AppendAllText(path, e.Name + " deleted" + ";" + Environment.NewLine);
            //    }
            //}
            ////public static void fs_Created(object sender, FileSystemEventArgs e)
            ////{
            ////    string path = @"C:\Users\hp\Desktop\a.txt";
            ////    File.AppendAllText(path, e.Name + " is created ");
            ////}
            //public static void fs_Renamed(object sender, RenamedEventArgs e)
            //{
            //    string path = @"C:\Users\hp\Desktop\Logs.txt";
            //    File.WriteAllText(path, e.ChangeType + e.OldFullPath + " renamed " + ";" + e.FullPath + Environment.NewLine);
            //}
            //public void fs_Changed(object sender, FileSystemEventArgs e)
            //{
            //     string path = @"C:\Users\hp\Desktop\Logs.txt";
            //    File.AppendAllText(path, e.Name + " is changed ");
            //}
            ////public static void fs_Deleted(object sender, FileSystemEventArgs e)
            ////{
            ////    string path = @"C:\Users\hp\Desktop\a.txt";
            ////    File.AppendAllText(path, e.Name + "is deleted");
            ////}
        }
    }
}

