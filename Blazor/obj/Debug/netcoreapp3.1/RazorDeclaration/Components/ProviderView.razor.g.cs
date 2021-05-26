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
#line 1 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProviderView.razor"
using BLL.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProviderView.razor"
using DAL.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProviderView.razor"
using BLL.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProviderView.razor"
using Blazor.Models;

#line default
#line hidden
#nullable disable
    public partial class ProviderView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 88 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\ProviderView.razor"
       
    public Product product = new Product();
    public Provider provider = new Provider();
    public Dictionary<Provider, List<Product>> table = new Dictionary<Provider, List<Product>>();
    protected async override Task OnInitializedAsync()
    {
        var providers = await provider_services.GetProviders();
        foreach(var p in providers)
        {
            table.Add(p, await provider_services.GetProducts(new ProviderDTO { Id = p.Id }));
        }
    }
    private async Task ProductSubmit(EditContext editContext)
    {
        await product_services.AddProduct(new ProductDTO {
            Name = product.Name,
            Price = product.Price,
            ProviderId = product.ProviderId
        });
        uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
    }
    private async Task ProviderSubmit(EditContext editContext)
    {
        await provider_services.AddProvider(new ProviderDTO
        {
            Name = provider.Name,
            Address = provider.Address
        });
        uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProductsServices product_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProvidersServices provider_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHelper { get; set; }
    }
}
#pragma warning restore 1591
