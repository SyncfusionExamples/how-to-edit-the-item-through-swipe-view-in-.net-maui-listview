using ListViewMauiSwiping.SwipeEditPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMauiSwiping
{
    public class ListViewInboxInfo : INotifyPropertyChanged
    {
        #region Fields

        private string? profileName;
        private string? subject;
        private string? desc;
        private string? date;
        private string? image;
        private bool? isAttached;
        private bool isOpened;
        private bool isFavorite = true;
        public Command<object> EditCommand { get; set; }

        #endregion

        #region Constructor

        public ListViewInboxInfo()
        {
            EditCommand = new Command<object>(OnSwipeEdit);
        }

        #endregion

        #region Properties

        public string? ProfileName
        {
            get { return profileName; }
            set
            {
                profileName = value;
                OnPropertyChanged("ProfileName");
            }
        }

        public string? Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
                OnPropertyChanged("Subject");
            }
        }

        public string? Description
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
                OnPropertyChanged("Description");
            }
        }

        public string? Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public string? Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public bool? IsAttached
        {
            get { return isAttached; }
            set
            {
                isAttached = value;
                OnPropertyChanged("IsAttached");
            }
        }

        public bool IsFavorite
        {
            get { return isFavorite; }
            set
            {
                isFavorite = value;
                OnPropertyChanged("IsFavorite");
            }
        }

        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                OnPropertyChanged("IsOpened");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Private Methods

        private void OnSwipeEdit(object obj)
        {
            var popupPage = new EditPage();
            popupPage.BindingContext = (obj as Grid).BindingContext;
            App.Current.MainPage.Navigation.PushAsync(popupPage);

        }
        #endregion
    }
}
