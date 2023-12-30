using AutoMapper;
using TARA.DATAENTRY.API.Data;
using TARA.DATAENTRY.API.Models.Masters;
using TARA.DATAENTRY.API.Models.QuestionCapturingDTO;
using TARA.DATAENTRY.API.Models.Users;

namespace TARA.DATAENTRY.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<RegisterUserDto, AppUser>().ReverseMap();
            CreateMap<Class, ClassResponseDto>()
                .ForMember(des=>des.Name,sor=> sor.MapFrom(src=>src.ClassName))
                .ReverseMap();
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject,SubjectResponseDto>().ReverseMap();
            CreateMap<Subject, ClassResponseDto>()
             .ForMember(des => des.Name, sor => sor.MapFrom(src => src.SubjectName)).ReverseMap();
            CreateMap<Lesson, ClassResponseDto>()
            .ForMember(des => des.Name, sor => sor.MapFrom(src => src.LessonName)).ReverseMap();
            CreateMap<Lesson, LessonDto>()
           .ForMember(des => des.Name, sor => sor.MapFrom(src => src.LessonName))
           .ReverseMap();
            CreateMap<Topic, ClassResponseDto>()
             .ForMember(des => des.Name, sor => sor.MapFrom(src => src.TopicName)).ReverseMap();
            CreateMap<Topic, TopicDto>()
            .ForMember(des => des.Name, sor => sor.MapFrom(src => src.TopicName)).ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<QuestionCaptureDto, QuestionCapturing>().ReverseMap();


        }
    }
}
