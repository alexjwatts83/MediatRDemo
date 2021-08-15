using AutoMapper;

namespace MediatRDemo.Application.Mappings
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
		//void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
	}

	//public interface IMapTo<T>
	//{
	//	void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
	//}
}
