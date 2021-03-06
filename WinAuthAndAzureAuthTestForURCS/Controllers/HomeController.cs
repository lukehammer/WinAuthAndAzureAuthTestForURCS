﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using WinAuthAndAzureAuthTestForURCS.Models;
using WinAuthAndAzureAuthTestForURCS.Utils;

namespace WinAuthAndAzureAuthTestForURCS.Controllers
{



    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                //if I have user ID then I don't need to set session vars
                if (Session["userID"] == null)
                    URCSHelpers.setUserSession();
            }
            return View();
        }

        /// <summary>
        /// Send an OpenID Connect sign-in request.
        /// Alternatively, you can just decorate the SignIn method with the [Authorize] attribute
        /// </summary>
        public void SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }


        }

        /// <summary>
        /// Send an OpenID Connect sign-out request.
        /// </summary>
        public void SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                    OpenIdConnectAuthenticationDefaults.AuthenticationType,
                    CookieAuthenticationDefaults.AuthenticationType);
        }

        public void Oauth()
        {
            

        }
    }
}