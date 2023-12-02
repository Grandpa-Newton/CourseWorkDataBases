using TestingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestingSystem.ViewModels
{
    public class FilterResultsViewModel
    {
        public FilterResultsViewModel(List<ApplicationUser> users, List<Test> tests, string user, int test)
        {
            Users = new SelectList(users, "Id", "UserName", user);
            Tests = new SelectList(tests, "TestId", "Name", test);
            SelectedUser = user;
            SelectedTest = test;
        }

        public SelectList Users { get; }

        public SelectList Tests { get; }

        public string SelectedUser { get; }

        public int SelectedTest { get; }
    }
}
