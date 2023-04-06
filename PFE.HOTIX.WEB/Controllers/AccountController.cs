using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PFE.HOTIX.WEB.Controllers
{
    public class AccountController : Controller
    {

        private IConfiguration _Config;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _Config = iConfig;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                if (username != null && password != null)
                {

                    Entities.User _User = Repository.User.GetOneByLogin(username);

                    if (_User == null)
                    {
                        return View("Login");
                    }

                    if (!_User.Authenticate(username.Trim(), Utils.Crypto.Encrypt(password, Entities.Constant.CONST_CIPHER_PHRASE)))
                    {
                        return View("Login");
                    }

                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(_User));

                    switch (_User.UserRole.Id)
                    {
                        case (int)Entities.Enumeration.UserRole.ADMIN:
                        case (int)Entities.Enumeration.UserRole.VEND:
                            return RedirectToAction("Dashboard", "Home");

                        case (int)Entities.Enumeration.UserRole.USER:
                            return RedirectToAction("Index", "Home");
                    }



                    #region Using API

                    //string API_URL = _Config.GetValue<string>("ApplicationParams:app_api_base_url");

                    //if (!string.IsNullOrEmpty(API_URL))
                    //{
                    //    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    //    HttpWebRequest req = WebRequest.Create(string.Concat(API_URL.TrimEnd(new Char[] { '/' }), @"/", "api/User/GetUserByLogin?Login=", username.Trim())) as HttpWebRequest;
                    //    req.Method = "GET";
                    //    req.Timeout = 30000;

                    //    using (var wResponse = (HttpWebResponse)req.GetResponse())
                    //    {
                    //        using (var sReader = new StreamReader(wResponse.GetResponseStream()))
                    //        {
                    //            string _Response = sReader.ReadToEnd();
                    //            if (_Response == null)
                    //            {
                    //                return View("Login");
                    //            }

                    //            JObject o = JObject.Parse(_Response);
                    //            //ApiResponse apiRes = o.ToObject<ApiResponse>();

                    //            //if ((apiRes == null) || (!apiRes.Success))
                    //            //{ 
                    //            //    return View("Login");
                    //            //}

                    //            //JObject JObj2 = JObject.Parse(apiRes.Data.ToString());
                    //            //Entities.User _User1 = (Entities.User)apiRes.Data;

                    //            JObject JObj = o["data"].Value<JObject>();
                    //            if (JObj != null)
                    //            {
                    //                Entities.User _User = JObj.ToObject<Entities.User>();

                    //                if (!_User.Authenticate(username.Trim(), Utils.Crypto.Encrypt(password, Entities.Constant.CONST_CIPHER_PHRASE)))
                    //                {
                    //                    return View("Login");
                    //                }

                    //                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(_User));
                    //                return RedirectToAction("Index", "Home");
                    //            }
                    //            else
                    //            {
                    //                return View("Login");
                    //            }
                    //        }
                    //    }
                    //}

                    #endregion

                    return View("Login");

                    //Entities.User User = new Entities.User() { Id = 1, FirstName = "Admin", LastName = "Admin", Login = "ADMIN", Email = "admin@mail.com" };
                    //HttpContext.Session.SetString("User", JsonConvert.SerializeObject(User));
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Entities.User User)
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Recover(string Email)
        {
            return View("Register");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
        }
    }
}
