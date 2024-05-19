using AutoMapper;
using Entities;
using Shared.DTO;

namespace TaskManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskEvent, TaskDto>();
            CreateMap<TaskDto, TaskEvent>();
        }
    }
}
