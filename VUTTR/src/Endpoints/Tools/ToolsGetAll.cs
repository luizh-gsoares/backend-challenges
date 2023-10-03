using VUTTR.Domain.Tools;
using VUTTR.Infra.Data;

namespace VUTTR.Endpoints.Tools;

public abstract class ToolsGetAll
{
    public static string Template => "/tools";
    public static IEnumerable<string> Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    
    private static IResult Action(ApplicationDbContext context)
    {
        var tools = context.Tools.ToList();
        var response = tools.Select(t => new ToolResponse(t.Id, t.Title, t.Link, t.Description, new List<Tag>()));
        return Results.Ok(response);
    }
}