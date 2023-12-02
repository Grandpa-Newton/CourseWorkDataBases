using System.ComponentModel.DataAnnotations;

namespace TestingSystem.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
