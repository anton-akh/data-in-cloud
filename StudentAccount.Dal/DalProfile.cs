using AutoMapper;
using StudentAccount.Dal.Class;
using StudentAccount.Dal.Student;

namespace StudentAccount.Dal
{
    internal class DalProfile : Profile
    {
        public DalProfile()
        {
            CreateMap<StudentDao, Model.Student.Student>()
                .ReverseMap();

            CreateMap<ClassDao, Model.Class.Class>()
                .ReverseMap();
        }
    }
}
