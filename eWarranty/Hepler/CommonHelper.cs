using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.Hepler
{
    public static class Extensions
    {
        public static List<LanguageModel> Getlanguages()
        {

            List<LanguageModel> languages = new List<LanguageModel>();

            languages.Add(new LanguageModel() { LongName = "English", LongCode = "en", lid = 1 });
            languages.Add(new LanguageModel() { LongName = "عربى", LongCode = "ur", lid = 2 });
            //  languages.Add(new LanguageModel() { LongName = "हिंदी", LongCode = "hi", lid = 3 });

            return languages;
        }
        public static string ConvertToBase64(this Stream stream)
        {
            var bytes = new Byte[(int)stream.Length];

            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, (int)stream.Length);

            return Convert.ToBase64String(bytes);
        }

        public static bool CheckNetwrokAvailability()
        {
            bool networkAvailable = false;
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                networkAvailable = true;
            }

            return networkAvailable;
        }


        public static async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            try
            {
                int _downloadImageTimeoutInSeconds = 15;
                HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(_downloadImageTimeoutInSeconds) };

                using (var httpResponse = await _httpClient.GetAsync(imageUrl))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return await httpResponse.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        //Url is Invalid
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                //Handle Exception
                return null;
            }
        }
        public static async Task<byte[]> DownloadImagePostAsync(string imageUrl)
        {
            try
            {
                int _downloadImageTimeoutInSeconds = 15;
                HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(_downloadImageTimeoutInSeconds) };

                using (var httpResponse = await _httpClient.PostAsync(imageUrl,null))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return await httpResponse.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        //Url is Invalid
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                //Handle Exception
                return null;
            }
        }
        public static async Task<string> QrScanning()
        {
            try
            {
                string stringData = string.Empty;
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    stringData = result;
                }
                return stringData;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public static bool EmailValidation(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        //GetPlace
        public static async Task<UserCurrentLocation> GetGeoAddress(double Latitude, double Longitude)
        {
            try
            {


                UserCurrentLocation userCurrent = new UserCurrentLocation();
                userCurrent.Latitude = Latitude;
                userCurrent.Longitude = Longitude;
                var placemarks = await Geocoding.GetPlacemarksAsync(Latitude, Longitude);
                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    userCurrent.Area = placemark.AdminArea;
                    userCurrent.SubArea = placemark.SubAdminArea;
                    userCurrent.CountryName = placemark.CountryName;
                    userCurrent.CountryCode = placemark.CountryCode;
                    userCurrent.Locality = placemark.Locality;
                    userCurrent.Area = placemark.SubLocality;
                    userCurrent.PostalCode = placemark.PostalCode;

                }
                return userCurrent;
                //  Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                return null;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                return null;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                return null;
            }
            catch (Exception ex)
            {
                // Unable to get location
                return null;
            }
            return null;
        }
        public static async Task<UserCurrentLocation> GetGeolocation()
        {
            try
            {


                UserCurrentLocation userCurrent = new UserCurrentLocation();
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                //location.
                if (location != null)
                {
                    userCurrent.Latitude = location.Latitude;
                    userCurrent.Longitude = location.Longitude;
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark != null) {
                        userCurrent.Area = placemark.AdminArea;
                        userCurrent.SubArea = placemark.SubAdminArea;
                        userCurrent.CountryName = placemark.CountryName;
                        userCurrent.CountryCode = placemark.CountryCode;
                        userCurrent.Locality = placemark.Locality;
                        userCurrent.Area = placemark.SubLocality;
                        userCurrent.PostalCode = placemark.PostalCode;

                    }
                    return userCurrent;
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
               
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                return null;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                return null;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                return null;
            }
            catch (Exception ex)
            {
                //	ex	{Java.IO.IOException: grpc failed   at Java.Interop.JniEnvironment+InstanceMethods.CallObjectMethod (Java.Interop.JniObjectReference instance, Java.Interop.JniMethodInfo method, Java.Interop.JniArgumentValue* args) [0x0006e] in <8b3b636835d84984ba4604c1f57b1983…}
                await App.Current.MainPage.DisplayAlert("Error", "GPS location finding failed. Please enable GPS.", "OK");
                return null;
            }
            return null;
        }

        public static void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        public static bool ValidDate(DateTime dateTime)
        {
            DateTime temp;
            if (DateTime.TryParse(dateTime.ToString(), out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<List<string>> GetDataAsync(string key)
        {
            List<string> dataSource = new List<string>();
            
            //string[] cars = { "Volvo", "BMW", "Ford", "Mazda", "1Volvo", "BMW", "Ford", "Mazda", "2Volvo", "BMW", "Ford", "Mazda" };
            //dataSource = cars.ToList();
            //return string.IsNullOrWhiteSpace(key) ? null : cars.Where(s => s.StartsWith(key, StringComparison.InvariantCultureIgnoreCase)).ToList();
           
            MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
            List<ModelNumberSearchResponse> modelNumberSearchResponses = await dataManagementSL.SearchModelNumberByInitials(key, 0);
            if (modelNumberSearchResponses != null && modelNumberSearchResponses.Count > 0)
            {
                foreach(var item in modelNumberSearchResponses)
                {
                    dataSource.Add(item.ModelName);
                }              
            }
            string[] ModelNos = dataSource.ToArray();
            return string.IsNullOrWhiteSpace(key) ? null : ModelNos.Where(s => s.StartsWith(key, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

    }
}
