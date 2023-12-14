using Common.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week3.Domain.Entities;

public class Activity : BaseEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string DifficultyLevel { get; set; }
    [ForeignKey("PetId")]
    public int PetId { get; set; }
    public virtual Pet Pet { get; set; }

    public Activity()
    {
        Name = string.Empty;
        Description = string.Empty;
        DifficultyLevel = string.Empty;
    }

    public Activity(
        string name, 
        string description, 
        string difficultyLevel, 
        int petId
    )
    {
        Name = name;
        Description = description;
        DifficultyLevel = difficultyLevel;
        PetId = petId;
    }
    public Activity(
        int id,
        string name,
        string description,
        string difficultyLevel,
        int petId
    )
        : base(id)
    {
        Name = name;
        Description = description;
        DifficultyLevel = difficultyLevel;
        PetId = petId;
    }
}



