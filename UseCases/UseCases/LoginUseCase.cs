using Dtos;
using Ports.Input;
using Ports.Output;
using Domain.Common;
using Domain.Interfaces.Repositories;
using Ports.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonWebTokenService;

namespace UseCases
{
    public class LoginUseCase : ILoginInputPort
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILoginOutputPort _outputPort;

        public LoginUseCase(IUserRepository userRepository, 
            ITokenService tokenService,
            ILoginOutputPort outputPort)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _outputPort = outputPort;
        }

        public async Task LoginHandle(LoginInputDto login)
        {
            var userVerified = await _userRepository.ValidateUser(login.UserName!, login.Password!);

            if (!userVerified)
            {
                throw new KeyNotFoundException("Usuario o contraseña inválidos");
            }

            LoginViewDto loginView = _tokenService.GenerateToken(login);

            var response = new ResponseModel<LoginViewDto>()

            {
                IsSuccess = userVerified,
                Message = "Usuario y contraseña válidos",
                Result = loginView
            };

            await _outputPort.LoginHandle(response);
        }
    }
}
