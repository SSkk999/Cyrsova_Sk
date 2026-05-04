using AutoMapper;
using cyrsach.BLL.Dto.Answer;
using cyrsach.DAL.Entities;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {

        CreateMap<AnswerEntity, AnswerDto>();


        CreateMap<CreateAnswerDto, AnswerEntity>()
            .ForMember(dest => dest.Question, opt => opt.Ignore());
    }
}