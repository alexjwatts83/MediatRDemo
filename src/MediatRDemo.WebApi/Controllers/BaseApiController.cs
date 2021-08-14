using System.Threading.Tasks;
using MediatRDemo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController<TEntity, TKey> : ControllerBase where TEntity : BaseEntity<TKey>
	{
	}
}
