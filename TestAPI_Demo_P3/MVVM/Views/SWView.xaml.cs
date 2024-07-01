using TestAPI_Demo_P3.MVVM.ViewModels;

namespace TestAPI_Demo_P3.MVVM.Views;

public partial class SWView : ContentPage
{
    private readonly SWViewModel _viewModel;
    public SWView(SWViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}