using Houston2.Common.Clients.Core;
using Vostok.Hosting.AspNetCore;
using Vostok.Hosting.AspNetCore.Houston;
using Vostok.Hosting.AspNetCore.Houston.Applications;
using Vostok.Hosting.Houston.Abstractions;
using Vostok.Hosting.Houston.Configuration;
using Vostok.Hosting.Houston2;
using Vostok.Hosting.Setup;

[assembly: HoustonEntryPoint(typeof(HoustonWebApplication))]

namespace WebApplication2;

public static class EntryPoint
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        //builder.UseHoustonHosting(SetupHouston);
        builder.UseVostokHosting(SetupVostok);
        
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }

    private static void SetupVostok(IVostokHostingEnvironmentBuilder builder)
    {
        builder.SetupFromHouston(new EnvAndHoustonHomeFolderAuthProvider("HOUSTON2_APIKEY"),
            "38652d55-a6d8-4c69-bb59-ae9e146ee0ae",
            "9851ede1-4660-41cd-83f9-e98dc4aa661a");
    }

    private static void SetupHouston(IHostingConfiguration configuration)
    {
        configuration.OutOfHouston.SetupEnvironment(builder =>
        {
            builder.SetupFromHouston(new EnvAndHoustonHomeFolderAuthProvider("HOUSTON2_APIKEY"),
                "38652d55-a6d8-4c69-bb59-ae9e146ee0ae",
                "9851ede1-4660-41cd-83f9-e98dc4aa661a");
        });
    }
}