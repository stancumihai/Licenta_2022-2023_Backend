using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Interfaces;
using Library.Models.Socket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Services.Controllers
{
    public class WebSocketTestController : ApiControllerBase
    {

        private readonly IHubContext<NotificationHub, INotificationHub> hubContext;

        public WebSocketTestController(IHubContext<NotificationHub, INotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string message)
        {
            await hubContext.Clients.All.ReceiveNotification( message);
            return Ok();
        }
    }
}