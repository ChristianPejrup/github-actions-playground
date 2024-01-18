using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Api;

namespace IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program> 
{
    public CustomWebApplicationFactory()
        : base()
    {

    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
        });

        builder.UseEnvironment("Development");
    }
}

