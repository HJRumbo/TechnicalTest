using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Dtos;
using GenFu;
using JsonWebTokenService;
using Moq;
using Ports.Output;
using Presenters.Interfaces;
using Presenters.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;
using UseCases.UseCases;

namespace UseCaseLayerTests
{
    public class LoginUseCaseTests
    {
        [Fact]
        public async Task Login_CredentialsAreCorrects_ReturnToken()
        {
            // Arrange
            var mockuserRepository = new Mock<IUserRepository>();
            var mockJwtService = new Mock<ITokenService>();
            ILoginOutputPort output = new LoginPresenter();

            var login = A.New<LoginInputDto>();
            var loginView = A.New<LoginViewDto>();

            // Act
            mockuserRepository.Setup(p => p.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            mockJwtService.Setup(p => p.GenerateToken(login)).Returns(loginView);

            var useCase = new LoginUseCase(mockuserRepository.Object, mockJwtService.Object, output);

            await useCase.LoginHandle(login);
            var response = ((IPresenter<ResponseModel<LoginViewDto>>)output).Content;

            // Assert
            Assert.True(response!.IsSuccess);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result.Token!);
        }

        [Fact]
        public async Task Login_CredentialsAreInCorrects_ThrowNotFoundException()
        {
            // Arrange
            var mockuserRepository = new Mock<IUserRepository>();
            var mockJwtService = new Mock<ITokenService>();
            ILoginOutputPort output = new LoginPresenter();

            var login = A.New<LoginInputDto>();
            var loginView = A.New<LoginViewDto>();

            // Act
            mockuserRepository.Setup(p => p.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);
            mockJwtService.Setup(p => p.GenerateToken(login)).Returns(loginView);

            var useCase = new LoginUseCase(mockuserRepository.Object, mockJwtService.Object, output);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => useCase.LoginHandle(login));
        }
    }
}
