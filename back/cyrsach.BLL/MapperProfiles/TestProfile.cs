using AutoMapper;
using cyrsach.BLL.Dto.Test;
using cyrsach.DAL.Entities;

public class TestProfile : Profile
{
    public TestProfile()
    {

        CreateMap<TestEntity, TestDto>()
            .ForMember(dest => dest.AuthorName,
                opt => opt.MapFrom(src => src.Author.Name));


        CreateMap<CreateTestDto, TestEntity>()
            .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.Author, opt => opt.Ignore()); 

    }
}