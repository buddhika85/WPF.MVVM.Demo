using CommunityToolkit.Mvvm.ComponentModel;

namespace QuickEdit_Wpf_MVVM.Models
{
    public partial class UserModel : ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string? name;

        [ObservableProperty]
        public int age;

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
