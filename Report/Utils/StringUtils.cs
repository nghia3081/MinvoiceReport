using MinvoiceReport.Extensions;
using System.Linq;

namespace MinvoiceReport.Utils
{
    public class StringUtils
    {
        public static bool IsAllNullOrEmpty(params string[] values)
        {
            return values.All(x => x.IsNullOrEmpty());
        }
        public static bool IsAnyNullOrEmpty(params string[] values)
        {
            return values.Any(x => x.IsNullOrEmpty());
        }
    }
}
