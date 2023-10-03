using VUTTR.Domain.Tools;
namespace VUTTR.Endpoints;
public record ToolResponse(int Id, string Title, string Link, string Description, List<Tag> Tags);