using Common.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week3.Domain.Entities;

public class Pet : BaseEntity<int>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BirthDate { get; set; }
    public string Color { get; set; }
    public string Gender { get; set; }
    [ForeignKey("OwnerId")]
    public Guid UserId { get; set; }
    [InverseProperty("Pets")]
    public virtual User Owner { get; set; }
    public virtual ICollection<HealthStatus> HealthStatuses { get; set; }
    public virtual ICollection<Activity> Activities { get; set; }

    public Pet()
    {
        Name = string.Empty;
        Type = string.Empty;
        BirthDate = DateTime.MinValue;
        Color = string.Empty;
        Gender = string.Empty;
        HealthStatuses = new HashSet<HealthStatus>();
        Activities = new HashSet<Activity>();
    }

    public Pet(
        string name, 
        string type, 
        DateTime birthDate, 
        string color, 
        string gender, 
        Guid userId
    )
    {
        Name = name;
        Type = type;
        BirthDate = birthDate;
        Color = color;
        Gender = gender;
        UserId = userId;
    }
    public Pet(
        int id,
        string name,
        string type,
        DateTime birthDate,
        string color,
        string gender,
        Guid userId
    )
        : base( id )
    {
        Name = name;
        Type = type;
        BirthDate = birthDate;
        Color = color;
        Gender = gender;
        UserId = userId;
    }
}



