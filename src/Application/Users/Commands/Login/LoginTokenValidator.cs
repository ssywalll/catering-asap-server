using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Application.Users.Commands.Login
{
    public class LoginTokenValidator : AbstractValidator<LoginCommand>
    {
        private readonly JwtSettings? _jwtSettings;

        public string? ValidateToken(string token)
        {
            if (token == null) 
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.securitykey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var user = jwtToken.Claims.First(x => x.Type == "email").Value;

                return user;
            }
            catch
            {
                return null;
            }
        } 
    }
}