using AutoMapper;
using Taskify.Models;
using Taskify.Models.ViewModel;

namespace Taskify.Core.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskItemViewModel, TaskItem>().ReverseMap();
        }
    }
}
