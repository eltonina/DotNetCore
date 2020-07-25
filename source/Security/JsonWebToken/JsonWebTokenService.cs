using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetCore.Security
{
    public class JsonWebTokenService : IJsonWebTokenService
    {
        public JsonWebTokenService(JsonWebTokenSettings jsonWebTokenSettings)
        {
            JsonWebTokenSettings = jsonWebTokenSettings;
        }

        private JsonWebTokenSettings JsonWebTokenSettings { get; }

        public Dictionary<string, object> Decode(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token).Payload;
        }

        public string Encode(IList<Claim> claims)
        {
            claims ??= new List<Claim>();

            var jwtSecurityToken = new JwtSecurityToken
            (
                JsonWebTokenSettings.Issuer,
                JsonWebTokenSettings.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(JsonWebTokenSettings.Expires),
                new SigningCredentials(JsonWebTokenSettings.SecurityKey, SecurityAlgorithms.HmacSha512)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
