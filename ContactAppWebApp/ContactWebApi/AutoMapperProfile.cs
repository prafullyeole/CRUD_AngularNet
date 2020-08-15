using AutoMapper;
using ContactWebApi.ViewModel;
using Entity.Models;

namespace ContactWebApi
{
    /// <summary>
    /// Auto Mapper for View Model and Model
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<ContactViewModel, Contact>();
        }
    }
}
