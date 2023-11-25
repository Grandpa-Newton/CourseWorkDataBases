using Lab05New.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab05New.ViewModels
{
    public class EditTestViewModel
    {
        public EditTestViewModel() { }
        public EditTestViewModel(List<Difficulty> difficulties, List<Topic> topics, int difficulty, int topic)
        {
            Difficulties = new SelectList(difficulties, "DifficultyId", "Name", difficulty);
            SelectedDifficultyId = difficulty;
            SelectedTopicId = topic;
            Topics = new SelectList(topics, "TopicId", "Name", topic);
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SelectedDifficultyId { get; set; }

        public int SelectedTopicId { get; set; }

      /*  [DisplayName("Сложность")]
        public SelectList Difficulties { get; set; }

        [DisplayName("Тематика")]
        public SelectList Topics { get; set; }*/

        public IEnumerable<SelectListItem>? Difficulties { get; set; }

        public IEnumerable<SelectListItem>? Topics { get; set; }

        [Required, MinLength(1, ErrorMessage = "Необходимо добавить хотя бы один вопрос")]
        [ValidateEachString]
        public List<string> QuestionNames { get; set; } = new();

        [ValidateEachString]
        public List<string> QuestionTexts { get; set; } = new();

        [ValidateEachString]
        public List<string> AnswerTexts { get; set; } = new();

        [ValidateNumberOfQuestions]
        public List<int> QuestionNumberOfPoints { get; set; } = new();
    }
}
