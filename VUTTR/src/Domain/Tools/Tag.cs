namespace VUTTR.Domain.Tools;

public class Tag : Entity
{
    public string Name { get; set; }
    public List<ToolTag> ToolTags { get; set; }
    public List<Tool> Tools { get; set; }
}