using DynamicComponents.SampleApp.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DynamicComponents.SampleApp.Services
{
    public class ComponentService
    {
        private readonly IJSRuntime iJSRuntime;

        public ComponentService(IJSRuntime iJSRuntime)
        {
            this.iJSRuntime = iJSRuntime;
        }

        public Dictionary<string, RenderComponent> GetRenderComponents()
        {
            return new Dictionary<string, RenderComponent>()
            {
                {"Posta ordinaria", new RenderComponent() { Type = typeof(AddressComponent) } },

                {"Fax", new RenderComponent() {
                    Type = typeof(FaxComponent)
                    , Parameters = new(){
                        { "CountryCode" , "+39"} ,
                        { "OnExportButtonClick", EventCallback.Factory.Create<string>(this, OnExportClick) }
                    }
                }}
            };
        }

        private async Task OnExportClick(string faxNumberValue)
        {
            await iJSRuntime.InvokeVoidAsync("alert", faxNumberValue);
        }
    }
}
