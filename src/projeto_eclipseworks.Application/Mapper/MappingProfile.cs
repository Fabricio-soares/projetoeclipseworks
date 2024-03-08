using AutoMapper;
using projeto_eclipseworks.Application.Dtos;
using projeto_eclipseworks.Dados.Entidades;
using projeto_eclipseworks.Dtos;

namespace projeto_eclipseworks.Application.Mapper
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
