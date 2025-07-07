// <copyright file="PromiseEngineContingenciaTest.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

//using AutoFixture;

//using Moq;

//using PRUEBA_SODIMAC.Application.Common.Interfaces.Bifurcacion;
//using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
//using PRUEBA_SODIMAC.Application.Common.Models.DTOs;
//using PRUEBA_SODIMAC.Application.Services;

//namespace PRUEBA_SODIMAC.UnitTests.Application.Services
//{
//	public class PromiseEngineContingenciaTest
//	{
//		private readonly Mock<ISerilogImplements> _serilogImplementsMock;
//		private readonly Mock<IBifurcacionDatosPromiseEngine> _bifurcacionMock;
//		private readonly Fixture _fixture;

//		public PromiseEngineContingenciaTest()
//		{
//			_serilogImplementsMock = new Mock<ISerilogImplements>();
//			_bifurcacionMock = new Mock<IBifurcacionDatosPromiseEngine>();
//			_fixture = new Fixture();
//		}


//		private PromiseEngineContingencia ConstructorApplication()
//		{

//			return new PromiseEngineContingencia(_serilogImplementsMock.Object, _bifurcacionMock.Object);

//		}


//		[Fact]
//		public async Task PromiseEngineContingencia_ReturnsSuccessfulResponseFinal()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();


//			_bifurcacionMock.Setup(x => x.BifurcacionArmarGrupos(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoProcesarCont>>());
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Create<List<DtoProductoConCobertura>>());
//			_bifurcacionMock.Setup(x => x.BufurcacionDatosArmarResponse(It.IsAny<List<DtoGrupoProcesarCont>>(), It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoProductoConCobertura>>());
//			_bifurcacionMock.Setup(x => x.BifurcacionJsonResponse(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoEntregaCont>>());


//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Create<DtoJsonRequest>());

//			// Assert
//			Assert.NotNull(result);
//		}


//		[Fact]
//		public async Task PromiseEngineContingencia_ReturnsSuccessfulResponseFinal_TrueExisteDomRf()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();

//			var prdLvlNumbers = new[] { "5878", "78965", "365478" };
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(3).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														dto.IdPromesaCliente = 2;
//																														return dto;
//																													}).ToList());


