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
#line 1 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\DriverView.razor"
using BLL.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\DriverView.razor"
using DAL.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\DriverView.razor"
using BLL.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\DriverView.razor"
using Blazor.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\DriverView.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\DriverView.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
    public partial class DriverView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 112 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\DriverView.razor"
       
    public int currentPage = 1;
    public int wId = 1;
    public int amount = 1;
    public string search = "";

    public DriverModel driver = new DriverModel();
    public IEnumerable<DAL.Entities.Driver> drivers = new List<DAL.Entities.Driver>();

    protected async override Task OnInitializedAsync()
    {
        string aId = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "aId");
        Warehouse warehouse = await Http.GetFromJsonAsync<Warehouse>($"https://localhost:44374/api/Warehouses/{aId}");
        wId = (int)warehouse.Id;
        drivers = await Http.GetFromJsonAsync<IEnumerable<Driver>>($"https://localhost:44374/api/Drivers/{wId}/{currentPage}");
        amount = await driver_services.Amount(wId);
    }
    private async Task FormSubmit(EditContext editContext)
    {
        driver.WarehouseId = 1;
        driver.EmploymentDate = DateTime.Now;
        DriverDTO newDriver = new DriverDTO
        {
            Name = driver.Name,
            Surname = driver.Surname,
            EmploymentDate = driver.EmploymentDate,
            Hours = driver.Hours,
            Wage = driver.Wage,
            Rating = driver.Rating,
            WarehouseId = driver.WarehouseId
        };
        await Http.PostAsJsonAsync("https://localhost:44374/api/Drivers/add", newDriver);
        currentPage = amount + 1;
        drivers = await Http.GetFromJsonAsync<IEnumerable<Driver>>($"https://localhost:44374/api/Drivers/{wId}/{currentPage}");
        StateHasChanged();
    }
    private async Task DeleteDriver(int id)
    {
        await Http.DeleteAsync($"https://localhost:44374/api/Drivers/{id}/delete");
        drivers = await Http.GetFromJsonAsync<IEnumerable<Driver>>($"https://localhost:44374/api/Drivers/{wId}/{currentPage}");
        StateHasChanged();
    }
    public async Task Next()
    {
        currentPage++;
        if (currentPage > amount + 1)
        {
            currentPage = amount + 1;
        }
        drivers = await Http.GetFromJsonAsync<IEnumerable<Driver>>($"https://localhost:44374/api/Drivers/{wId}/{currentPage}");
        StateHasChanged();
    }
    public async Task Prev()
    {
        currentPage--;
        if (currentPage < 1)
        {
            currentPage = 1;
        }
        drivers = await Http.GetFromJsonAsync<IEnumerable<Driver>>($"https://localhost:44374/api/Drivers/{wId}/{currentPage}");
        StateHasChanged();
    }
    public void Sort(char command)
    {
        switch (command)
        {
            case 'a':
                {
                    drivers = drivers.OrderBy(d => d.Name);
                    break;
                }
            case 'd':
                {
                    drivers = drivers.OrderByDescending(d => d.Name);
                    break;
                }
            case 'c':
                {
                    drivers = drivers.OrderBy(d => d.Id);
                    break;
                }
            default:
                {
                    drivers = drivers.OrderBy(d => d.Id);
                    break;
                }
        }
        StateHasChanged();
    }
    public async Task Search()
    {
        if (search == "")
        {
            drivers = await Http.GetFromJsonAsync<IEnumerable<Driver>>($"https://localhost:44374/api/Drivers/{wId}/{currentPage}");
        }
        else
        {
            drivers = await Http.GetFromJsonAsync<IEnumerable<Driver>>($"https://localhost:44374/api/Drivers/{wId}/0");
            drivers = drivers.Where(s => s.Name.Contains(search));
        }
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWarehousesServices warehouse_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDriversServices driver_services { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
