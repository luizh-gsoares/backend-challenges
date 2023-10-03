using System.ComponentModel.DataAnnotations;

namespace VUTTR.Domain;

public abstract class Entity
{
    [Key] public int Id { get; set; }
}