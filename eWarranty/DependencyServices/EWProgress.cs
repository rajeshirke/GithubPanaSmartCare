using System;
namespace eWarranty.DependencyServices
{
    public interface IEWProgress
    {
        void Show();
        void Show(string message);
        void Dismiss();
    }
}
