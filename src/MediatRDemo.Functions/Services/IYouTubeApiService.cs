using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public interface IYouTubeApiService
	{
		Task Search(string q);
		Task List(string q);
		Task Get(string q);
	}
}