using System.Text;

namespace Microservice.Appointments.Application.Helpers
{
    public class Http_Helper
    {
        public static string GetUrlWithQueryParams(string paramName, List<string> values)
        {
            StringBuilder sb = new();
            sb.Append($"?");

            foreach (var item in values) {
                sb.Append($"{paramName}={item}&");
            }

            string output = sb.ToString();
            output = output.Remove(output.Length - 1);
            return output;
        }
    }
}
