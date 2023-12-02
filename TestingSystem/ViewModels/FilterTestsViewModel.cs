using TestingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestingSystem.ViewModels
{
    public class FilterTestsViewModel
    {
        public FilterTestsViewModel(List<Difficulty> difficulties, List<Topic> topics, int difficulty, int topic, string name)
        {
            Difficulties = new SelectList(difficulties, "DifficultyId", "Name", difficulty);
            Topics = new SelectList(topics, "TopicId", "Name", topic);
            SelectedDifficulty = difficulty;
            SelectedTopic = topic;
            SelectedName = name;
        }

        public SelectList Difficulties { get; }
        public SelectList Topics { get; }

        public int SelectedDifficulty { get; }
        public int SelectedTopic { get; }

        public string SelectedName { get; }

    }
}
