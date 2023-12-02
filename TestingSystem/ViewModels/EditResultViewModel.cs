using System.ComponentModel.DataAnnotations;

namespace TestingSystem.ViewModels
{
    public class EditResultViewModel
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string TestName { get; set; }

        [Required]
        [Range(1,10, ErrorMessage ="Недопустимая оценка (от 1 до 10)")]
        public int Mark { get; set; }
     }
}
