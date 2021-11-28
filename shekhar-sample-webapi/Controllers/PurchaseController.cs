using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using shekhar_sample_webapi.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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
        public bool Post([FromBody]PurchaseModel purchase_object)
        {
            // card details verification
            bool isPaymentSucccessful = false;
            if(purchase_object.cardDetailsArray != null)
            {
                using (StreamReader r = new StreamReader("./Data/data.json"))
                {
                    var json = r.ReadToEnd();
                    var jobj = JObject.Parse(json);
                    JArray cardDetailsArray = (JArray)jobj["cardDetailsArray"];
                    foreach (JObject i in cardDetailsArray) // <-- Note that here we used JObject instead of usual JProperty
                    {
                        var tempCardDetailsObj = JsonConvert.DeserializeObject<CardDetails>(i.ToString());
                        if (purchase_object.cardDetailsArray.Contains(tempCardDetailsObj))
                        {
                            isPaymentSucccessful = true;
                        }
                    }
                }
            }
            // Check payment details verification
            else if (purchase_object.checkidArray != null)
            {
                using (StreamReader r = new StreamReader("./Data/data.json"))
                {
                    var json = r.ReadToEnd();
                    var jobj = JObject.Parse(json);
                    JArray checkidarray = (JArray)jobj["checkidarray"];
                    foreach (JObject i in checkidarray) // <-- Note that here we used JObject instead of usual JProperty
                    {
                        var tempCardDetailsObj = JsonConvert.DeserializeObject<int>(i.ToString());
                        if (purchase_object.checkidArray.Contains((int)i))
                        {
                            isPaymentSucccessful = true;
                        }
                    }
                }
            }
            // check if cash option is enabled
            else if (purchase_object.iscash)
            {
                isPaymentSucccessful = true;
            }
            else
            {
                isPaymentSucccessful = false;
            }

            if(isPaymentSucccessful)
            {
                UpdateStockCount(purchase_object);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateStockCount(PurchaseModel purchase_object)
        {
            // get the ids of the items array and reduce the stock count
            var itemIDsArray = purchase_object.Items.Select(x => x.ID).ToList();

            using (StreamReader r = new StreamReader("./Data/data.json"))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                JArray itemsArray = (JArray)jobj["Items"];
                foreach (JObject item in itemsArray) // <-- Note that here we used JObject instead of usual JProperty
                {
                    if (itemIDsArray.Contains((int)item.GetValue("ID")))
                    {
                        int existingStockCount = (int)item.GetValue("StockCount");
                        int currentStockCount = existingStockCount - 1;
                        JToken SCToken = item.SelectToken("StockCount");
                        SCToken.Replace(currentStockCount);
                    }

                }
                string output = JsonConvert.SerializeObject(jobj, Formatting.Indented);
                System.IO.File.WriteAllText("./Data/data.json", output);

            }
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
