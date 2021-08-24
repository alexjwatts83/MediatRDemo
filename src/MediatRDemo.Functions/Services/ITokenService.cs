using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public interface ITokenService
	{
		Task<string> GetLastToken();
		Task<bool> SaveToken(string token);
	}
}
