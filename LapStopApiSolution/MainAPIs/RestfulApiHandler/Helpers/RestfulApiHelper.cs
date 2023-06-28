using Microsoft.IdentityModel.Tokens;
using Common.Variables;

namespace RestfulApiHandler.Helpers
{
    public static class RestfulApiHelper
    {
        public static TokenValidationParameters GetDefaultTokenValidationParams()
        {
            return new TokenValidationParameters
            {
                // VALIDATION
                ValidateIssuer = CommonVariables.JwtTokenConfig.IsShouldValidateIssuer,                         // The issuer is the actual server that created the token
                ValidateAudience = CommonVariables.JwtTokenConfig.IsShouldValidateAudience,                     // The receiver of the token is a valid recipient
                ValidateLifetime = CommonVariables.JwtTokenConfig.IsShouldValidateLifetime,                     // The token has not expired
                ValidateIssuerSigningKey = CommonVariables.JwtTokenConfig.IsShouldValidateIssuerSigningKey,    // The signing key is valid and is trusted by the server
                ClockSkew = CommonVariables.JwtTokenConfig.ClockSkewMinutes,
                // GENERATE
                IssuerSigningKey = new SymmetricSecurityKey(CommonVariables.JwtTokenConfig.SecretKeyUTF8),
                ValidIssuer = CommonVariables.JwtTokenConfig.ValidIssuer,
                ValidAudience = CommonVariables.JwtTokenConfig.ValidAudience
            };
        }
    }
}
