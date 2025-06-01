using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuickEdit_Wpf_MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace QuickEdit_Wpf_MVVM.ViewModels
{
    public partial class ManageUsersViewModel : ObservableObject
    {
        #region InsertForm

        [ObservableProperty]
        private string name = string.Empty;


        [ObservableProperty]
        private int age = 30;

        #endregion InsertForm

        #region Grid

        public ObservableCollection<UserModel> users = new ObservableCollection<UserModel>();

        #endregion Grid

        #region Commands

        public RelayCommand AddUserCommand { get; }
        public RelayCommand RemoveUserCommand { get; }
        #endregion Commands

        public ManageUsersViewModel()
        {
            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
        }

        private void RemoveUser()
        {
            MessageBox.Show("Remove");
        }

        private void AddUser()
        {
            MessageBox.Show("Add");
        }
    }

}
