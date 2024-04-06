using Microsoft.JSInterop;

namespace BlazorShop.Helper;

public static class IJSRuntimeExtension
{
    public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
    {
        await jsRuntime.InvokeVoidAsync("showToastr", "success", message);
    }

    public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
    {
        await jsRuntime.InvokeVoidAsync("showToastr", "error", message);
    }
}