namespace Week3.Application.DTOs;

public class ActivityAddDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string DifficultyLevel { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Date { get; set; }
}
