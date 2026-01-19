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
    // Direct dependency on the Model
    private Models.User _user;

    public MainWindow()
    {
        InitializeComponent();
        
        // Initialize a sample user
        _user = new Models.User 
        { 
            Name = "John Doe", 
            Age = 30, 
            Email = "john@example.com" 
        };
    }

    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        // Manually copying data from Model to View
        txtName.Text = _user.Name;
        txtAge.Text = _user.Age.ToString();
        txtEmail.Text = _user.Email;
        
        lblStatus.Text = "Status: Data loaded from Model.";
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try 
        {
            // Manually copying data from View to Model
            _user.Name = txtName.Text;
            _user.Age = int.Parse(txtAge.Text);
            _user.Email = txtEmail.Text;

            lblStatus.Text = $"Status: Data saved to Model. New state: {_user.Name}, {_user.Age}, {_user.Email}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving data: {ex.Message}");
        }
    }
}