using Lab05New.Models;

namespace Lab05New.ViewModels
{
    public class TopicsViewModel
    {
        public IEnumerable<Topic> Topics { get; }

        public PageViewModel PageViewModel { get; }

        public FilterTopicsViewModel FilterTopicsViewModel { get; }

        public TopicsViewModel(IEnumerable<Topic> topics, PageViewModel pageViewModel, FilterTopicsViewModel filterTopicsViewModel)
        {
            Topics = topics;
            PageViewModel = pageViewModel;
            FilterTopicsViewModel = filterTopicsViewModel;
        }
    }
}
