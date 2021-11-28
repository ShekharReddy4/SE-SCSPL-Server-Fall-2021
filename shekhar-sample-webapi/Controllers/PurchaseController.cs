using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using shekhar_sample_webapi.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shekhar_sample_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        // GET: api/<PurchaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PurchaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PurchaseController>
        [HttpPost]
        public void Post([FromBody] string purchase_object)
        {
            List<PurchaseModel> pmObject = JsonConvert.DeserializeObject<List<PurchaseModel>>(purchase_object.ToString());

            // get the ids of the items array
            var IDsArray = pmObject[0].items.Select(x => x.ID).ToList();

            // get those products from json file and update the stock and then rewrite
            // string filepath = "./Data/data.json";
            //string json = File.ReadAllText("settings.json");
            //dynamic jsonObj = JsonConvert.DeserializeObject(json);
            //jsonObj["Bots"][0]["Password"] = "new password";
            //string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            // object p = File.WriteAllText("settings.json", output);
            /*
            using (StreamReader r = new StreamReader("./Data/data.json"))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                JArray itemsArray = (JArray)jobj["Items"];
                foreach (JObject item in itemsArray) // <-- Note that here we used JObject instead of usual JProperty
                {
                    if (IDsArray.Contains((int)item.GetValue("ID")))
                    {
                        item.
                    }
                    string name = item.GetValue("name").ToString();
                    string url = item.GetValue("url").ToString();
                    // ...
                }



                List<Item> li = JsonConvert.DeserializeObject<List<Item>>(itemsArray.ToString());
                items = li.SingleOrDefault(x => x.ID == id);

            }*/



        }

        // PUT api/<PurchaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
