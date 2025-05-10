using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eWarranty.Views.Customer.DashBoardView
{
  
    public partial class EWMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public EWMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new EWMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class EWMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<EWMasterDetailPageMenuItem> MenuItems { get; set; }

            public EWMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<EWMasterDetailPageMenuItem>(new[]
                {
                    new EWMasterDetailPageMenuItem { Id = 0, Title = "Page 1",  },
                    new EWMasterDetailPageMenuItem { Id = 1, Title = "Page 2" },
                    new EWMasterDetailPageMenuItem { Id = 2, Title = "Page 3" },
                    new EWMasterDetailPageMenuItem { Id = 3, Title = "Page 4" },
                    new EWMasterDetailPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
