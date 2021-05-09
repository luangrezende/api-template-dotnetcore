using System.Text;
using System;

namespace Template.Project.Util.ConfigErrors
{
    public static class ExceptionExtension
    {
        public static string GetCompleteDescription(this Exception ex)
        {
            var sb = new StringBuilder();
            do
            {
                sb.AppendLine("Error: " + ex.Message);
                sb.AppendLine("Stack Trace: " + ex.StackTrace);
                if (ex.InnerException != null)
                {
                    sb.AppendLine();
                    sb.AppendLine("InnerException:");
                }
                ex = ex.InnerException;
            }
            while (ex != null);
            return sb.ToString();
        }

        public static string GetSimpleDescription(this Exception ex)
        {
            return $"Error: {ex.Message} - Details: {ex.InnerException?.Message: 'No details'}";
        }
    }
}