//			_bifurcacionMock.Setup(x => x.BifurcacionArmarGrupos(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoGrupoProcesarCont>()
//																													.Without(x => x.Skus)
//																													.CreateMany(3).Select((dto, index) =>
//																													{
//																														dto.Skus = prdLvlNumbers.ToList();
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BufurcacionDatosArmarResponse(It.IsAny<List<DtoGrupoProcesarCont>>(), It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(3).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BifurcacionJsonResponse(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoEntregaCont>>());


//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Build<DtoJsonRequest>()
//																		.With(x => x.Productos, new List<DtoProductosRequestCont>
//																		{
//																			new DtoProductosRequestCont { Sku = "5878", Cantidad = _fixture.Create<int>() },
//																			new DtoProductosRequestCont { Sku = "78965", Cantidad = _fixture.Create<int>() },
//																			new DtoProductosRequestCont { Sku = "365478", Cantidad = _fixture.Create<int>() }
//																		}).Create());

//			// Assert
//			Assert.NotNull(result);
//		}


//		[Fact]
//		public async Task PromiseEngineContingencia_ReturnsSuccessfulResponseFinal_TrueExisteDomRf_UnGrupo()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();

//			var prdLvlNumbers = new[] { "5878", "78965", "365478" };
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														dto.IdPromesaCliente = 2;
//																														return dto;
//																													}).ToList());


//			_bifurcacionMock.Setup(x => x.BifurcacionArmarGrupos(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoGrupoProcesarCont>()
//																													.Without(x => x.Skus)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.Skus = prdLvlNumbers.ToList();
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BufurcacionDatosArmarResponse(It.IsAny<List<DtoGrupoProcesarCont>>(), It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BifurcacionJsonResponse(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoEntregaCont>>());


//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Build<DtoJsonRequest>()
//																		.With(x => x.Productos, new List<DtoProductosRequestCont>
//																		{
//																			new DtoProductosRequestCont { Sku = "5878", Cantidad = _fixture.Create<int>() },
//																		}).Create());

//			// Assert
//			Assert.NotNull(result);
//		}


//		[Fact]
//		public async Task PromiseEngineContingencia_ReturnsSuccessfulResponseFinal_TrueExisteDomRf_UnGrupo_promes_2_4()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();

//			var prdLvlNumbers = new[] { "5878", "78965" };
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoProductoConCobertura>()
//																												.Without(x => x.PrdLvlNumber)
//																												.CreateMany(2)
//																												.Select((dto, index) =>
//																												{
//																													dto.PrdLvlNumber = prdLvlNumbers[index];
//																													dto.IdPromesaCliente = index == 0 ? 2 : 4;
//																													return dto;
//																												}).ToList());


//			_bifurcacionMock.Setup(x => x.BifurcacionArmarGrupos(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoGrupoProcesarCont>()
//																													.Without(x => x.Skus)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.Skus = prdLvlNumbers.ToList();
//																														dto.Productos = _fixture.Build<DtoProductoConCobertura>()
//																																				.Without(x => x.PrdLvlNumber).CreateMany(2)
//																																				.Select((dto, index) =>
//																																				{
//																																					dto.PrdLvlNumber = prdLvlNumbers[index];
//																																					dto.IdPromesaCliente = index == 0 ? 2 : 4;
//																																					return dto;
//																																				}).ToList();
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BufurcacionDatosArmarResponse(It.IsAny<List<DtoGrupoProcesarCont>>(), It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(2).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BifurcacionJsonResponse(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoEntregaCont>>());


//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Build<DtoJsonRequest>()
//																		.With(x => x.Productos, new List<DtoProductosRequestCont>
//																		{
//																			new DtoProductosRequestCont { Sku = "5878", Cantidad = _fixture.Create<int>() },
//																		}).Create());

//			// Assert
//			Assert.NotNull(result);
//		}

//		[Fact]
//		public async Task PromiseEngineContingencia_ReturnsSuccessfulResponseFinal_TrueExisteDomRf_SinUnGrupo()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();

//			var prdLvlNumbers = new[] { "5878", "78965", "365478" };
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														dto.IdPromesaCliente = 2;
//																														return dto;
//																													}).ToList());


//			_bifurcacionMock.Setup(x => x.BifurcacionArmarGrupos(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoGrupoProcesarCont>()
//																													.Without(x => x.Skus)
//																													.CreateMany(0).Select((dto, index) =>
//																													{
//																														dto.Skus = prdLvlNumbers.ToList();
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BufurcacionDatosArmarResponse(It.IsAny<List<DtoGrupoProcesarCont>>(), It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BifurcacionJsonResponse(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoEntregaCont>>());


//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Build<DtoJsonRequest>()
//																		.With(x => x.Productos, new List<DtoProductosRequestCont>
//																		{
//																			new DtoProductosRequestCont { Sku = "5878", Cantidad = _fixture.Create<int>() },
//																		}).Create());

//			// Assert
//			Assert.NotNull(result);
//		}

//		[Fact]
//		public async Task PromiseEngineContingencia_ReturnsSuccessfulResponseFinal_FalseExisteDomRf()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();

//			var prdLvlNumbers = new[] { "5878", "78965", "365478" };
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														dto.IdPromesaCliente = 4;
//																														return dto;
//																													}).ToList());


//			_bifurcacionMock.Setup(x => x.BifurcacionArmarGrupos(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoGrupoProcesarCont>()
//																													.Without(x => x.Skus)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.Skus = prdLvlNumbers.ToList();
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BufurcacionDatosArmarResponse(It.IsAny<List<DtoGrupoProcesarCont>>(), It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(1).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BifurcacionJsonResponse(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoEntregaCont>>());


//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Build<DtoJsonRequest>()
//																		.With(x => x.Productos, new List<DtoProductosRequestCont>
//																		{
//																			new DtoProductosRequestCont { Sku = "5878", Cantidad = _fixture.Create<int>() },
//																		}).Create());

//			// Assert
//			Assert.NotNull(result);
//		}

//		[Fact]
//		public async Task PromiseEngineContingencia_BifurcacionDatosProdCobert_0()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();

//			var prdLvlNumbers = new[] { "5878", "78965", "365478" };
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(0).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														dto.IdPromesaCliente = 4;
//																														return dto;
//																													}).ToList());



//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Build<DtoJsonRequest>()
//																		.With(x => x.Productos, new List<DtoProductosRequestCont>
//																		{
//																			new DtoProductosRequestCont { Sku = "5878", Cantidad = _fixture.Create<int>() },
//																		}).Create());

//			// Assert
//			Assert.NotNull(result);
//		}


//		[Fact]
//		public async Task PromiseEngineContingencia_ReturnsSuccessfulResponseFinal_TrueExisteDomRf_SinUnGrupo_Promesa_2_4()
//		{
//			// Arrange
//			var servicio = ConstructorApplication();

//			var prdLvlNumbers = new[] { "5878", "78965", "365478" };
//			_bifurcacionMock.Setup(x => x.BifurcacionDatosProdCobert(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoProductoConCobertura>()
//																												.Without(x => x.PrdLvlNumber)
//																												.CreateMany(2)
//																												.Select((dto, index) =>
//																												{
//																													dto.PrdLvlNumber = prdLvlNumbers[index];
//																													dto.IdPromesaCliente = index == 0 ? 2 : 4;
//																													return dto;
//																												}).ToList());


//			_bifurcacionMock.Setup(x => x.BifurcacionArmarGrupos(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoGrupoProcesarCont>()
//																													.Without(x => x.Skus)
//																													.CreateMany(0).Select((dto, index) =>
//																													{
//																														dto.Skus = prdLvlNumbers.ToList();
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BufurcacionDatosArmarResponse(It.IsAny<List<DtoGrupoProcesarCont>>(), It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Build<DtoProductoConCobertura>()
//																													.Without(x => x.PrdLvlNumber)
//																													.CreateMany(2).Select((dto, index) =>
//																													{
//																														dto.PrdLvlNumber = prdLvlNumbers[index];
//																														return dto;
//																													}).ToList());

//			_bifurcacionMock.Setup(x => x.BifurcacionJsonResponse(It.IsAny<List<DtoProductoConCobertura>>())).Returns(_fixture.Create<List<DtoGrupoEntregaCont>>());


//			// Act
//			var result = await servicio.ProcesarContingencia(_fixture.Build<DtoJsonRequest>()
//																		.With(x => x.Productos, new List<DtoProductosRequestCont>
//																		{
//																			new DtoProductosRequestCont { Sku = "5878", Cantidad = _fixture.Create<int>() },
//																			new DtoProductosRequestCont { Sku = "78965", Cantidad = _fixture.Create<int>() },
//																		}).Create());

//			// Assert
//			Assert.NotNull(result);
//		}


//	}
//}
