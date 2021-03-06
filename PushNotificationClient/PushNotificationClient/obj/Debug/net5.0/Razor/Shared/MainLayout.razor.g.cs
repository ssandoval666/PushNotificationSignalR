#pragma checksum "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7872e4c1590f55c0f942d2e509f1ed487c4d930d"
// <auto-generated/>
#pragma warning disable 1591
namespace PushNotificationClient.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using PushNotificationClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\_Imports.razor"
using PushNotificationClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\Shared\MainLayout.razor"
using PushNotificationClient.Class;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\Shared\MainLayout.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-28u177ephz");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-28u177ephz");
            __builder.OpenComponent<PushNotificationClient.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-28u177ephz");
            __builder.AddMarkupContent(11, "<div class=\"top-row px-4\" b-28u177ephz><a href=\"http://blazor.net\" target=\"_blank\" class=\"ml-md-auto\" b-28u177ephz>About</a></div>\r\n\r\n        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "content px-4");
            __builder.AddAttribute(14, "b-28u177ephz");
            __builder.AddContent(15, 
#nullable restore
#line 20 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 26 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationClient\PushNotificationClient\Shared\MainLayout.razor"
 
    string url = "https://localhost:44333/notificationhub";
    HubConnection _connection = null;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);


        var IsOnLine = await localStorage.GetItemAsync<bool>("ConnectionStatus");

        if (IsOnLine)
        {
            await GetToken();
        }


        if (firstRender)
            await RequestNotificationSubscriptionAsync();

    }

    private async Task RequestNotificationSubscriptionAsync()
    {
        var subscription = await JSRuntime.InvokeAsync<bool>("subscribe");
        
        if (subscription)
        {

            _connection = new HubConnectionBuilder()
            .WithUrl(url)
            .Build();

            await _connection.StartAsync();

            _connection.Closed += async (s) =>
            {
                await _connection.StartAsync();
            };

            _connection.On<string>("notification", async m =>
            {
                await JSRuntime.InvokeVoidAsync("notification", m);
                StateHasChanged();
            });

        }
    }

   
    public async Task GetToken()
    {
        var JWToken = await localStorage.GetItemAsync<string>("JWT");
        JWToken = null;

        if (JWToken == null)
        {
            UserInfo oUser = new UserInfo();

            oUser.Email = "sss@dd.com";
            oUser.Password = "eeee";

            //Http.DefaultRequestHeaders.Add("x-api-version", "1.0");
            var response = await Http.PostAsJsonAsync("api/v1/Token/Token", oUser);
            var message = response.Content.ReadAsStringAsync();

            await localStorage.SetItemAsync("JWT", message.Result);
        }

    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
