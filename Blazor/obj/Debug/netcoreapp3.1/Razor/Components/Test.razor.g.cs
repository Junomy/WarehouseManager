#pragma checksum "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\Test.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "beb78a252e39b64d51040b9001d89650b2849cc9"
// <auto-generated/>
#pragma warning disable 1591
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
#line 1 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\Test.razor"
using Blazor.Models;

#line default
#line hidden
#nullable disable
    public partial class Test : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Test Rezor</h1>\r\n");
            __builder.OpenElement(1, "table");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<tr>\r\n        <th>Id</th>\r\n        <th>Name</th>\r\n    </tr>\r\n");
#nullable restore
#line 8 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\Test.razor"
     for(int i = 0; i < models.Count; i++)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "        ");
            __builder.OpenElement(5, "tr");
            __builder.AddMarkupContent(6, "\r\n            ");
            __builder.OpenElement(7, "td");
            __builder.AddContent(8, 
#nullable restore
#line 11 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\Test.razor"
                 i

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.OpenElement(10, "td");
            __builder.AddContent(11, 
#nullable restore
#line 12 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\Test.razor"
                 models[i]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
#nullable restore
#line 14 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\Test.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "C:\Users\Junomy\source\repos\WarehouseManagement\Blazor\Components\Test.razor"
       
    public static List<string> NewModels()
    {
        List<string> list = new List<string>();
        list.Add("One");
        list.Add("Two");
        list.Add("Three");
        list.Add("Four");
        list.Add("Five");
        return list;
    }
    public List<string> models = NewModels();

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
