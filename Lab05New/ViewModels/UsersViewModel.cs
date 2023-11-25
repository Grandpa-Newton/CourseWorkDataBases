using Lab05New.Models;

namespace Lab05New.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; }

        public PageViewModel PageViewModel { get; }

        public FilterUserViewModel FilterUserViewModel { get; }

        public UsersViewModel(IEnumerable<ApplicationUser> users, PageViewModel pageViewModel, FilterUserViewModel filterUserViewModel)
        {
            Users = users;
            PageViewModel = pageViewModel;
            FilterUserViewModel = filterUserViewModel;
        }
    }
}
