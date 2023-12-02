using Microsoft.Build.Framework;
using System.Composition.Convention;

namespace TestingSystem.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
