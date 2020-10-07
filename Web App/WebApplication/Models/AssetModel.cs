using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using WebApplication.Extensions;
using System.Web.Http.ModelBinding;

namespace WebApplication.Models
{
    public class AssetModel
    {

        public string ip { get; set; }
        public string host { get; set; }
        public string Os { get; set; }
        public string dt = DateTime.Now.ToString();
        public string uname = HttpContext.Current.User.Identity.GetUserNameIdentifier();
        }
    }