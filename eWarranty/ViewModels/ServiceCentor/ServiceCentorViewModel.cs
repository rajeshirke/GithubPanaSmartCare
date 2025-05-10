using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.SRDetails;
using eWarranty.Views.ServiceCentorView;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.ViewModels.ServiceCentor
{
    public class ServiceCentorViewModel: BaseViewModel
    {
        public ServiceCentorViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await DataBinding();
                IsBusy = false;
            });

            RefreshCommand = new Command(() => OnRefresh());
        }

        private async void OnRefresh()
        {
            IsBusy = true;
            await DataBinding();
            IsRefreshing = false;
            IsBusy = false;
        }

        public Command RefreshCommand { get; set; }

        public async Task DataBinding()
        {
            //try
            //{
            //    var ChkgpsStatus = DependencyService.Get<ILocSettings>().isGpsAvailable();
            //    if (!ChkgpsStatus)
            //    {
            //        await ErrorDisplayAlert("Your gps location is not accurate");
            //    }
            //    else
            //    {
            //        CommonAttribute.UserLocation = await Extensions.GetGeolocation();

            //        if (ServiceCentors == null)
            //            ServiceCentors = new ObservableCollection<ServiceCenter>();

            //        if (MasterServiceCentors == null)
            //            MasterServiceCentors = new ObservableCollection<ServiceCenter>();
            //        if (CommonAttribute.UserLocation != null)
            //        {
            //            ServiceCentersManagementSL serviceCentersManagementSL = new ServiceCentersManagementSL();

            //            List<ServiceCenter> respServiceCenter = await serviceCentersManagementSL.GetServiceCentersNearestToLocation(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);

            //            if (respServiceCenter != null)
            //            {
            //                Location sourceCoordinates = new Location(CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);

            //                foreach (var item in respServiceCenter)
            //                {
            //                    Location destinationCoordinates = new Location(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude));

            //                    double distance = Location.CalculateDistance(sourceCoordinates, destinationCoordinates, DistanceUnits.Kilometers);
            //                    item.Distnace = Math.Round(distance, 2);
            //                    MasterServiceCentors.Add(item);
            //                }
            //            }
            //            ServiceCentors = MasterServiceCentors;
            //            // FilterServiceCenter(50);
            //        }
            //        else
            //        {
            //            if (Device.RuntimePlatform == Device.Android)
            //            {
            //                bool gpsStatus = DependencyService.Get<ILocSettings>().isGpsAvailable();
            //                //if(!gpsStatus)
            //                //    await ErrorDisplayAlert(AppResources.lblErrorGPS);
            //            }

            //        }
            //    }

            //    // AddServicesRequestPage

            //}
            //catch (Exception ex)
            //{
            //    IsBusy = false;
            //}

            try
            {
                //var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
                //var status1 = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (Device.RuntimePlatform == Device.Android)
                {
                    var ChkgpsStatus = DependencyService.Get<ILocSettings>().isGpsAvailable();
                    if (!ChkgpsStatus)
                    {
                        await ErrorDisplayAlert("Your gps location is not accurate");
                    }
                    else
                    {
                        if (ChkgpsStatus)
                        {
                            CommonAttribute.UserLocation = await Extensions.GetGeolocation();

                            if (ServiceCentors == null)
                                ServiceCentors = new ObservableCollection<ServiceCenter>();

                            if (MasterServiceCentors == null)
                                MasterServiceCentors = new ObservableCollection<ServiceCenter>();
                            if (CommonAttribute.UserLocation != null)
                            {
                                ServiceCentersManagementSL serviceCentersManagementSL = new ServiceCentersManagementSL();

                                List<ServiceCenter> respServiceCenter = await serviceCentersManagementSL.GetServiceCentersByProductAndNearestLocation(CommonAttribute.CustomeProfile.CountryId, Convert.ToInt32(CommonAttribute.SRInputModel.ProductModelWarrantyResponse.ProductClassificationID), CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);

                                if (respServiceCenter != null)
                                {
                                    Location sourceCoordinates = new Location(CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);

                                    foreach (var item in respServiceCenter)
                                    {
                                        Location destinationCoordinates = new Location(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude));

                                        double distance = Location.CalculateDistance(sourceCoordinates, destinationCoordinates, DistanceUnits.Kilometers);
                                        item.Distnace = Math.Round(distance, 2);
                                        MasterServiceCentors.Add(item);
                                    }
                                }
                                ServiceCentors = MasterServiceCentors;
                                FilterServiceCenter(50);
                            }
                            else
                            {
                                if (Device.RuntimePlatform == Device.Android)
                                {
                                    bool gpsStatus = DependencyService.Get<ILocSettings>().isGpsAvailable();
                                    //if (!gpsStatus)
                                    //    await ErrorDisplayAlert(AppResources.lblErrorGPS);
                                }
                            }
                        }
                    }
                }
                else
                {
                    CommonAttribute.UserLocation = await Extensions.GetGeolocation();

                    if (ServiceCentors == null)
                        ServiceCentors = new ObservableCollection<ServiceCenter>();

                    if (MasterServiceCentors == null)
                        MasterServiceCentors = new ObservableCollection<ServiceCenter>();
                    if (CommonAttribute.UserLocation != null)
                    {
                        ServiceCentersManagementSL serviceCentersManagementSL = new ServiceCentersManagementSL();

                        List<ServiceCenter> respServiceCenter = await serviceCentersManagementSL.GetServiceCentersByProductAndNearestLocation(CommonAttribute.CustomeProfile.CountryId, Convert.ToInt32(CommonAttribute.SRInputModel.ProductModelWarrantyResponse.ProductClassificationID), CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);

                        if (respServiceCenter != null)
                        {
                            Location sourceCoordinates = new Location(CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);

                            foreach (var item in respServiceCenter)
                            {
                                Location destinationCoordinates = new Location(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude));

                                double distance = Location.CalculateDistance(sourceCoordinates, destinationCoordinates, DistanceUnits.Kilometers);
                                item.Distnace = Math.Round(distance, 2);
                                MasterServiceCentors.Add(item);
                            }
                        }
                        ServiceCentors = MasterServiceCentors;
                        FilterServiceCenter(50);
                    }
                }
                // AddServicesRequestPage
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }

        }
        public void SearchServiceCenter(string skey)
        {
            try
            {
                if (!string.IsNullOrEmpty(skey))
                {
                    var items = MasterServiceCentors.Where(u => (u.CityName != null && u.CityName.ToLower().Contains(skey.ToLower())) || (u.StreetAddress != null && u.StreetAddress.ToLower().Contains(skey.ToLower())) || (u.Name != null && u.Name.ToLower().Contains(skey.ToLower())));
                    ServiceCentors = new ObservableCollection<ServiceCenter>(items);
                }
                else
                    ServiceCentors = MasterServiceCentors;
            }
            catch (Exception ex)
            {

            }
            
        }
        public void FilterServiceCenter(int km)
        {
            try
            {
                if (km == 0 && !string.IsNullOrEmpty(Skey))
                {
                    var items = MasterServiceCentors.Where(u => (u.CityName != null && u.CityName.ToLower().Contains(Skey.ToLower())));
                    ServiceCentors = new ObservableCollection<ServiceCenter>(items);
                }
                else if (km != 0 && string.IsNullOrEmpty(Skey))
                {
                    var items = MasterServiceCentors.Where(u => (u.Distnace <km));
                    ServiceCentors = new ObservableCollection<ServiceCenter>(items);
                }
                else if (km != 0 && !string.IsNullOrEmpty(Skey))
                {
                    var items = MasterServiceCentors.Where(u => (u.CityName != null && u.CityName.ToLower().Contains(Skey.ToLower())) || (u.Landmark != null && u.Distnace < km));
                    ServiceCentors = new ObservableCollection<ServiceCenter>(items);
                }
                else
                    ServiceCentors = MasterServiceCentors;
            }
            catch(Exception ex)
            {
                ServiceCentors = MasterServiceCentors;
            }
        }
        #region events
        //AddProductPage
        public Command SelectedServiceCentorCommand
        {
            get
            {
                return new Command<ServiceCenter>((obj) =>
                {
                    CommonAttribute.CustomerSelectedServiceCenter = obj;
                    Navigation.PushAsync(new ServiceLocationPage());
                });
            }
        }
        public Command AddServicesRequestCommand
        {
            get
            {
                return new Command<ServiceCenter>((item) =>
                {
                    SelectedServiceCentor = item;
                    SelectedServiceCentor.SelectedItem = true;
                  
                    CommonAttribute.SRInputModel.ServiceCenter = item;
                    Navigation.PushAsync(new AddServicesRequestPage());
                });
            }
        }
        public Command CallServiceCentorCommand
        {
            get
            {
                return new Command<ServiceCenter>(async (obj) =>
                {
                    try
                    {
                        if (obj.ContactNumber1 != null && obj.ContactNumber1 != string.Empty && obj.ContactNumber1 != "")
                        {
                            Extensions.PlacePhoneCall(obj.ContactNumber1);
                        }
                        else if (obj.ContactNumber2 != null && obj.ContactNumber2 != string.Empty && obj.ContactNumber2 != "")
                        {
                            Extensions.PlacePhoneCall(obj.ContactNumber2);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }
        #endregion
        #region Properties

        private bool _IsRefreshing;
        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set
            {
                _IsRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        //  public List<ServiceCentorModel> ServiceCentors { get; set; }
        private ObservableCollection<ServiceCenter> _ServiceCentors;
        public ObservableCollection<ServiceCenter> ServiceCentors
        {
            get { return _ServiceCentors; }
            set
            {
                _ServiceCentors = value;
                OnPropertyChanged(nameof(ServiceCentors));
            }
        }
        private ObservableCollection<ServiceCenter> _MasterServiceCentors;
        public ObservableCollection<ServiceCenter> MasterServiceCentors
        {
            get { return _MasterServiceCentors; }
            set
            {
                _MasterServiceCentors = value;
                OnPropertyChanged("MasterServiceCentors");
            }
        }

        private ServiceCentorModel _ServiceCentor;
        public ServiceCentorModel ServiceCentor
        {
            get { return _ServiceCentor; }
            set
            {
                _ServiceCentor = value;
                OnPropertyChanged(nameof(ServiceCentor));
            }
        }
        private ServiceCenter _SelectedServiceCentor;
        public ServiceCenter SelectedServiceCentor
        {
            get { return _SelectedServiceCentor; }
            set
            {
                _SelectedServiceCentor = value;
                OnPropertyChanged("SelectedServiceCentor");
            }
        }
        private string _Skey;
        public string Skey
        {
            get { return _Skey; }
            set
            {
                _Skey = value;
                OnPropertyChanged("Skey");
            }
        }
        #endregion
    }
}
