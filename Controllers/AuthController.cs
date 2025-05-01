using Microsoft.AspNetCore.Mvc;
using NetStock.Dtos;
using NetStock.Entities;
using NetStock.Repositories;
using NetStock.Services;

namespace NetStock.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {

        private readonly UserRepository repository;

        private readonly PasswordHasher passwordHasher;

        public AuthController(UserRepository _repository, PasswordHasher PasswordHasher)
        {
            this.repository = _repository;
            this.passwordHasher = PasswordHasher;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserDto DataRegister)
        {

            var ExistUser = await this.repository.GetByEmailAsync(DataRegister.Email);

            if (ExistUser.Email != null)
            {

                return Unauthorized(new { message = "Email já registrado" });

            }
            else
            {

                if (DataRegister.Password != DataRegister.ConfirmPasswod)
                {

                    return Unauthorized(new { message = "Erro na confirmação de senha" });
                }
                else
                {

                    var hashPassword = this.passwordHasher.Hash(DataRegister.Password);

                    var newUser = new User
                    {
                        Name = DataRegister.Name,
                        Email = DataRegister.Email,
                        Password = hashPassword,
                        Phone = DataRegister.ConfirmPasswod

                    };

                    await this.repository.AddAsync(newUser);

                    return Ok(new { message = "Usuario registrado com sucesso", token = "" });



                }

            }



        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserDto DataLogin)
        {

            var userExist = await this.repository.GetByEmailAsync(DataLogin.Email);

            if (userExist.Email != null)
            {
                return Unauthorized(new { message = "Não existe um usuario registrado com esse email" });
            }


            var checkPassword = this.passwordHasher.Verify(userExist.Password, DataLogin.Passwod);

            if (checkPassword)
            {
                return BadRequest(new { message = "Senha incorreta" });
            }





            return Ok(new
            {
                message = "Usuario registrado com sucesso"
            });

        }





    }
}