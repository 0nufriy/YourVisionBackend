using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Metods;
using Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmotionalController : ControllerBase
    {

        private readonly IEmotionService Eservice;
        private readonly ISessionService Sservice;
        public EmotionalController(IEmotionService emotionalService, ISessionService sessionService)
        {
            Eservice = emotionalService;
            Sservice = sessionService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("setConfig/{id}")]
        public async Task<ActionResult<bool>> puplishConfig(int id, PersonAudience[] list)
        {
            var session = await Sservice.SessionGetById(id);
            if(session == null)
            {
                return NotFound();
            }
            var mqttFactory = new MqttFactory();
            using (var mqttClient = mqttFactory.CreateMqttClient())
            {

                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithClientId("Onufriy_web_api")
                    .WithTcpServer("7b26d5ab55b440aea791d3c891152fcf.s1.eu.hivemq.cloud")
                    .WithCredentials("hivemq.webclient.1683143341233", "0A<m8*b9.tK&B5xXqHSh")
                    .WithTls()
                    .WithCleanSession()
                    .Build();

                var a = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                foreach (var person in list)
                {
                    Config config = new Config();
                    config.SessionId = id;
                    config.AudienceID = person.AudienceId;
                    config.DurationMinute = session.DurationMinute;
                    var message = new MqttApplicationMessageBuilder()
                    .WithTopic("config" + person.PersonId.ToString())
                    .WithPayload(JsonConvert.SerializeObject(config))
                    .Build();
                    mqttClient.PublishAsync(message);
                }
            }
            return Ok(true);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("startSession/{id}")]
        public async Task<ActionResult<bool>> startSession(int id)
        {
            var session = await Sservice.SessionGetById(id);
            if(session == null)
            {
                return NotFound();
            }
            var mqttFactory = new MqttFactory();

            var count_done = 0;
            bool cont = true;
            using (var mqttClient = mqttFactory.CreateMqttClient())
            {

                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithClientId("Onufriy_web_api")
                    .WithTcpServer("7b26d5ab55b440aea791d3c891152fcf.s1.eu.hivemq.cloud")
                    .WithCredentials("hivemq.webclient.1683143341233", "0A<m8*b9.tK&B5xXqHSh")
                    .WithTls()
                    .WithCleanSession()
                    .Build();

                var a = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
               
                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    var a = System.Text.Encoding.Default.GetString(e.ApplicationMessage.Payload);
                    EmotionalResultPostDTO postDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<EmotionalResultPostDTO>(a);

                    try
                    {
                        ResultPost(postDTO);
                    }
                    catch
                    {
                        return Task.CompletedTask;
                    }
                    Console.WriteLine($"{postDTO.Start} to {postDTO.End} - emotional {postDTO.Emotional} from device {postDTO.PersonId}");
                    return Task.CompletedTask;
                };
                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic("emotional");
                        })
                    .Build();

                var b = await mqttClient.SubscribeAsync(mqttSubscribeOptions);

                Console.WriteLine("Add emotional start.");
                Console.ReadLine();
                Console.WriteLine("Add emotional stop.");
            }
           

            return Ok(true);
        }

        [Authorize]
        [HttpGet]
        [Route("getEmotional/{id}")]
        public async Task<ActionResult<EmotionalGetDTO>> EmotionalGet(int id)
        {
           
            EmotionalGetDTO res = await Eservice.GetEmotionals(id);
            var user = CurrentUser.Get(HttpContext);
            if (user.Role != "admin" && user.ProfileId != res.ProfileId)
            {
                return NotFound();
            }
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("Result/post")]
        public async Task<ActionResult<EmotionalRDGetDTO>> ResultPost(EmotionalResultPostDTO postDTO)
        {
            EmotionalRDGetDTO res = await Eservice.PostEmotionalResult(postDTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Route("Expect/post")]
        public async Task<ActionResult<EmotionalEDGetDTO>> ExpectPost(EmotionalExpectPostDTO postDTO)
        {
            EmotionalEDGetDTO res = await Eservice.PostEmotionalExpect(postDTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
