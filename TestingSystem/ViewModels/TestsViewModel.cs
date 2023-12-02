using TestingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestingSystem.ViewModels
{
    public class TestsViewModel
    {
        public IEnumerable<Test> Tests { get; }
        public PageViewModel PageViewModel { get; }

        public FilterTestsViewModel FilterTestsViewModel { get; }

        public IEnumerable<CompletionMark> CompletionMarks { get; }

        public IEnumerable<Result> Results { get; }

        public ApplicationUser ApplicationUser { get; }
        public TestsViewModel(IEnumerable<Test> tests, PageViewModel viewModel, FilterTestsViewModel filterTestsViewModel, IEnumerable<CompletionMark> completionMarks, IEnumerable<Result> results, ApplicationUser applicationUser)
        {
            Tests = tests;
            PageViewModel = viewModel;
            FilterTestsViewModel = filterTestsViewModel;
            CompletionMarks = completionMarks;
            Results = results;
            ApplicationUser = applicationUser;
        }
    }
}
