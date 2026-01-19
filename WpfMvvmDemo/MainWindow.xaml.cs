using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMvvmDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ViewModels.MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        
        // Initialize ViewModel and set DataContext
        _viewModel = new ViewModels.MainViewModel();
        this.DataContext = _viewModel;
    }

    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        // Demonstrating that changing the ViewModel automatically updates the View
        // No need to touch txtName.Text etc. anymore!
        
        _viewModel.Name = "Converted to MVVM";
        _viewModel.Age = 99;
        _viewModel.Email = "mvvm@rocks.com";
        
        lblStatus.Text = "Status: ViewModel properties updated from Code-Behind. View should reflect changes automatically.";
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        // Demonstrating that the View automatically updated the ViewModel
        // We just read the ViewModel properties.
        
        lblStatus.Text = $"Status: Read from ViewModel: {_viewModel.Name}, {_viewModel.Age}, {_viewModel.Email}";
    }
}