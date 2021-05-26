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
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
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
#line 1 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProductView.razor"
using BLL.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProductView.razor"
using DAL.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProductView.razor"
using BLL.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProductView.razor"
using Blazor.Models;

#line default
#line hidden
#nullable disable
    public partial class ProductView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 59 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProductView.razor"
       
    public Stock newstock = new Stock();
    public List<StockViewModel> stockview = new List<StockViewModel>();
    public IEnumerable<Product> products = new List<Product>();
    protected async override Task OnInitializedAsync()
    {
        products = await product_services.GetProducts();
        var stocks = await stock_services.GetByWarehouse(1);
        foreach (var s in stocks)
        {
            Provider provider = await provider_services.GetProvider(new ProviderDTO { Id = products.Where(p => p.Id == s.ProductId).FirstOrDefault().ProviderId });
            stockview.Add(new StockViewModel
            {
                ProductId = s.ProductId,
                WarehouseId = s.WarehouseId,
                Name = products.Where(p => p.Id == s.ProductId).FirstOrDefault().Name,
                BuyPrice = products.Where(p => p.Id == s.ProductId).FirstOrDefault().Price,
                SellPrice = s.SellPrice,
                Amount = s.Amount,
                ProviderId = provider.Id,
                ProviderName = provider.Name,
                ProviderAddress = provider.Address
            });
        }
    }
    private async Task FormSubmit(EditContext editContext)
    {
        newstock.WarehouseId = 1;
        await warehouse_services.AddProduct(new StockDTO
        {
            ProductId = newstock.ProductId,
            WarehouseId = newstock.WarehouseId,
            Amount = newstock.Amount,
            SellPrice = newstock.SellPrice
        });
        uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProvidersServices provider_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStockServices stock_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWarehousesServices warehouse_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProductsServices product_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHelper { get; set; }
    }
}
#pragma warning restore 1591