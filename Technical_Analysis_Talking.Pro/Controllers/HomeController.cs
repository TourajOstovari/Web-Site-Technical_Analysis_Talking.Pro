using System.Linq;
using System.Web.Mvc;
using PagedList;
namespace Technical_Analysis_Talking.Pro.Controllers
{
    public class HomeController : Controller
    {
        Technical_Analysis_Talking.Pro.App_Data.Database_StructContainer _StructContainer = new App_Data.Database_StructContainer();
        public ActionResult Index()
        {
            App_Data.Posts_ posts_ = new App_Data.Posts_();
            //if(_StructContainer.Posts_Set.Count()>0)
            App_Data.Posts_[] test = _StructContainer.Posts_Set.ToArray();
            if (_StructContainer.Interest_rate.FirstOrDefault() != null) { 
            App_Data.Interest_rate interest_ = _StructContainer.Interest_rate.First();
            ViewData["eur_rate"] = interest_.eur_rate;
            ViewData["usd_rate"] = interest_.usd_rate;
            ViewData["gbp_rate"] = interest_.gbp_rate;
        }

            App_Data.Posts_[] posts_s = new App_Data.Posts_[4];
            
            if (test.Length - 3 >= 0)
            {
                int temp_Counter = 0;
                for (int i = (test.Length-1); i >= test.Length - 3; i--)
                {
                    posts_s[temp_Counter++] = test[i];
                }
            }
            else {
                for (int i = 0; i <= test.Length-1; i++)
                {
                    posts_s[i] = test[i];
                }
            }
            return View(posts_s);

        }
        public ActionResult Archive(int page=1)
        {
            App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            App_Data.Posts_[] post_s = database_.Posts_Set.ToArray();
            return View("Analysis_Blog",post_s.ToPagedList(page,3));
        }
        [HttpPost]
        public ActionResult Subscribe(App_Data.news_subscribe new_user)
        {
            if (ModelState.IsValid) { 
            _StructContainer.news_subscribe.Add(new_user);
            _StructContainer.SaveChanges();
                ModelState.AddModelError("Successfully", "You are subscribed Successfully.");
            }
            return View("index");
        }
        public ActionResult Viewpost()
        {
            App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            if (Request.QueryString["id"] != null)
            {
                int ids = int.Parse(Request.QueryString["id"].ToString());
                App_Data.Posts_ post = database_.Posts_Set.FirstOrDefault((s) => s.Id == ids);
                if (post.Id >= 0)
                    return View(post);
                else
                    return View();
            }
            return View();
            
        }
    }
}
