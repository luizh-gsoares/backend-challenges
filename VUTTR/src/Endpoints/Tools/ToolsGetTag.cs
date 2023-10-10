using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUTTR.Domain.Tools;
using VUTTR.Infra.Data;

namespace VUTTR.Endpoints.Tools
{
    public class ToolsGetTag
    {
        public static string Template => "/tools";
        public static IEnumerable<string> Methods => new[] { HttpMethod.Get.ToString() };
        
    }
}