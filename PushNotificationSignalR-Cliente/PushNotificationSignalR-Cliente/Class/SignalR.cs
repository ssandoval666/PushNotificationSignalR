using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PushNotificationSignalRCliente.Class
{
    class SignalR
    {


        private string url = "https://localhost:44333/notificationhub";
        private HubConnection _connection = null;
        private IJSRuntime JSRuntime { get; set; }

        private SignalR() { }

        private static SignalR _instance;

        public static SignalR GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SignalR();
            }
            return _instance;
        }

        public async Task<HubConnection> GetConnection()
        {
            if (_connection == null)
            {
               await ConnectToServerAsync();
            }

            return _connection;
        }

        private async Task ConnectToServerAsync()
        {
            
            if (_connection == null)
            {
                _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

                await _connection.StartAsync();

                _connection.Closed += async (s) =>
                {
                    await _connection.StartAsync();
                };
                
                /*
                _connection.On<string>("notification", async m =>
                {
                    await JSRuntime.InvokeVoidAsync("notification", m);
                });
                */

            }
        }
    }
}
