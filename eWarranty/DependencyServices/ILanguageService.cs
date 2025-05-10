using System;
using System.Globalization;

namespace eWarranty.DependencyServices
{
    public interface ILanguageService
    {
        void SetLanguage(string lang);

        void SetApplicationLanguage(CultureInfo ci);
    }
}
