
using AutoMapper;
using StudentAccount.Orchestrators.Student.Contract;

namespace StudentAccount.Orchestrators
{
    internal class OrchestratorProfile : Profile
    {
        public OrchestratorProfile()
        {
            CreateMap<CreateStudent, Model.Student.Student>();
        }
    }
}
