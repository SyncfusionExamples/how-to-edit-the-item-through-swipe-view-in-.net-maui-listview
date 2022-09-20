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

        private string title;
        private string subject;
        private string desc;
        private string date;
        private ImageSource image;
        private ImageSource favImage;
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

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Subject
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

        public string Description
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

        public string Date
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

        public ImageSource InboxImage
        {
            get { return this.image; }
            set
            {
                this.image = value;
                OnPropertyChanged("InboxImage");
            }
        }

        public ImageSource FavoriteImage
        {
            get { return this.favImage; }
            set
            {
                this.favImage = value;
                OnPropertyChanged("FavoriteImage");
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

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

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
