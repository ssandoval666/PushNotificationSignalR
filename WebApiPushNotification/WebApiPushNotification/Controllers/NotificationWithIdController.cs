using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPushNotification.Class;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Authorization;
using WebApiPushNotification;
using Microsoft.AspNetCore.SignalR;

namespace JWTWebApi.Controllers
{
    ///<Summary>
    /// Controlador para el Manejo de la subscripcion
    ///</Summary>
    ///
    [Authorize]
    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Notification/[controller]")]
    public class NotificationWithIdController : ControllerBase
    {


        ///<Summary>
        /// Parametro de Configuracion
        ///</Summary>
        ///
        private readonly IHubContext<NotificationHub> _hubContext;

        ///<Summary>
        /// Controlador para el Manejo de la subscripcion
        ///</Summary>
        ///

        public NotificationWithIdController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        /// <summary>  
        /// Envio de Mensajes con SignalR  
        /// </summary>
        [HttpPost]
        [MapToApiVersion("1.0")]
#pragma warning disable 1998
        public async Task<IActionResult> NotificationWithId(NotificationMessageText oMessage)
        {
            var payload = System.Text.Json.JsonSerializer.Serialize(oMessage);
            await _hubContext.Clients.Client(oMessage.ConnectionID).SendAsync("notification", payload);
            //await _hubContext.Clients.All.SendAsync("notification", payload);
            return Ok("Notification has been sent successfully!");
        }
    }
}
