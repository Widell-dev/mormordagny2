using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiBaseController : ControllerBase
{
    protected async Task<ActionResult> CreatePagedResult<T>(IGenericRepository<T> repo, ISpecification<T> args, int PageNumber, int PageSize) where T :BaseEntity
    {
        var result = await repo.ListAsync(args);
        var items = await repo.CountAsync(args);
        var response = new PagedResult<T>(PageNumber, PageSize, items, result);

        return Ok(response);
    }
}
