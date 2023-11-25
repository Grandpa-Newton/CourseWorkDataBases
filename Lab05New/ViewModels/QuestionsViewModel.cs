using Lab05New.Models;

namespace Lab05New.ViewModels
{
    public class QuestionsViewModel
    {
        public Question Question { get; }
        public PageViewModel PageViewModel { get; }

        public QuestionsViewModel(Question question, PageViewModel pageViewModel)
        {
            Question = question;
            PageViewModel = pageViewModel;
        }
    }
}
