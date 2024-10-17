﻿using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Auth;
using API_Bibliotheque.Tools;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;
using Crypt = BCrypt.Net.BCrypt;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository<BLL.Auth> _AuthService;
        private readonly JwtGenerator _jwt;
        public AuthController(IAuthRepository<BLL.Auth> AuthService, JwtGenerator jwt)
        {
            _AuthService = AuthService;
            _jwt = jwt;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterPost auth)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            string hashpwd = Crypt.HashPassword(auth.Password);

            if (_AuthService.Register(auth.Email, hashpwd, auth.Name, auth.FirsName))
                return Ok();
            else
                return BadRequest("Register Failed");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login auth)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string dbpwd = _AuthService.GetPassword(auth.Email);

            if (Crypt.Verify(auth.Password, dbpwd))
            {
                Auth user = _AuthService.Login(auth.Email, dbpwd).ToAPI();
                string token = _jwt.GenerateToken(user);
                return Ok(token);
            }
            else
                return BadRequest("Login Failed");
        }
    }
}