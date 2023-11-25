using Microsoft.Build.Framework;

namespace Lab05New.ViewModels
{
    public class EditTopicViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
