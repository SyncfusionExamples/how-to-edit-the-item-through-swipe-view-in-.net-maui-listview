# how-to-edit-the-item-through-swipe-view-in-.net-maui-listview

This example demonstrates how to edit the item through swiping in .Net Maui ListView

## XAML 
<Grid x:Name="mainGrid">
    <Grid.RowDefinitions>
        <RowDefinition Height="40" />
        <RowDefinition Height="*" />
    </Grid.RowDefinitions>
    <Label Grid.Row="0"
            Text="Inbox"
            FontSize="18"
            FontFamily="Roboto-Medium"
            Margin="16,0,0,0"
            VerticalOptions="Center" />
    <ListView:SfListView Grid.Row="1"
                            x:Name="listView"
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
            ---
        </ListView:SfListView.ItemTemplate>
    </ListView:SfListView>
</Grid>

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.