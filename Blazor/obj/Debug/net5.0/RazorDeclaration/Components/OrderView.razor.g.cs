// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Blazor.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
using BLL.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
using DAL.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
using BLL.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
using Blazor.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
    public partial class OrderView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 84 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\OrderView.razor"
       
    public int currentPage = 1;
    public int wId = 1;
    public int amount = 1;
    public string search = "";

    public Order order = new Order();
    public List<OrderViewModel> orderview = new List<OrderViewModel>();
    protected async override Task OnInitializedAsync()
    {
        string aId = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "aId");
        Warehouse warehouse = await Http.GetFromJsonAsync<Warehouse>($"https://localhost:44374/api/Warehouses/{aId}");
        wId = (int)warehouse.Id;
        await UpdateOrders();
        amount = await order_services.Amount(wId);
    }
    private async Task UpdateOrders()
    {
        orderview = new List<OrderViewModel>();
        var orders = await Http.GetFromJsonAsync<IEnumerable<Order>>($"https://localhost:44374/api/Orders/{wId}/{currentPage}");
        foreach (var o in orders)
        {
            var product = await Http.GetFromJsonAsync<Product>($"https://localhost:44374/api/Products/{o.ProductId}/info");
            var client = await Http.GetFromJsonAsync<Client>($"https://localhost:44374/api/Clients/{o.ClientId}/info");
            orderview.Add(new OrderViewModel
            {
                Id = o.Id,
                ClientId = o.ClientId,
                ProductId = o.ProductId,
                ProductAmount = o.ProductAmount,
                WarehouseId = o.WarehouseId,
                Cost = o.Cost,
                ProductName = product.Name,
                ClientName = client.Name,
                ClientAddress = client.Address
            });
        }
        StateHasChanged();
    }
    public async Task Next()
    {
        currentPage++;
        if (currentPage > amount + 1)
        {
            currentPage = amount + 1;
        }
        await UpdateOrders();
    }
    public async Task Prev()
    {
        currentPage--;
        if (currentPage < 1)
        {
            currentPage = 1;
        }
        await UpdateOrders();
    }
    public void Sort(char command)
    {
        switch (command)
        {
            case 'a':
                {
                    orderview = orderview.OrderBy(d => d.ProductName).ToList();
                    break;
                }
            case 'd':
                {
                    orderview = orderview.OrderByDescending(d => d.ProductName).ToList();
                    break;
                }
            case 'c':
                {
                    orderview = orderview.OrderBy(d => d.Id).ToList();
                    break;
                }
            default:
                {
                    orderview = orderview.OrderBy(d => d.Id).ToList();
                    break;
                }
        }
        StateHasChanged();
    }
    public async Task Search()
    {
        if (search == "")
        {
            await UpdateOrders();
        }
        else
        {
            await UpdateOrders();
            orderview = orderview.Where(s => s.ProductName.Contains(search)).ToList();
        }
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStockServices stock_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWarehousesServices warehouse_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClientsServices client_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProductsServices product_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrdersServices order_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591