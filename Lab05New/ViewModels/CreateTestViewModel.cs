using Lab05New.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab05New.ViewModels
{
    public class CreateTestViewModel
    {
        public CreateTestViewModel() { }
        public CreateTestViewModel(List<Difficulty> difficulties, List<Topic> topics)
        {
            Difficulties = new SelectList(difficulties, "DifficultyId", "Name", difficulties[0]);
            
            Topics = new SelectList(topics, "TopicId", "Name", topics[0]);
        }

        public int DifficultyId { get; set; }

        public int TopicId { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }

       /* [DisplayName("Сложность")]
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
