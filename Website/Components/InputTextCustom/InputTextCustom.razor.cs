# nullable enable

using Microsoft.AspNetCore.Components;

namespace Website.Components.InputTextCustom
{
    partial class InputTextCustom : ComponentBase
    {
        [Parameter] public string? Placeholder { get; set; }
    }
}