using System;
using System.ComponentModel;

namespace eWarranty.Models
{
    public class Message : INotifyPropertyChanged
    {
        string text;

        public string Text
        {
            get { return text; }
            set {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        DateTime messageDateTime;

        public DateTime MessageDateTime
        {
            get { return messageDateTime; }
            set {
                messageDateTime = value;
                OnPropertyChanged("MessageDateTime");
            }
        }

        public string MessageTimeDisplay => MessageDateTime.ToShortDateString();

        bool isIncoming;

        public bool IsIncoming
        {
            get { return isIncoming; }
            set {
                isIncoming = value;
                OnPropertyChanged("IsIncoming");
            }
        }

        public bool HasAttachement => !string.IsNullOrEmpty(attachementUrl);

        string attachementUrl;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string AttachementUrl
        {
            get { return attachementUrl; }
            set {
                attachementUrl = value;
                OnPropertyChanged("AttachementUrl");
            }
        }

    }
}