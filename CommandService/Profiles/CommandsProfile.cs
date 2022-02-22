using AutoMapper;
using CommandService.Models;
using CommandService.Dtos;

namespace CommandService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<Command, CommandCreateDto>();
            CreateMap<Command, CommandReadDto>();
        }
    }
}