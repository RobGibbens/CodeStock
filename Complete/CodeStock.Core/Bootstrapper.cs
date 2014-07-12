using AutoMapper;
using CodeStock.Core.Models;

namespace CodeStock.Core
{
    public class Bootstrapper
    {
        public void Automapper()
        {
            Mapper.CreateMap<ConferenceDto, Conference>()
                .ForMember(dest => dest.City, opt => opt.ResolveUsing<CityResolver>());

            Mapper.CreateMap<SessionDto, Session>();
        }
    }

    public class CityResolver : ValueResolver<ConferenceDto, string>
    {
        protected override string ResolveCore(ConferenceDto source)
        {
            if (source == null || source.address == null)
                return string.Empty;

            return source.address.city;
        }
    }
}