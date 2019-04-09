using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EPM.Models;
using EPM.Models.Enum;
using JMAInsurance.Entity.Enum;
using JMAInsurance.Entity.Security;

namespace JMAInsurance.Entity
{
    public class SessionManager
    {
        private readonly JMAInsuranceContext db;
        public static SessionManager Current
        {
            get
            {
                try
                {
                    return DependencyResolver.Current?.GetService<SessionManager>();
                }
                catch
                {

                    return null;
                }
            }
        }
        public SessionManager(JMAInsuranceContext db)
        {
            this.db = db;
        }
        //public User CurrentLoggedInUser
        //{
        //    get
        //    {
        //        if (null != System.Web.HttpContext.Current &&
        //            null != System.Web.HttpContext.Current.Session["CurrentLoggedInUser"])
        //        {
        //            return System.Web.HttpContext.Current.Session["CurrentLoggedInUser"] as User;
        //        }

        //        var user = GetUser();

        //        if (System.Web.HttpContext.Current != null)
        //        {
        //            System.Web.HttpContext.Current.Session["CurrentLoggedInUser"] = user;
        //        }

        //        return user;
        //    }
        //    set => System.Web.HttpContext.Current.Session["CurrentLoggedInUser"] = value;
        //}
        //public User CurrentLoggedInUserWithNoDelegation
        //{
        //    get
        //    {

        //        if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session["CurrentLoggedInUserWithNoDelegation"])
        //            return System.Web.HttpContext.Current.Session["CurrentLoggedInUserWithNoDelegation"] as User;
        //        var user = GetUser();
        //        if (null == user)
        //        {
        //            return null;
        //        }
        //        if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AutomaticAppStartup"]))
        //        {
        //            var stop = userName.IndexOf("\\", StringComparison.Ordinal);
        //            userName = (stop > -1) ? userName.Substring(stop + 1, userName.Length - stop - 1) : userName;
        //        }



        //        if (System.Web.HttpContext.Current != null)
        //        {
        //            System.Web.HttpContext.Current.Session["CurrentLoggedInUserWithNoDelegation"] = user;
        //        }

        //        return user;
        //    }
        //    set => System.Web.HttpContext.Current.Session["CurrentLoggedInUserWithNoDelegation"] = value;
        //}
        //public List<int> AllowedThemesId
        //{
        //    get
        //    {
        //        if (null != System.Web.HttpContext.Current &&
        //            null != System.Web.HttpContext.Current.Session["AllowedThemesId"])
        //        {
        //            return System.Web.HttpContext.Current.Session["AllowedThemesId"] as List<int>;
        //        }

        //        var currentUser = CurrentLoggedInUser;

        //        if (currentUser == null)
        //        {
        //            return new List<int>();
        //        }

        //        var userPermissionIds = currentUser.UserPermissions.Select(z => z.UserPermissionId).ToList();

               

             

               

        //        return System.Web.HttpContext.Current.Session["AllowedThemesId"] as List<int>;
        //    }
        //    set => System.Web.HttpContext.Current.Session["AllowedThemesId"] = value;
        //}
        public enum_Language CurrentLanguage
        {
            get
            {
                if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session["CurrentLanguage"])
                    return (enum_Language)System.Web.HttpContext.Current.Session["CurrentLanguage"];
                else
                    return enum_Language.Arabic;
            }
            set => System.Web.HttpContext.Current.Session["CurrentLanguage"] = value;
        }

      





    }
}