using AutoMapper;
using projetoeclipseworks.Dtos;
using projetoeclipseworks.Application.Dtos;
using projetoeclipseworks.Dados.Entidades;

namespace projetoeclipseworks.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Projeto, ProjetoDto>().ReverseMap();
            CreateMap<TarefaDto, Tarefa>().ReverseMap();
            CreateMap<TarefaDto, Tarefa>().ReverseMap();
            CreateMap<AtualizacaoStatusTarefaDto, Tarefa>().ReverseMap();
        }
    }
}
