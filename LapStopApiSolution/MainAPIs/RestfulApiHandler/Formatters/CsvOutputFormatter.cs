using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace RestfulApiHandler.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter() 
        {
            // Define which media type this formatter should Parse/Encodings
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv")); 
            SupportedEncodings.Add(Encoding.UTF8); 
            SupportedEncodings.Add(Encoding.Unicode); 
        }

        // Indicates whether or not
        // the EmployeeDto type can be written by this serializer
        protected override bool CanWriteType(Type? type) 
        {
            /// The IsAssignableFrom() returns [TRUE] 
            /// if the TYPES are the SAME, 
            /// or if the type IMPLEMENTS (Interface) or INHERITS it.
            if (typeof(EmployeeDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<EmployeeDto>).IsAssignableFrom(type))
            { 
                return base.CanWriteType(type); 
            }
            // Which Obj DON"T want to convert to CSV
            // false -> Response: 406 - Not Acceptable
            return false;
        }

        // Constructs the Response
        public override async Task WriteResponseBodyAsync(
                                        OutputFormatterWriteContext context, 
                                        Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response; 
            var buffer = new StringBuilder();
            if (context.Object is not null)     // check NULL
            {
                if (context.Object is IEnumerable<object>)  // collection
                {
                    foreach (var company in (IEnumerable<object>)context.Object)
                    {
                        FormatCsv(buffer, company);
                    }
                }
                else  // single Obj
                {
                    FormatCsv(buffer, context.Object);
                }
                await response.WriteAsync(buffer.ToString());
            }
        }

        // Formats a Response the way we want it
        private static void FormatCsv(StringBuilder buffer, object outputObj) 
        {
            // Define CSV format: Columns separated by comma ","
            if (outputObj.GetType() == typeof(EmployeeDto))
            {
                EmployeeDto employeeDto = (EmployeeDto)outputObj;
                buffer.AppendLine($"{employeeDto.Id},\"{employeeDto.FirstName},\"{employeeDto.LastName},\"{employeeDto.Phone}\"");
            }
            else if (outputObj.GetType() == typeof(BrandDto))
            {
                BrandDto brandDto = (BrandDto)outputObj;
                buffer.AppendLine($"{brandDto.Id},\"{brandDto.Name}\"");
            }
        }

    }
}
