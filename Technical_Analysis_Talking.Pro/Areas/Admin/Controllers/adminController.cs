
namespace Technical_Analysis_Talking.Pro.Areas.Admin.Controllers
{
    using Newtonsoft.Json;
    using PagedList;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Validate_Login(Technical_Analysis_Talking.Pro.App_Data.Users_ users)
        {
            Technical_Analysis_Talking.Pro.App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            App_Data.Users_ result = database_.Users_Set.FirstOrDefault((s) => (s.username == users.username && s.password == users.password));

            /*
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdeqcUUAAAAANvc_bhMz0Kf71Df5bc28SdIpWp6";
            var client = new WebClient();
            var result2 = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<CaptchaResponse>(result2);
            var status = (bool)obj.Success;
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
            */

            App_Data.Posts_[] posts = database_.Posts_Set.ToArray();
            if (result != null)
                if (result.username == users.username && result.password == users.password) { result.last_login_time = System.DateTime.Now.ToShortDateString(); database_.SaveChanges(); ViewData["loging_State"] = "true"; return View("Admin_panel", posts.ToPagedList(1, 10)); }
            return View("login");
        }

        public ActionResult Admin_Panel(int page)
        {
            Technical_Analysis_Talking.Pro.App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            App_Data.Posts_[] posts = database_.Posts_Set.ToArray();
            ViewData["pager"] = page;
            if (ViewData["loging_State"] != "")
            {
                return View("Admin_panel", posts.ToPagedList(int.Parse(ViewData["pager"].ToString()), 10));
            }
            return View("login");
        }
        [HttpPost]
        public ActionResult Insert_New(HttpPostedFileBase file, App_Data.Posts_ posts_)
        {
            Technical_Analysis_Talking.Pro.App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            App_Data.Posts_[] posts = database_.Posts_Set.ToArray();
            if (ViewData["loging_State"] != "")
            {
                //App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
                file.SaveAs(Server.MapPath(@"~/images/" + file.FileName));
                posts_.image = file.FileName;
                database_.Posts_Set.Add(posts_);
                database_.SaveChanges();
                ModelState.AddModelError("Saved", "Saved Succesfully ...");
            }
            return View("Admin_panel", posts.ToPagedList(int.Parse(ViewData["pager"].ToString()), 10));
        }
        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorMessage { get; set; }
        }
        public ActionResult update_interest(App_Data.Interest_rate rates)
        {
            App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            if (database_.Interest_rate.Count<App_Data.Interest_rate>() == 0)
            {
                database_.Interest_rate.Add(rates);
            }
            else
            {
                System.Collections.Generic.IEnumerable<App_Data.Interest_rate> _Rate = database_.Interest_rate;
                database_.Interest_rate.RemoveRange(_Rate);
                database_.SaveChanges();
                database_.Interest_rate.Add(rates);
                database_.SaveChanges();
            }
            database_.SaveChanges();
            App_Data.Posts_[] posts = database_.Posts_Set.ToArray();
            return View("admin_panel", posts.ToPagedList(int.Parse(ViewData["pager"].ToString()), 10));
        }
        public ActionResult Sign_Out()
        {
            ViewData["loging_State"] = "";
            return View("Index");
        }
        public ActionResult Delete_Post()
        {
            App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            if (ViewData["loging_State"] != "")
                if (RouteData.Values["id"] != null)
                {

                    int ids = int.Parse(RouteData.Values["id"].ToString());
                    App_Data.Posts_ posts = database_.Posts_Set.FirstOrDefault((s) => s.Id == ids);
                    database_.Posts_Set.Remove(posts);
                    database_.SaveChanges();
                }
            App_Data.Posts_[] post_s = database_.Posts_Set.ToArray();
            return View("admin_panel", post_s.ToPagedList(1, 10));
        }
    }
}