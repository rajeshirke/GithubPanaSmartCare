using System;
namespace eWarranty.DependencyServices
{
    public interface ILocSettings
    {
        void OpenSettings();
        bool isGpsAvailable();
    }
}
