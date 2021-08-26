using AutoMapper;

using Agenda.WebApi.Model;
using Agenda.WebApi.DTOs;
using System.Linq;

namespace Agenda.WebApi.Helpers
{
    public class AgendaWebApiProfile: Profile
    {
        public AgendaWebApiProfile()
        {
            CreateMap<Contato, ContatoDto>()
                .ForMember(dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}") 
            )
            .ForMember(dest => dest.Tipo,
                       op => op.MapFrom(src => src.Tipo.Descricao))
            .ForMember(dest => dest.DataAniversario,
                       opt => opt.MapFrom(src => src.DataAniversario.GetBirthday()))
            .ForMember(dest => dest.NumeroTelefone,
                       opt => opt.MapFrom(src => src.TelefonesContato.FirstOrDefault().Numero))
            .ForMember(dest => dest.Email,
                       opt => opt.MapFrom(src => src.EmailsContato.FirstOrDefault().Email));
            
            CreateMap<ContatoDto, Contato>();
            CreateMap<Contato, ContatoRegistrarDto>().ReverseMap();
        }
    }
}