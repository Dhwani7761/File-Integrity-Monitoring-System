using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class FileLogs
    {
        public int f_id { get; set; }
        public string f_name { get; set; }
        public string f_path { get; set; }
        public string f_action { get; set; }
        public string f_dtime = DateTime.Now.ToString();
        public string f_hname = System.Net.Dns.GetHostName();
    }
}