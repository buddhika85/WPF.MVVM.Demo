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
        private int id = 1;

        [ObservableProperty]
        private string name = "Jack";


        [ObservableProperty]
        private int age = 30;

        [ObservableProperty]
        public string message = string.Empty;

        #endregion InsertForm

        #region Grid

        public ObservableCollection<UserModel> users { get; }

        [ObservableProperty]
        private UserModel? selectedUser = null;

        #endregion Grid

        #region Commands

        public RelayCommand SaveUserCommand { get; }
        public RelayCommand DeleteUserCommand { get; }
        public RelayCommand EditUserCommand { get; }
        #endregion Commands

        public ManageUsersViewModel()
        {
            users = [];
            SaveUserCommand = new RelayCommand(SaveUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
            EditUserCommand = new RelayCommand(EditUser);
        }

        private void DeleteUser()
        {
            //MessageBox.Show($"Remove {SelectedUser}");
            if (SelectedUser != null)
                users.Remove(SelectedUser);
        }

        private void EditUser()
        {
            //MessageBox.Show($"Edit {SelectedUser}");
            if (SelectedUser != null)
            {
                Id = SelectedUser.Id;
                Name = SelectedUser.Name;
                Age = SelectedUser.Age;
            }

        }

        private void SaveUser()
        {
            Message = string.Empty;
            var error = Validate();

            if (!string.IsNullOrEmpty(error))
            {
                Message = error;                
                return;
            }

            if (SelectedUser == null)
            {
                users.Add(new UserModel { Id = Id, Name = Name, Age = Age });       // add mode
            }
            else
            {                
                SelectedUser.Name = Name;                                           // edit mode
                SelectedUser.Age = Age;
            }

            ResetForm();
        }

        private void ResetForm()
        {
            SelectedUser = null;
            Name = string.Empty;
            var lastUser = users.LastOrDefault();
            Id = lastUser == null ? 1 : lastUser.Id + 1;
        }

        private string Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return "Error - name cannnot be empty";
            }

            if (SelectedUser == null && FindUser() != null)
            {
                return $"Error - User with ID {Id} already exists. So, cannot Add.";
            }
            
            return string.Empty;
        }

        private UserModel? FindUser()
        {
            return users.SingleOrDefault(x => x.Id == Id);
        }
    }
}
