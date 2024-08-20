using FinanceTracker.Models;
using FinanceTracker.ViewModels;
using FinanceTracker.Views;
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

namespace FinanceTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User SelectedUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            StartScreen startScreen = new StartScreen();
            MainContentControl.Content = startScreen;
        }

        public void NavigateToHome()
        {
            Home home = new Home();
            //WE get the selected user from the UserCardViewModel, which comes from the home.xaml and pass it to the HomeViewModel
            home.DataContext = new HomeViewModel(SelectedUser);
            MainContentControl.Content = home;
        }
    }
}