using AutoMapper;
using cyrsach.BLL.Dto.Question;
using cyrsach.DAL.Entities;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {

        CreateMap<QuestionEntity, QuestionDto>();


        CreateMap<CreateQuestionDto, QuestionEntity>()
            .ForMember(dest => dest.Test, opt => opt.Ignore());

    }
}
