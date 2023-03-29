using AutoMapper;
using StudentAccount.Dal.Student;

namespace StudentAccount.Dal
{
    internal class DalProfile : Profile
    {
        public DalProfile()
        {
            CreateMap<StudentDao, Model.Student.Student>()
                .ReverseMap();
        }
    }
}
