using Microsoft.Build.Framework;

namespace TestingSystem.ViewModels
{
    public class CreateTopicViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
