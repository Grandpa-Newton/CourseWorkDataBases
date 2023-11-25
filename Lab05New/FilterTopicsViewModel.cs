using Lab05New.Models;

namespace Lab05New
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
