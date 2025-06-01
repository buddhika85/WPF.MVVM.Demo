using QuickEdit_Wpf_MVVM.ViewModels;
using System.Windows;

namespace QuickEdit_Wpf_MVVM.Views
{
    /// <summary>
    /// Interaction logic for ManageUsersView.xaml
    /// </summary>
    public partial class ManageUsersView : Window
    {
        public ManageUsersView()
        {
            InitializeComponent();
            DataContext = new ManageUsersViewModel();
        }
    }
}
