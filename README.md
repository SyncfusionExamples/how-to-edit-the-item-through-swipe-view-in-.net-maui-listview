# How to edit the item through swiping in .NET MAUI ListView (SfListView)?
This example demonstrates how to edit the item through swiping in .NET MAUI ListView (SfListView).

## Sample

```xaml
<ListView:SfListView x:Name="listView"
                    ItemsSource="{Binding InboxInfo}"
                    AllowSwiping="True"
                    SwipeThreshold="50"
                    SwipeOffset="100"
                    SelectionMode="Multiple"
                    SelectionGesture="LongPress"
                    ScrollBarVisibility="Always"
                    AutoFitMode="Height">
    <ListView:SfListView.EndSwipeTemplate>
        <DataTemplate x:Name="EndSwipeTemplate">
            <Grid x:Name="SwipeGrid"
                    BackgroundColor="#DC595F"
                    HorizontalOptions="Fill"
                    VerticalOptions="Fill">
                <Label Grid.Row="0"
                        HorizontalTextAlignment="Center"
                        VerticalTextAlignment="Center"
                        BackgroundColor="Transparent"
                        Text="EditItem" />
                <Grid.GestureRecognizers>
                    <TapGestureRecognizer Command="{Binding Path=BindingContext.EditCommand,Source={x:Reference SwipeGrid}}"
                                            CommandParameter="{x:Reference SwipeGrid}" />
                </Grid.GestureRecognizers>
            </Grid>
        </DataTemplate>
    </ListView:SfListView.EndSwipeTemplate>
    <ListView:SfListView.ItemTemplate>
        <DataTemplate>
            <code>
            . . .
            . . .
            <code>
        </DataTemplate>
    </ListView:SfListView.ItemTemplate>
</ListView:SfListView>

C#:

(bindable.BindingContext as ListViewSwipingViewModel).ResetSwipeView += ListViewSwipingBehavior_ResetSwipeView;
ListView.ItemTapped += ListView_ItemTapped;

private void ListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
{
    (e.DataItem as ListViewInboxInfo).IsOpened = true;
}

private void ListViewSwipingBehavior_ResetSwipeView(object sender, ResetEventArgs e)
{
    ListView!.ResetSwipeItem();
}

ViewModel.cs:

private Command? favoritesImageCommand;

public event EventHandler<ResetEventArgs>? ResetSwipeView;

protected virtual void OnResetSwipe(ResetEventArgs e)
{
    EventHandler<ResetEventArgs>? handler = ResetSwipeView;
    handler?.Invoke(this, e);
}

favoritesImageCommand = new Command(SetFavorites);;

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
```
