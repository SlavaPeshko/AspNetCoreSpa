using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {

    }
}
