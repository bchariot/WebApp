namespace WebApp

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    member _.ConfigureServices(services: IServiceCollection) =
        services.AddCors() |> ignore
        services.AddControllers() |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        let ConfigureCors(corsBuilder: CorsPolicyBuilder): unit =        
            corsBuilder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials() |> ignore
        app.UseCors(System.Action<CorsPolicyBuilder> ConfigureCors) |> ignore
        app.UseHttpsRedirection() |> ignore
        app.UseRouting() |> ignore
        app.UseAuthorization() |> ignore
        app.UseEndpoints(fun endpoints -> endpoints.MapControllers() |> ignore) |> ignore

    member val Configuration : IConfiguration = null with get, set
