using System.Net;

namespace JobApplicationService.API.Security;

public static class SecurityPolicy
{
    public static bool IsAllowedLocalOrigin(string? origin)
    {
        if (!Uri.TryCreate(origin, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            return false;
        }

        if (string.Equals(uri.Host, "localhost", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return IPAddress.TryParse(uri.Host, out var address) && IPAddress.IsLoopback(address);
    }
}
