namespace VUTTR.Domain.Tools;

public class ToolTag
{
    public int ToolId { get; set; }
    public Tool Tool { get; set; } = null!;

    public int TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}
