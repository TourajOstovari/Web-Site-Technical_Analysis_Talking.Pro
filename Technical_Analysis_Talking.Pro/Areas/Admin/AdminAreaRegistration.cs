﻿using System.Web.Mvc;

namespace Technical_Analysis_Talking.Pro.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Admin" , action = "login", id = UrlParameter.Optional }
            );
        }
    }
}