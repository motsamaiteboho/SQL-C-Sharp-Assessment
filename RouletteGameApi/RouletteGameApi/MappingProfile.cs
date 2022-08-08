using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace RouletteGameApi
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<Bet, BetDto>();
			CreateMap<Spin, SpinDto>();
		}
	}
}
