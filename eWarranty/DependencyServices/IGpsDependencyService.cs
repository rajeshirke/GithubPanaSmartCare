using System;
namespace eWarranty.DependencyServices
{
    public interface IGpsDependencyService
    {
        bool IsGpsTurnedOn();
        void OpenSettings();
    }
}
