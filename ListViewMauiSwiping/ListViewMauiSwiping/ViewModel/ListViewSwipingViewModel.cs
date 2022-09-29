using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMauiSwiping
{
    public class ListViewSwipingViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ListViewInboxInfo>? inboxInfo;
        private Command? favoritesImageCommand;

        #endregion


        #region Interface Member

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region EventHandler
        public event EventHandler<ResetEventArgs>? ResetSwipeView;

        protected virtual void OnResetSwipe(ResetEventArgs e)
        {
            EventHandler<ResetEventArgs>? handler = ResetSwipeView;
            handler?.Invoke(this, e);
        }

        #endregion

        #region Constructor

        public ListViewSwipingViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewInboxInfo>? InboxInfo
        {
            get { return inboxInfo; }
            set { this.inboxInfo = value; OnPropertyChanged("InboxInfo"); }
        }

        public Command? FavoritesImageCommand
        {
            get { return favoritesImageCommand; }
            protected set { favoritesImageCommand = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ListViewInboxInfoRepository inboxinfo = new ListViewInboxInfoRepository();
            inboxInfo = inboxinfo.GetInboxInfo();
            favoritesImageCommand = new Command(SetFavorites);;
        }

        private void SetFavorites(object item)
        {
            var listViewItem = item as ListViewInboxInfo;
            if ((bool)listViewItem!.IsFavorite)
            {
                listViewItem.IsFavorite = false;
            }
            else
            {
                listViewItem.IsFavorite = true;
            }
            OnResetSwipe(new ResetEventArgs());
        }

        #endregion

        #region ResetEvent
        public class ResetEventArgs : EventArgs
        {

        }
        #endregion
    }
}
