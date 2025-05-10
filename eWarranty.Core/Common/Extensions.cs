using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace eWarranty.Core.Common
{
    public static class Extensions
    {
        //public static string GetEnumDescription(Enum value)
        //{
        //    var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        //    var descriptionAttribute =
        //        enumMember == null
        //            ? default(DescriptionAttribute)
        //            : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
        //    return
        //        descriptionAttribute == null
        //            ? value.ToString()
        //            : descriptionAttribute.Description;
        //}

        //public static string GetDisplayName(this Enum enumValue)
        //{

        //    string displayName = enumValue.GetType()?
        //                    .GetMember(enumValue.ToString())?
        //                    .First()?
        //                    .GetCustomAttribute<DisplayAttribute>()?
        //                    .Name;

        //    return string.IsNullOrEmpty(displayName) ? enumValue.ToString() : displayName;
        //}

        public static string GenerateProductRegistrationNumber(string text)
        {
            return "Ref-" + text;
        }

        //public static bool IsBase64String(string base64)
        //{
        //    Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        //    return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        //}

        //public static string GetEnumDisplayName(Enum value)
        //{
        //    var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        //    var descriptionAttribute =
        //        enumMember == null
        //            ? default(DisplayNameAttribute)
        //            : enumMember.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
        //    return
        //        descriptionAttribute == null
        //            ? value.ToString()
        //            : descriptionAttribute.DisplayName;
        //}
    }
}
