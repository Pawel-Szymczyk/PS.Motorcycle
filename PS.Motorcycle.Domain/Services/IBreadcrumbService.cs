using PS.Motorcycle.Domain.Models.Components;

namespace PS.Motorcycle.Domain.Services
{
    public interface IBreadcrumbService
    {
        List<IBreadcrumb> GetBreadcrumb(IBreadcrumb breadcrumb);

    }
}