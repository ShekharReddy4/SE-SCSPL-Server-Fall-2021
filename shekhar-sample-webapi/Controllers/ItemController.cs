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
    public class ItemController : ControllerBase
    {
        // GET: api/<ItemController>
        [HttpGet]
        public string Get()
        {
            string filepath = "./Data/data.json";
            string result = string.Empty;
            string json;
            using (StreamReader r = new StreamReader(filepath))
            {
                json = r.ReadToEnd();
                Console.WriteLine(json);
                var jobj = JObject.Parse(json);
                Console.WriteLine(jobj);
                
                //var jobj = JObject.Parse(json);
                //foreach (var item in jobj.Properties())
                //{
                //    item.Value = item.Value.ToString().Replace("v1", "v2");
                //}
                //result = jobj.ToString();

                Console.WriteLine(result);
            }
            return json;
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string filepath = "./Data/data.json";
            string result = string.Empty;
            Item items;
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                JArray itemsArray = (JArray)jobj["Items"];
                List<Item> li = JsonConvert.DeserializeObject<List<Item>>(itemsArray.ToString());
                items =  li.SingleOrDefault(x => x.ID == id);
                
            }

            //return JsonConvert.SerializeObject(items).Select( x => new Item
            //    {
            //        ID = items.ID,
            //        Name = items.Name,
            //        Discount = items.Discount,
            //        StockCount = items.StockCount
            //    }).ToArray();

            return JsonConvert.SerializeObject(items);


            
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
