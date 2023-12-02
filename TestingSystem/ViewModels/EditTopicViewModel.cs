using Microsoft.Build.Framework;

namespace TestingSystem.ViewModels
{
    public class EditTopicViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
