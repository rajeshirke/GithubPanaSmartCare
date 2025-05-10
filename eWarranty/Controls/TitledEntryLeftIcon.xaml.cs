using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eWarranty.Controls
{
    public partial class TitledEntryLeftIcon : ContentView
    {
        string placeholder = string.Empty;

        public enum KeyboardEnum
        {
            Default,
            Text,
            Chat,
            Url,
            Email,
            Telephone,
            Numeric,
        }

        public TitledEntryLeftIcon()
        {
            InitializeComponent();

            EntryContent.BindingContext = this;
            LabelTitle.BindingContext = this;
            imgicon.BindingContext = this;
            if (string.IsNullOrEmpty(LabelTitle.Text))
            {
                LabelTitle.IsVisible = false;
            }
            //LabelTitle.Text = string.Empty;
            

        }

        public static BindableProperty TitleProperty =
           BindableProperty.Create(nameof(Title), typeof(string), typeof(TitledEntryWithIcon), null, BindingMode.TwoWay);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(TitledEntryWithIcon), null, BindingMode.TwoWay);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(string), typeof(TitledEntryWithIcon), "#cccccc", BindingMode.TwoWay);

        public string PlaceholderColor
        {
            get { return (string)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(int), typeof(TitledEntryWithIcon), 16, BindingMode.TwoWay);

        public int FontSize
        {
            get => (int)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(TitledEntryWithIcon), string.Empty, BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static BindableProperty IsTextPasswordProperty =
           BindableProperty.Create(nameof(IsTextPassword), typeof(bool), typeof(TitledEntryWithIcon), false, BindingMode.TwoWay);

        public bool IsTextPassword
        {
            get { return (bool)GetValue(IsTextPasswordProperty); }
            set { SetValue(IsTextPasswordProperty, value); }
        }

        public static BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(KeyboardProperty), typeof(KeyboardEnum), typeof(TitledEntryWithIcon), KeyboardEnum.Default, BindingMode.TwoWay);

        public KeyboardEnum EntryKeyboard
        {
            get => (KeyboardEnum)GetValue(KeyboardProperty);
            set
            {
                SetValue(KeyboardProperty, value);
                SetKeyboard();
            }
        }
        //IsPassword
        void Handle_ContainerFocused(object sender, FocusEventArgs e)
        {
            EntryContent.Focus();
        }

        void Handle_Focused(object sender, FocusEventArgs e)
        {
            LabelTitle.Text = Placeholder;
            LabelTitle.IsVisible = true;

            if (EntryContent.Text == null || EntryContent.Text.Length == 0)
            {
                placeholder = EntryContent.Placeholder;
                EntryContent.Placeholder = string.Empty;
            }

        }

        void Handle_Unfocused(object sender, FocusEventArgs e)
        {
            if (EntryContent.Text == null || EntryContent.Text.Length == 0)
            {
                EntryContent.Placeholder = placeholder;
                LabelTitle.IsVisible = false;
            }
            else
            {
                LabelTitle.IsVisible = true;
                LabelTitle.Text = Placeholder;
            }

        }

        void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                LabelTitle.Text = Placeholder;
            }
        }


        void SetKeyboard()
        {
            switch (EntryKeyboard)
            {
                case KeyboardEnum.Default:
                    EntryContent.Keyboard = Keyboard.Default;
                    break;
                case KeyboardEnum.Text:
                    EntryContent.Keyboard = Keyboard.Text;
                    break;
                case KeyboardEnum.Chat:
                    EntryContent.Keyboard = Keyboard.Chat;
                    break;
                case KeyboardEnum.Url:
                    EntryContent.Keyboard = Keyboard.Url;
                    break;
                case KeyboardEnum.Email:
                    EntryContent.Keyboard = Keyboard.Email;
                    break;
                case KeyboardEnum.Telephone:
                    EntryContent.Keyboard = Keyboard.Telephone;
                    break;
                case KeyboardEnum.Numeric:
                    EntryContent.Keyboard = Keyboard.Numeric;
                    break;
                default:
                    EntryContent.Keyboard = Keyboard.Default;
                    break;
            }
        }

        public static BindableProperty ImageSourceProperty =
           BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(TitledEntryWithIcon), null, BindingMode.TwoWay);

        public string ImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
        public static BindableProperty textAlignmentProperty =
          BindableProperty.Create(nameof(textAlignment), typeof(TextAlignment), typeof(TitledEntryWithIcon), null, BindingMode.TwoWay);

        public TextAlignment textAlignment
        {
            get => (TextAlignment)GetValue(textAlignmentProperty);
            set => SetValue(textAlignmentProperty, value);
        }

        public static BindableProperty flowDirectionProperty =
          BindableProperty.Create(nameof(textAlignment), typeof(FlowDirection), typeof(TitledEntryWithIcon), null, BindingMode.TwoWay);

        public FlowDirection flowDirection
        {
            get => (FlowDirection)GetValue(flowDirectionProperty);
            set => SetValue(flowDirectionProperty, value);
        }

        //TextAlignment
    }
}
