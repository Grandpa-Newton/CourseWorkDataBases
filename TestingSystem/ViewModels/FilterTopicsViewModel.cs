using TestingSystem.Models;

namespace TestingSystem.ViewModels
{
    public class FilterTopicsViewModel
    {
        public FilterTopicsViewModel(string name)
        {
            SelectedName = name;
        }

        public string SelectedName { get; }
    }
}
