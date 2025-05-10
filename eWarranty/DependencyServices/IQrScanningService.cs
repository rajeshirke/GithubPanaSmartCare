using System;
using System.Threading.Tasks;

namespace eWarranty.DependencyServices
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
