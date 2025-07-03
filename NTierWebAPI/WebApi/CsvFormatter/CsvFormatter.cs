using System.Globalization;
using CsvHelper;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApi.CsvFormatter
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            await using var writer = new StreamWriter(response.Body, selectedEncoding);
            await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            
            var records = context.Object as IEnumerable<object> ?? new List<object> { context.Object };
            
            if(records != null)
            {
                await csv.WriteRecordsAsync(records);
            }
        }
    }
}
