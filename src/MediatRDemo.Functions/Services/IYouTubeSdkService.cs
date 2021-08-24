using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public interface IYouTubeSdkService
	{
		Task Search(string q);
		Task List(string channelId);
		Task Get(string videoId);
		Task Update(string videoId);
	}
}