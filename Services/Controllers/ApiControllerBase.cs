using Microsoft.AspNetCore.Mvc;
using BLL.Core;

namespace Services.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApiControllerBase : ControllerBase
{
    private BusinessContext _businessContext = null!;

    protected BusinessContext BusinessContext => _businessContext ??= HttpContext.RequestServices.GetRequiredService<BusinessContext>();
}
