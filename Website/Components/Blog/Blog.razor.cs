# nullable enable

using Microsoft.AspNetCore.Components;

namespace Website.Components.Blog
{
    partial class Blog : ComponentBase
    {
        [Parameter] public string? Title { get; set; }
        [Parameter] public string? Content { get; set; }
    }
}