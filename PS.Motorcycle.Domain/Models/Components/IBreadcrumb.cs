namespace PS.Motorcycle.Domain.Models.Components
{
    public interface IBreadcrumb
    {
        string Text { get; set; }
        string Url { get; set; }
    }
}