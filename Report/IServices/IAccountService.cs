using MinvoiceReport.Utils;

namespace MinvoiceReport.IServices
{
    public interface IAccountService
    {
        string Login(ApiClient client, string taxCode, string username, string password);
        string GetMaDvcs(ApiClient client, string taxCode);
    }
}
