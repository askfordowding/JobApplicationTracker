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
}
