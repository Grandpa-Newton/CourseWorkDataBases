using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab06.Models;

public partial class Test
{
    public int TestId { get; set; }

    [Required(ErrorMessage ="Укажите название теста")]
    public string Name { get; set; } = null!;

    public int TopicId { get; set; }

    public int DifficultyId { get; set; }

    [Range(1, 100, ErrorMessage = "Количество вопросов должно быть в промежутке от 1 до 100")]
    [Required(ErrorMessage = "Укажите количество вопросов")]
    public int NumberOfQuestions { get; set; }

    public virtual Difficulty? Difficulty { get; set; } = null!;

    public virtual Topic? Topic { get; set; } = null!;
}
