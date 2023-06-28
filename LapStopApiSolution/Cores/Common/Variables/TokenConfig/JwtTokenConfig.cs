using System.Text;

namespace Common.Variables
{
    public static partial class CommonVariables
    {
        public static partial class JwtTokenConfig
        {
            /// <summary>
            /// Initialize ESSENTIAL values to use throughout the project
            /// </summary>
            /// <param name="algorithmForSignature"></param>
            /// <param name="secretKey"></param>
            /// <param name="validIssuer"></param>
            /// <param name="validAudience"></param>
            /// <param name="expirationMinutes"></param>
            /// <param name="clockSkewMinutes">ClockSkew (default 5 mins) is the tolerance of difference time between Server and Client</param>
            /// <param name="isShouldValidateIssuer">The ISSUER is the actual server that CREATED the token</param>
            /// <param name="isShouldValidateAudience">The receiver of the token is a VALID RECIPIENT</param>
            /// <param name="isShouldValidateIssuerSigningKey">The signing key is VALID and is TRUSTED by the server</param>
            /// <param name="isShouldValidateLifetime">The token has NOT expired if FALSE</param>
            public static void InitializeValues(
                string? algorithmForSignature,
                string? secretKey,
                string? validIssuer,
                string? validAudience,
                string? expirationMinutes,
                uint clockSkewMinutes = 5,
                bool isShouldValidateIssuer = true,             // The issuer is the actual server that created the token
                bool isShouldValidateAudience = true,           // The receiver of the token is a valid recipient
                bool isShouldValidateIssuerSigningKey = true,   // The signing key is valid and is trusted by the server
                bool isShouldValidateLifetime = true            // The token has not expired
            )
            {
                _secretKeyUTF8 = !string.IsNullOrEmpty(secretKey)
                                        ? Encoding.UTF8.GetBytes(secretKey)
                                        : Array.Empty<byte>();

                _expirationMinutesValue = !string.IsNullOrEmpty(expirationMinutes) &&
                                       Double.TryParse(expirationMinutes, out double expirationMinutesValue)
                                       ? expirationMinutesValue : 0;

                _algorithmForSignature = !string.IsNullOrEmpty(algorithmForSignature) ? algorithmForSignature : "none";
                _validIssuer = !string.IsNullOrEmpty(validIssuer) ? validIssuer : "";
                _validAudience = !string.IsNullOrEmpty(validAudience) ? validAudience : ""; 
                
                _isShouldValidateIssuer = isShouldValidateIssuer;
                _isShouldValidateAudience = isShouldValidateAudience;
                _isShouldValidateIssuerSigningKey = isShouldValidateIssuerSigningKey;
                _isShouldValidateLifetime = isShouldValidateLifetime;
                _clockSkewMinutes = TimeSpan.FromMinutes(Convert.ToDouble(clockSkewMinutes));
            }

            private static string _algorithmForSignature { get; set; } = "none";
            private static byte[] _secretKeyUTF8 { get; set; } = Array.Empty<byte>();
            private static string _validIssuer { get; set; } = "";
            private static string _validAudience { get; set; } = "";
            private static double _expirationMinutesValue { get; set; } = 0;
            private static TimeSpan _clockSkewMinutes { get; set; } = TimeSpan.FromMinutes(5);
            private static bool _isShouldValidateIssuer { get; set; }
            private static bool _isShouldValidateAudience { get; set; }
            private static bool _isShouldValidateIssuerSigningKey { get; set; }
            private static bool _isShouldValidateLifetime { get; set; }


            public static string AlgorithmForSignature => _algorithmForSignature;
            public static byte[] SecretKeyUTF8 => _secretKeyUTF8;
            public static string ValidIssuer => _validIssuer;
            public static string ValidAudience => _validAudience;
            
            /// <summary>
            /// Token will be expired AFTER this time
            /// </summary>
            public static DateTime? ExpirationTime => DateTime.Now.AddMinutes(_expirationMinutesValue);
            
            /// <summary>
            /// ClockSkew (default 5 mins) is the tolerance of difference time between Server and Client
            /// </summary>
            public static TimeSpan ClockSkewMinutes => _clockSkewMinutes;

            /// <summary>
            /// The ISSUER is the actual server that CREATED the token
            /// </summary>
            public static bool IsShouldValidateIssuer => _isShouldValidateIssuer;

            /// <summary>
            /// The receiver of the token is a VALID RECIPIENT
            /// </summary>
            public static bool IsShouldValidateAudience => _isShouldValidateAudience;
            
            /// <summary>
            /// The signing key is VALID and is TRUSTED by the server
            /// </summary>
            public static bool IsShouldValidateIssuerSigningKey => _isShouldValidateIssuerSigningKey;
            
            /// <summary>
            /// The token has NOT expired if FALSE
            /// </summary>
            public static bool IsShouldValidateLifetime => _isShouldValidateLifetime;

        }
    }
}
