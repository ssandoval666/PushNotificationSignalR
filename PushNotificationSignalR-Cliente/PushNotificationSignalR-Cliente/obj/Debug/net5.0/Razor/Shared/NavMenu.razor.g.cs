#pragma checksum "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20ba0318fa4df37f671578bc503be294846c4d46"
// <auto-generated/>
#pragma warning disable 1591
namespace PushNotificationSignalRCliente.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using PushNotificationSignalRCliente;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\_Imports.razor"
using PushNotificationSignalRCliente.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-u2yu54t2qt");
            __builder.OpenElement(3, "a");
            __builder.AddAttribute(4, "class", "navbar-brand");
            __builder.AddAttribute(5, "href");
            __builder.AddAttribute(6, "b-u2yu54t2qt");
            __builder.AddMarkupContent(7, "\r\n        Cliente\r\n        ");
            __builder.OpenComponent<PushNotificationSignalRCliente.Shared.Connection>(8);
            __builder.AddAttribute(9, "Online", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(10, "<h1 class=\"navbar-brand\" style=\"color: green\" b-u2yu54t2qt>Online</h1>");
            }
            ));
            __builder.AddAttribute(11, "Offline", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(12, "<h1 class=\"navbar-brand\" style=\"color: red\" b-u2yu54t2qt>Offline</h1>");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(13, "\r\n        <br b-u2yu54t2qt>");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n    \r\n    ");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "class", "navbar-toggler");
            __builder.AddAttribute(17, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "b-u2yu54t2qt");
            __builder.AddMarkupContent(19, "<span class=\"navbar-toggler-icon\" b-u2yu54t2qt></span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n\r\n");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", 
#nullable restore
#line 20 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "b-u2yu54t2qt");
            __builder.OpenElement(25, "ul");
            __builder.AddAttribute(26, "class", "nav flex-column");
            __builder.AddAttribute(27, "b-u2yu54t2qt");
            __builder.OpenElement(28, "li");
            __builder.AddAttribute(29, "class", "nav-item px-3");
            __builder.AddAttribute(30, "b-u2yu54t2qt");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(31);
            __builder.AddAttribute(32, "class", "nav-link");
            __builder.AddAttribute(33, "href", "");
            __builder.AddAttribute(34, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 23 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\Shared\NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(35, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(36, "<span class=\"oi oi-home\" aria-hidden=\"true\" b-u2yu54t2qt></span> Home\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n        ");
            __builder.OpenElement(38, "li");
            __builder.AddAttribute(39, "class", "nav-item px-3");
            __builder.AddAttribute(40, "b-u2yu54t2qt");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(41);
            __builder.AddAttribute(42, "class", "nav-link");
            __builder.AddAttribute(43, "href", "counter");
            __builder.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(45, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-u2yu54t2qt></span> Counter\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n        ");
            __builder.OpenElement(47, "li");
            __builder.AddAttribute(48, "class", "nav-item px-3");
            __builder.AddAttribute(49, "b-u2yu54t2qt");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(50);
            __builder.AddAttribute(51, "class", "nav-link");
            __builder.AddAttribute(52, "href", "fetchdata");
            __builder.AddAttribute(53, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(54, "<span class=\"oi oi-list-rich\" aria-hidden=\"true\" b-u2yu54t2qt></span> Fetch data\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "C:\Users\Sebastian Sandoval\Documents\GitHub\PushNotificationSignalR\PushNotificationSignalR-Cliente\PushNotificationSignalR-Cliente\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591