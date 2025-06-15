using AutoMapper;
using Resume.Application.DTOs;
using Resume.Domain.Entities;

namespace Resume.Application.Mapping;

public class ResumeProfile : Profile
{
    public ResumeProfile() {
        CreateMap<Domain.Entities.Resume, ResumeDto>().ReverseMap();
        CreateMap<Experience, ExperienceDto>().ReverseMap();
        CreateMap<Education, EducationDto>().ReverseMap();
        CreateMap<Skill, SkillDto>().ReverseMap();
        CreateMap<Language, LanguageDto>().ReverseMap();
        CreateMap<Reference, ReferenceDto>().ReverseMap();
        CreateMap<Link, LinkDto>().ReverseMap();
    }
}