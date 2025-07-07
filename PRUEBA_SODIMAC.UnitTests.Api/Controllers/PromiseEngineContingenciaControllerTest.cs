// <copyright file="PromiseEngineContingenciaControllerTest.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

//using AutoFixture;

//using Microsoft.AspNetCore.Mvc;

//using Moq;

//using Newtonsoft.Json;

//using PRUEBA_SODIMAC.Api.Controllers;
//using PRUEBA_SODIMAC.Api.Response;
//using PRUEBA_SODIMAC.Application.Common.Interfaces.Services;
//using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
//using PRUEBA_SODIMAC.Application.Common.Models.DTOs;
//using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;

//namespace PRUEBA_SODIMAC.UnitTests.Api.Controllers
//{
//    public class PromiseEngineContingenciaControllerTest
//    {
//        private readonly Mock<ISerilogImplements> _mockSerilog;
//        private readonly Mock<IPromiseEngineContingencia> _mockApplicattion;
//        private readonly Fixture _fixture;

//        public PromiseEngineContingenciaControllerTest()
//        {
//            _mockSerilog = new Mock<ISerilogImplements>();
//            _mockApplicattion = new Mock<IPromiseEngineContingencia>();
//            _fixture = new Fixture();
//        }


//        [Fact]
//        public async Task PromiseEngineContingencia_ReturnsOkResult_WhenResponseIsSuccessful()
//        {
//            // Arrange
//            _mockApplicattion.Setup(app => app.ProcesarContingencia(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Create<DtoGenericResponse<DtoJsonResponse>>());
//            var controller = new PromiseEngineContingenciaController(_mockSerilog.Object, _mockApplicattion.Object);

//            // Act
//            var result = await controller.ProcesarContingencia(_fixture.Create<DtoJsonRequest>());

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var okResultS = JsonConvert.SerializeObject(okResult.Value);
//            var okresultDs = JsonConvert.DeserializeObject<ApiResponse<DtoGenericResponse<DtoJsonResponse>>>(okResultS);

//            Assert.NotNull(okresultDs);
//        }

//        [Fact]
//        public async Task PromiseEngineContingencia_ReturnsConflictResult_WhenResponseIsUnsuccessful()
//        {
//            // Arrange
//            _mockApplicattion.Setup(app => app.ProcesarContingencia(It.IsAny<DtoJsonRequest>())).ReturnsAsync(_fixture.Build<DtoGenericResponse<DtoJsonResponse>>().With(x => x.EsExitoso, false).Create());
//            var controller = new PromiseEngineContingenciaController(_mockSerilog.Object, _mockApplicattion.Object);

//            // Act
//            var result = await controller.ProcesarContingencia(_fixture.Create<DtoJsonRequest>());

//            // Assert
//            var conflictResult = Assert.IsType<ObjectResult>(result);
//            Assert.Equal(409, conflictResult.StatusCode);
//        }

//        [Fact]
//        public async Task TrxInOutOmsCargueVta_ReturnsInternalServerError_WhenExceptionIsThrown()
//        {
//            // Arrange
//            _mockApplicattion.Setup(app => app.ProcesarContingencia(It.IsAny<DtoJsonRequest>())).ThrowsAsync(new Exception());
//            var controller = new PromiseEngineContingenciaController(_mockSerilog.Object, _mockApplicattion.Object);


//            // Act
//            var result = await controller.ProcesarContingencia(_fixture.Create<DtoJsonRequest>());

//            // Assert
//            var objectResult = Assert.IsType<ObjectResult>(result);
//            Assert.Equal(500, objectResult.StatusCode);
//        }

//        [Fact]
//        public async Task TrxInOutOmsCargueVta_ReturnsInternalServerError_BagRequest()
//        {
//            // Arrange
//            var controller = new PromiseEngineContingenciaController(_mockSerilog.Object, _mockApplicattion.Object);
//            // Act
//            var result = await controller.ProcesarContingencia(It.IsAny<DtoJsonRequest>());

//            // Assert
//            var objectResult = Assert.IsType<ObjectResult>(result);
//            Assert.Equal(404, objectResult.StatusCode);
//        }

//    }
//}
