using AutoMapper;
using Core.Commands;
using Core.Commands.Handlers;
using Core.DTO;
using Core.Entities;
using Core.Interface;
using Core.Mapper;
using Infra;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestsChurras
{

    public class MainTest
    {
        private readonly IMapper _mapper;

        public MainTest()
        {
            var autoMapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CoreProfile());
            });

            _mapper = autoMapperConfig.CreateMapper();
        }

        [Fact]
        public void ObtemChurrasco()
        {
            var dbContextMock = new Mock<ChurrasDbContext>();
            var dbSetMock = new Mock<DbSet<Churrasco>>();
            var churrasco = new Churrasco()
            {
                Descricao = "Descrição",
                Observacoes = "Observações",
                ValorComBebida = 100,
                ValorSemBebida = 50
            };

            dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).Returns(new ValueTask<Churrasco>(churrasco));
            dbContextMock.Setup(s => s.Set<Churrasco>()).Returns(dbSetMock.Object);

            var churrasRepo = new ChurrascoRepository(dbContextMock.Object);
            var churrascNovo = churrasRepo.GetById(Guid.NewGuid()).Result;

            Assert.NotNull(churrascNovo);
            Assert.Equal(churrascNovo.ValorComBebida, churrasco.ValorComBebida);
            Assert.Equal(churrascNovo.ValorSemBebida, churrasco.ValorSemBebida);
        }

        [Fact]
        public async Task DeveCriarNovoChurrascoAsync()
        {
            var dbContextMock = new Mock<ChurrasDbContext>();
            var dbSetMock = new Mock<DbSet<Churrasco>>();
            var repo = new Mock<IChurrascoRepository>();
            var churrasco = new Churrasco()
            {
                Descricao = "Descrição",
                Observacoes = "Observações",
                ValorComBebida = 100,
                ValorSemBebida = 50
            };

            repo.Setup(x => x.Create(churrasco)).ReturnsAsync(churrasco);

            dbContextMock.Setup(s => s.Set<Churrasco>()).Returns(dbSetMock.Object);

            var churrasRepo = new ChurrascoRepository(dbContextMock.Object);
            var churrascNovo = churrasRepo.Create(churrasco).Result;

            var handler = new ChurrascoHandler(_mapper, repo.Object);

            var churrascoDTO = new ChurrascoDTO
            {
                Data = DateTime.Now.AddDays(5),
                Descricao = "Descrição",
                Observacoes = "Obs",
                ValorComBebida = 100,
                ValorSemBebida = 50
            };

            var cmd = new ChurrascoCommand(churrascoDTO);

            var resultado = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(resultado);
            Assert.Equal(resultado.ValorComBebida, churrascoDTO.ValorComBebida);
            Assert.Equal(resultado.ValorSemBebida, churrascoDTO.ValorSemBebida);
        }

        [Fact]
        public async Task DeveValidarChurrascoSemValorAsync()
        {
            var dbContextMock = new Mock<ChurrasDbContext>();
            var dbSetMock = new Mock<DbSet<Churrasco>>();
            var repo = new Mock<IChurrascoRepository>();

            dbContextMock.Setup(s => s.Set<Churrasco>()).Returns(dbSetMock.Object);

            var handler = new ChurrascoHandler(_mapper, repo.Object);

            var cmd = new ChurrascoCommand(new ChurrascoDTO
            {
                Data = DateTime.Now.AddDays(5),
                Descricao = "Descrição",
                Observacoes = "Obs",
                ValorComBebida = -1,
                ValorSemBebida = 0
            });

            try
            {
                var resultado = await handler.Handle(cmd, CancellationToken.None);
            }
            catch (Exception e)
            {
                Assert.Equal("Valor de contribuição inválido", e.Message);
                Assert.IsType<ArgumentException>(e);
            }
        }

        [Fact]
        public async Task DeveValidarChurrascoDataPassadaAsync()
        {
            var dbContextMock = new Mock<ChurrasDbContext>();
            var dbSetMock = new Mock<DbSet<Churrasco>>();
            var repo = new Mock<IChurrascoRepository>();

            dbContextMock.Setup(s => s.Set<Churrasco>()).Returns(dbSetMock.Object);

            var handler = new ChurrascoHandler(_mapper, repo.Object);

            var cmd = new ChurrascoCommand(new ChurrascoDTO
            {
                Data = DateTime.Now.AddDays(-1),
                Descricao = "Descrição",
                Observacoes = "Obs",
                ValorComBebida = 100,
                ValorSemBebida = 50
            });

            try
            {
                var resultado = await handler.Handle(cmd, CancellationToken.None);
            }
            catch (Exception e)
            {
                Assert.Equal("Data do churrasco tem que ser no futuro!", e.Message);
                Assert.IsType<ArgumentException>(e);
            }
        }
    }
}