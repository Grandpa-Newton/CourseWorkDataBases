using Lab05New.Models;

namespace Lab05New.ViewModels
{
    public class ResultsViewModel
    {
        public IEnumerable<Test> Tests { get; }

        public PageViewModel PageViewModel { get; }

        public FilterResultsViewModel FilterResultsViewModel { get; }

        public IEnumerable<ApplicationUser> Users { get; }

        public IEnumerable<Result> Results { get; }

        public ResultsViewModel(PageViewModel pageViewModel, FilterResultsViewModel filterResultsViewModel, IEnumerable<ApplicationUser> users, IEnumerable<Result> results)
        {
            PageViewModel = pageViewModel;
            FilterResultsViewModel = filterResultsViewModel;
            Users = users;
            Results = results;
        }
    }
}
