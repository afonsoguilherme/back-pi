using AutoMapper;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            // Mapeando a classe Usuario
            CreateMap<UsuarioDTO, Usuario>().
                AfterMap((dto, model) => model.Id = dto.Id);
            CreateMap<Usuario, UsuarioDTO>()
                .AfterMap((model, dto) => dto.Id = model.Id);

            // Mapeando a classe Vendedor
            CreateMap<VendedorDTO, Vendedor>().
                AfterMap((dto, model) => model.IdVendedor = dto.IdVendedor);
            CreateMap<Vendedor, VendedorDTO>()
                .AfterMap((model, dto) => dto.IdVendedor = model.IdVendedor);

                // Mapeando a classe Movimento
            CreateMap<MovimentoDTO, Movimento>().
                AfterMap((dto, model) => model.IdMovimento = dto.IdMovimento);
            CreateMap<Movimento, MovimentoDTO>()
                .AfterMap((model, dto) => dto.IdMovimento = model.IdMovimento);

                // Mapeando a classe VendaNaoSucedida
            CreateMap<VendaNaoSucedidaDTO, VendaNaoSucedida>().
                AfterMap((dto, model) => model.IdVendaNaoSucedida = dto.IdVendaNaoSucedida);
            CreateMap<VendaNaoSucedida, VendaNaoSucedidaDTO>()
                .AfterMap((model, dto) => dto.IdVendaNaoSucedida = model.IdVendaNaoSucedida);

                // Mapeando a classe FilaEspera
            CreateMap<FilaEsperaDTO, FilaEspera>().
                AfterMap((dto, model) => model.IdVendedorEmEspera = dto.IdVendedorEmEspera);
            CreateMap<FilaEspera, FilaEsperaDTO>()
                .AfterMap((model, dto) => dto.IdVendedorEmEspera = model.IdVendedorEmEspera);

                // Mapeando a classe FilaAtendimento
            CreateMap<FilaAtendimentoDTO, FilaAtendimento>().
                AfterMap((dto, model) => model.IdVendedorEmAtendimento = dto.IdVendedorEmAtendimento);
            CreateMap<FilaAtendimento, FilaAtendimentoDTO>()
                .AfterMap((model, dto) => dto.IdVendedorEmAtendimento = model.IdVendedorEmAtendimento);

                // Mapeando a classe FilaAusencia
            CreateMap<FilaAusenciaDTO, FilaAusencia>().
                AfterMap((dto, model) => model.IdVendedorEmAusencia = dto.IdVendedorEmAusencia);
            CreateMap<FilaAusencia, FilaAusenciaDTO>()
                .AfterMap((model, dto) => dto.IdVendedorEmAusencia = model.IdVendedorEmAusencia);

                // Mapeando a classe Marca
            CreateMap<MarcaDTO, Marca>().
                AfterMap((dto, model) => model.IdMarca = dto.IdMarca);
            CreateMap<Marca, MarcaDTO>()
                .AfterMap((model, dto) => dto.IdMarca = model.IdMarca);

                // Mapeando a classe Tipo
            CreateMap<TipoDTO, Tipo>().
                AfterMap((dto, model) => model.IdTipo = dto.IdTipo);
            CreateMap<Tipo, TipoDTO>()
                .AfterMap((model, dto) => dto.IdTipo = model.IdTipo);

                // Mapeando a classe Cor
            CreateMap<CorDTO, Cor>().
                AfterMap((dto, model) => model.IdCor = dto.IdCor);
            CreateMap<Cor, CorDTO>()
                .AfterMap((model, dto) => dto.IdCor = model.IdCor);

                // Mapeando a classe TamanhoAlfabetico
            CreateMap<TamanhoAlfabeticoDTO, TamanhoAlfabetico>().
                AfterMap((dto, model) => model.IdTamanhoAlfabetico = dto.IdTamanhoAlfabetico);
            CreateMap<TamanhoAlfabetico, TamanhoAlfabeticoDTO>()
                .AfterMap((model, dto) => dto.IdTamanhoAlfabetico = model.IdTamanhoAlfabetico);

            // Mapeando a classe TamanhoNumerico
            CreateMap<TamanhoNumericoDTO, TamanhoNumerico>().
                AfterMap((dto, model) => model.IdTamanhoNumerico = dto.IdTamanhoNumerico);
            CreateMap<TamanhoNumerico, TamanhoNumericoDTO>()
                .AfterMap((model, dto) => dto.IdTamanhoNumerico = model.IdTamanhoNumerico);
        }
    }
}
