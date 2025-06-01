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

        [ObservableProperty]
        public string message;

        #endregion InsertForm

        #region Grid

        public ObservableCollection<UserModel> users { get; }

        #endregion Grid

        #region Commands

        public RelayCommand SaveUserCommand { get; }
        public RelayCommand RemoveUserCommand { get; }
        #endregion Commands

        public ManageUsersViewModel()
        {
            users = new ObservableCollection<UserModel>();
            SaveUserCommand = new RelayCommand(SaveUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
        }

        private void RemoveUser()
        {
            MessageBox.Show("Remove");
        }

        private void SaveUser()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                users.Add(new UserModel { Name = Name, Age = Age });
        }
    }

}
