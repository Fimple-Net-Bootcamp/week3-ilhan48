using Common.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week3.Domain.Entities;

public class Food : BaseEntity<int>
{
    public string Name { get; set; }
    [ForeignKey("PetId")]
    public int PetId { get; set; }
    public virtual Pet Pet { get; set; }
    public Food()
    {
        Name = string.Empty;
    }
    public Food(string name, int petId)
    {
        Name = name;
        PetId = petId;
    }
    public Food(int id, string name, int petId) : base(id)
    {
        Name = name;
        PetId = petId;
    }
}
