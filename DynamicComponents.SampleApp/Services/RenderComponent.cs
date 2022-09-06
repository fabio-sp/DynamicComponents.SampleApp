namespace DynamicComponents.SampleApp.Services
{
    public class RenderComponent
    {
        public Type Type { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
    }
}
