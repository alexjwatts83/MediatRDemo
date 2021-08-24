using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public interface ITokenService
	{
		Task<string> GetLastToken();
		Task<bool> SaveToken(string token);
	}
	public class TokenService : ITokenService
	{
		public Task<string> GetLastToken()
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> SaveToken(string token)
		{
			throw new System.NotImplementedException();
		}
	}
}
