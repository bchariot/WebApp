namespace WebApp

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.OpenApi.Models

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    member _.ConfigureServices(services: IServiceCollection) =
        services.AddCors() |> ignore
        services.AddControllers() |> ignore
        services.AddSwaggerGen(fun config ->
            config.SwaggerDoc("v1", new OpenApiInfo( Title = "WebApp", Version = "v1" )) |> ignore
        ) |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        let ConfigureCors(corsBuilder: CorsPolicyBuilder): unit =        
            corsBuilder
                .WithOrigins("http://localhost:4200", "https://votes-web-app.vercel.app")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials() |> ignore
        app.UseCors(System.Action<CorsPolicyBuilder> ConfigureCors) |> ignore

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
            app.UseSwagger() |> ignore
            app.UseSwaggerUI(fun config ->
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "F# RestAPI v1") |> ignore
            ) |> ignore
        else
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseRouting() |> ignore
        app.UseAuthorization() |> ignore
        app.UseEndpoints(fun endpoints -> endpoints.MapControllers() |> ignore) |> ignore

    member val Configuration : IConfiguration = null with get, set
