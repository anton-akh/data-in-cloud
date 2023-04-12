
using AutoMapper;
using StudentAccount.Orchestrators.Class.Contract;
using StudentAccount.Orchestrators.Student.Contract;

namespace StudentAccount.Orchestrators
{
    internal class OrchestratorProfile : Profile
    {
        public OrchestratorProfile()
        {
            CreateMap<CreateStudent, Model.Student.Student>();
            CreateMap<EditStudent, Model.Student.Student>();

            CreateMap<CreateClass, Model.Class.Class>();
            CreateMap<EditClass, Model.Class.Class>();
        }
    }
}
