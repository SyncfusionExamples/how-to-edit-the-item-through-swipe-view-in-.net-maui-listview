namespace ListViewMauiSwiping.SwipeEditPage;

public partial class EditPage : ContentPage
{
    #region Fields
    public string TitleText;
    public string DescriptionText;
    public string SubjectText;
    public string DateText;
    #endregion

    #region Constructor
    public EditPage()
	{
		InitializeComponent();
        this.BindingContextChanged += SfPopUpView_BindingContextChanged;
    }
    #endregion
    private void SfPopUpView_BindingContextChanged(object sender, EventArgs e)
    {
        TitleText = titleeditor.Text;
        DescriptionText = desceditor.Text;
        SubjectText = subeditor.Text;
        DateText = dateeditor.Text;
    }

    private void savebtn_clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void cancelbtn_clicked(object sender, EventArgs e)
    {
        titleeditor.Text = TitleText;
        desceditor.Text = DescriptionText;
        subeditor.Text = SubjectText;
        dateeditor.Text = DateText;
        Navigation.PopAsync();
    }

}