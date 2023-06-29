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
                // ===========VALIDATION=================
                // The ISSUER is the actual server that CREATED the token
                ValidateIssuer = CommonVariables.JwtTokenConfig.IsShouldValidateIssuer,                         // The issuer is the actual server that created the token
                // The receiver of the token is a VALID RECIPIENT
                ValidateAudience = CommonVariables.JwtTokenConfig.IsShouldValidateAudience,                     // The receiver of the token is a valid recipient
                // The token has NOT expired if FALSE
                ValidateLifetime = CommonVariables.JwtTokenConfig.IsShouldValidateLifetime,                     // The token has not expired
                // The signing key is VALID and is TRUSTED by the server
                ValidateIssuerSigningKey = CommonVariables.JwtTokenConfig.IsShouldValidateIssuerSigningKey,    // The signing key is valid and is trusted by the server
                // ClockSkew (default 5 mins) is the tolerance of difference time between Server and Client
                ClockSkew = CommonVariables.JwtTokenConfig.ClockSkewMinutes,
                // ===========GENERATE====================
                IssuerSigningKey = new SymmetricSecurityKey(CommonVariables.JwtTokenConfig.SecretKeyUTF8),
                ValidIssuer = CommonVariables.JwtTokenConfig.ValidIssuer,
                ValidAudience = CommonVariables.JwtTokenConfig.ValidAudience
            };
        }
    }
}
