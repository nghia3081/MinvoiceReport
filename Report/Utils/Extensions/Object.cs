using System;
namespace MinvoiceReport.Extensions
{
    public static class Object
    {
        public static bool IsNull(this object value)
        {
            return value is null;
        }
        public static TypeConvert? TryParse<TypeConvert>(this object value) where TypeConvert : struct
        {
            try
            {
                return (TypeConvert) System.Convert.ChangeType(value, typeof(TypeConvert));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
