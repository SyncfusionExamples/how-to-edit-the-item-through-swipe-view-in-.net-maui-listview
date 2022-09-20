using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMauiSwiping
{
    public class ListViewSwipingViewModel
    {
        #region Fields

        private ObservableCollection<ListViewInboxInfo> inboxInfo;

        private SfListView ListView;

        #endregion

        #region Constructor

        public ListViewSwipingViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties


        public ObservableCollection<ListViewInboxInfo> InboxInfo
        {
            get { return inboxInfo; }
            set { this.inboxInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            swipeStartingCommand = new Command<Syncfusion.Maui.ListView.SwipeStartingEventArgs>(OnSwipeStarted);
            swipeEndedCommand = new Command<Syncfusion.Maui.ListView.SwipeEndedEventArgs>(OnSwipeEnded);
            loadedCommand = new Command<SfListView>(OnListViewLoaded);

            ListViewInboxInfoRepository inboxinfo = new ListViewInboxInfoRepository();
            inboxInfo = inboxinfo.GetInboxInfo();
        }

        private void OnSwipeStarted(SwipeStartingEventArgs obj)
        {
            itemIndex = -1;
        }


        #endregion

        #region Command

        #region Fields

        int itemIndex = -1;
        Command<SfListView> loadedCommand;
        Command<Syncfusion.Maui.ListView.SwipeStartingEventArgs> swipeStartingCommand;
        Command<Syncfusion.Maui.ListView.SwipeEndedEventArgs> swipeEndedCommand;

        #endregion

        #region Properties

        public Command<SwipeStartingEventArgs> SwipeStartingCommand
        {
            get { return swipeStartingCommand; }
            protected set { swipeStartingCommand = value; }
        }

        public Command<Syncfusion.Maui.ListView.SwipeEndedEventArgs> SwipeEndedCommand
        {
            get { return swipeEndedCommand; }
            protected set { swipeEndedCommand = value; }
        }

        public Command<SfListView> LoadedCommand
        {
            get { return loadedCommand; }
            protected set { loadedCommand = value; }
        }


        #endregion

        #region Methods

        public void OnListViewLoaded(SfListView listView)
        {
            ListView = listView;
        }

        public void OnSwipeEnded(Syncfusion.Maui.ListView.SwipeEndedEventArgs eventArgs)
        {
            itemIndex = eventArgs.Index;
        }

        #endregion

        #endregion
    }
}
