using System.Net;
using JobApplicationService.API.Security;

namespace JobApplicationService.IntegrationTests;

public sealed class SecurityPolicyTests
{
    [Theory]
    [InlineData("http://localhost:5173")]
    [InlineData("https://localhost:7101")]
    [InlineData("http://127.0.0.1:5173")]
    [InlineData("https://[::1]:7101")]
    public void IsAllowedLocalOrigin_AllowsLoopbackOrigins(string origin)
    {
        Assert.True(SecurityPolicy.IsAllowedLocalOrigin(origin));
    }

    [Theory]
    [InlineData("https://example.com")]
    [InlineData("https://localhost.example.com")]
    [InlineData("file:///tmp/index.html")]
    [InlineData("not-a-uri")]
    public void IsAllowedLocalOrigin_RejectsNonLoopbackOrigins(string origin)
    {
        Assert.False(SecurityPolicy.IsAllowedLocalOrigin(origin));
    }

    [Theory]
    [InlineData("127.0.0.1")]
    [InlineData("::1")]
    [InlineData("::ffff:127.0.0.1")]
    public void IsAllowedRemoteAddress_AllowsLoopback(string address)
    {
        Assert.True(SecurityPolicy.IsAllowedRemoteAddress(IPAddress.Parse(address)));
    }

    [Theory]
    [InlineData("192.168.1.25")]
    [InlineData("10.0.0.10")]
    [InlineData("8.8.8.8")]
    public void IsAllowedRemoteAddress_RejectsNonLoopback(string address)
    {
        Assert.False(SecurityPolicy.IsAllowedRemoteAddress(IPAddress.Parse(address)));
    }
}
