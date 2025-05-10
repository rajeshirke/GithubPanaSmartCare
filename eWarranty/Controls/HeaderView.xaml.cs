using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace eWarranty.Controls
{
    public partial class HeaderView : ContentView
    {
        public HeaderView()
        {
            InitializeComponent();
            // LabelTitle.BindingContext = this;
            LabelTitle.BindingContext = this;
            imgRigth.BindingContext = this;
            btnMenu.BindingContext = this;
        }
        public static BindableProperty TitleProperty =
           BindableProperty.Create(nameof(Title), typeof(string), typeof(TitledEntryView), null, BindingMode.TwoWay);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static BindableProperty RightImageSourceProperty =
           BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(TitledEntryWithIcon), null, BindingMode.TwoWay);

        public string RightImageSource
        {
            get => (string)GetValue(RightImageSourceProperty);
            set => SetValue(RightImageSourceProperty, value);
        }
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
       "Command",
       typeof(ICommand),
       typeof(TitledEntryWithIcon),
       null,
       propertyChanged: (bindable, oldValue, newValue) =>
       {
           // do something.                
       });

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(TitledEntryWithIcon), null);

        public event EventHandler<EventArgs> Tapped;

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Command?.Execute(null);
        }

        #region BackCommand
        public static readonly BindableProperty BackCommandProperty = BindableProperty.Create(
       "Command",
       typeof(ICommand),
       typeof(TitledEntryWithIcon),
       null,
       propertyChanged: (bindable, oldValue, newValue) =>
       {
           // do something.                
       });

        public static readonly BindableProperty BackCommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(TitledEntryWithIcon), null);

        public event EventHandler<EventArgs> BackTapped;

        public ICommand BackCommand
        {
            get { return (ICommand)GetValue(BackCommandProperty); }
            set { SetValue(BackCommandProperty, value); }
        }

        public object BackCommandParameter
        {
            get { return GetValue(BackCommandParameterProperty); }
            set { SetValue(BackCommandParameterProperty, value); }
        }

        void BackTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            BackCommand?.Execute(null);
        }
        #endregion
    }
}
