using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RGVApiDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RGVApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RgvController : ControllerBase
    {
        // GET: api/<RgvController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RgvController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("/reeman/global_plan")]
        public string Global_Plan()
        {
            Coordinance coordinance = new Coordinance() { x_axis = 1119.76f, y_axis = 987.56f, theta = 1234.89f };
            return JsonConvert.SerializeObject(coordinance);
        }

        [HttpGet("/reeman/lcoal_plan")]
        public string Local_Plan()
        {
            Coordinance coordinance = new Coordinance() { x_axis = 4324.09f, y_axis = 353.89f, theta = 7655.4f };
            return JsonConvert.SerializeObject(coordinance);
        }

        [HttpGet("/reeman/pose")]
        public string Pose()
        {
            Coordinance coordinance = new Coordinance() { x_axis = 297f, y_axis = 251f, theta = 0.97f };
            return JsonConvert.SerializeObject(coordinance);
        }

        [HttpGet("/reeman/movebase_status")]
        public string MoveBase_Status()
        {
            Status status = new Status() { status=0 };
            return JsonConvert.SerializeObject(status);
        }

        [HttpGet("/reeman/base_encode")]
        public string Base_Encode()
        {
            Battery battery = new Battery() { battery=100, chargeFlag=1,emergencyButton=0 };
            return JsonConvert.SerializeObject(battery);
        }

        // POST api/<RgvController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        [HttpPost("/cmd/nav")]
        public void Nav([FromBody] string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Coordinance? coordinance = JsonConvert.DeserializeObject<Coordinance>(value);
                    string out_put = $"Received coordinace with x: {coordinance.x_axis},y:{coordinance.y_axis},theta:{coordinance.theta} ";
                    Console.WriteLine(out_put);
                }
                else
                {
                    Console.WriteLine("nothing received");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
          
        }

        [HttpPost("/cmd/cancel_goal")]
        public void Cancel_Goal()
        {

        }

        [HttpPost("/cmd/charge")]
        public void Charge([FromBody] string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Charge? charge = JsonConvert.DeserializeObject<Charge>(value);
                    string out_put = $"Received type: {charge.type},point:{charge.point}";
                    Console.WriteLine(out_put);
                }
                else
                {
                    Console.WriteLine("nothing received");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost("/cmd/nav_point")]
        public void Nav_Point([FromBody] string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Target? target = JsonConvert.DeserializeObject<Target>(value);
                    string out_put = $"Received navigation name {target.point} ";
                    Console.WriteLine(out_put);
                }
                else
                {
                    Console.WriteLine("nothing received");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        [HttpPost("/cmd/speed")]
        public void Speed([FromBody] string value)
        {

        }
        // PUT api/<RgvController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Move? move = JsonConvert.DeserializeObject<Move>(value);
                    string out_put = $"Received vx: {move.vx} and vth:{move.vth} ";
                    Console.WriteLine(out_put);
                }
                else
                {
                    Console.WriteLine("nothing received");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/<RgvController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       
    }
}
