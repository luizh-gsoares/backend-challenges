namespace VUTTR.Domain.Tools;

public class Tag : Entity
{
    public string Name { get; set; }
    public ICollection<Tool> Tools { get; set; }
}