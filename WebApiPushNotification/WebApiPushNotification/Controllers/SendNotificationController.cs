using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using PushSharp.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPushNotification.Class;
using WebPush;

namespace JWTWebApi.Controllers
{
    ///<Summary>
    /// Controlador para el Envio de mensajes
    ///</Summary>
    ///

    [Authorize]
    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Notification/[controller]")]
    public class SendNotificationController : ControllerBase
    {
        ///<Summary>
        /// CParametros de configuracion
        ///</Summary>
        ///
        public IConfiguration _configuration;
        private readonly WebPushNotificationConfig webPushNotification = new WebPushNotificationConfig();

        ///<Summary>
        /// Controlador para el Envio de mensajes
        ///</Summary>
        ///
        public SendNotificationController(IConfiguration config)
        {
            _configuration = config;
        }

        /// <summary>  
        /// Envio de Notificaciones Requiere JWT  
        /// </summary>  
        [HttpPost]
        public async Task<IActionResult> SendNotification(NotificationMessageText oMessage)
        {

            var directory = Environment.CurrentDirectory;
            string fileName = "\\Data\\JsonSubs.json";
            directory += fileName;
            if (System.IO.File.Exists(directory))
            {
                var sss = System.IO.File.ReadAllText(directory);

                List<NotificationSubscription> oTemp = System.Text.Json.JsonSerializer.Deserialize<List<NotificationSubscription>>(sss);
                List<NotificationSubscription> oErrors = new List<NotificationSubscription>();


                foreach (NotificationSubscription oSubscripcion in oTemp)
                {
                    try
                    {

                        //Configuration FCM(use this section for FCM)
                        //var config = new GcmConfiguration("AAAAWEKiNdk:APA91bH-xlH2rAX_gZ6-ED5XMgIE-u7y3Dlzt0WU6ApkvLTGlxAnbWN0hVcxvjGRMM4TR2yeQt4lA6rXEyetk3S6lRuLBwFu0zSfphc8N4aHSKbq0FYN7cPs6YXyB_9sDCuVHl2MsKpB");
                        var config = new GcmConfiguration("RpTcanCLvTDHaau0ua3cXbCsjLeZFRcW6uTMom5WXp4");
                        config.GcmUrl = "https://fcm.googleapis.com/fcm/send";
                        var provider = "FCM";

                        var gcmBroker = new GcmServiceBroker(config);


                        gcmBroker.OnNotificationFailed += (notification, aggregateEx) =>
                        {

                            aggregateEx.Handle(ex =>
                            {

                                throw ex;
                            });
                        };

                        gcmBroker.OnNotificationSucceeded += (notification) =>
                        {
                            Console.WriteLine("{provider} Notification Sent!");
                        };

                        // Start the broker
                        gcmBroker.Start();

                        
                            // Queue a notification to send
                            gcmBroker.QueueNotification(new GcmNotification
                            {
                                RegistrationIds = new List<string> { oSubscripcion.Url.Split("https://fcm.googleapis.com/fcm/send/")[1] },
                                Data = JObject.Parse("{ \"somekey\" : \"somevalue\" }")
                            });
                        

                        // Stop the broker, wait for it to finish   
                        // This isn't done after every message, but after you're
                        // done with the broker
                        gcmBroker.Stop();






                        var webPushClient = new WebPushClient();
                        var pushSubscription = new PushSubscription(oSubscripcion.Url, oSubscripcion.P256dh, oSubscripcion.Auth);
                        var payload = System.Text.Json.JsonSerializer.Serialize(oMessage);

                        var gcmAPIKey = "BF5Xcx-8JEwwKifXRl5aGHzO41CaIgTzMizA1vldNdU8Y4ZEfl0SuqXrSwvv5rtHAvTRCkxZG7Jj_Gn0G3HK_hY";

                        await webPushClient.SendNotificationAsync(pushSubscription, payload, gcmAPIKey);
                    }
                    catch (Exception ex)
                    {
                        oErrors.Add(oSubscripcion);
                        throw ex;
                    }

                }
            }



            return Ok();
        }
    }
}
