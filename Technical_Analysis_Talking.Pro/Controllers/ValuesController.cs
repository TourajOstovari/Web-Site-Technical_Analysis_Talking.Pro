using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
namespace Technical_Analysis_Talking.Pro.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "Please inform us which news idea you want by ?id= get method parameter" };
        }

        // GET api/values/5
        public dynamic Get(int id)
        {
            Technical_Analysis_Talking.Pro.App_Data.Database_StructContainer database_ = new App_Data.Database_StructContainer();
            Technical_Analysis_Talking.Pro.App_Data.Posts_ posts = database_.Posts_Set.FirstOrDefault((s) => s.Id == id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(posts);
        }
    }
}
