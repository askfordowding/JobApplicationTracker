using System.Net;
using JobApplicationService.API.Security;
using Xunit;

namespace JobApplicationService.IntegrationTests;

public sealed class SecurityPolicyTests
{
    [Fact]
    public void IsAllowedLocalOrigin_AllowsLoopbackOrigins()
    {
        var origins = new[]
        {
            "http://localhost:5173",
            "https://localhost:7101",
            "http://127.0.0.1:5173",
            "https://[::1]:7101"
        };

        foreach (var origin in origins)
        {
            Assert.True(SecurityPolicy.IsAllowedLocalOrigin(origin), $"Expected loopback origin to be allowed: {origin}");
        }
    }

    [Fact]
    public void IsAllowedLocalOrigin_RejectsNonLoopbackOrigins()
    {
        var origins = new[]
        {
            "https://example.com",
            "https://localhost.example.com",
            "file:///tmp/index.html",
            "not-a-uri"
        };

        foreach (var origin in origins)
        {
            Assert.False(SecurityPolicy.IsAllowedLocalOrigin(origin), $"Expected non-loopback origin to be rejected: {origin}");
        }
    }

    [Fact]
    public void IsAllowedRemoteAddress_AllowsLoopback()
    {
        var addresses = new[]
        {
            "127.0.0.1",
            "::1",
            "::ffff:127.0.0.1"
        };

        foreach (var address in addresses)
        {
            Assert.True(SecurityPolicy.IsAllowedRemoteAddress(IPAddress.Parse(address)), $"Expected loopback address to be allowed: {address}");
        }
    }

    [Fact]
    public void IsAllowedRemoteAddress_RejectsNonLoopback()
    {
        var addresses = new[]
        {
            "192.168.1.25",
            "10.0.0.10",
            "8.8.8.8"
        };

        foreach (var address in addresses)
        {
            Assert.False(SecurityPolicy.IsAllowedRemoteAddress(IPAddress.Parse(address)), $"Expected non-loopback address to be rejected: {address}");
        }
    }
}
