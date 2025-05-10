using System;
namespace eWarranty.DependencyServices
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
        void DismissAlert();
    }
}
