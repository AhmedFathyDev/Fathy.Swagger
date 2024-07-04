# Fathy.Swagger

NuGet package for efficiently adding swagger in ASP.NET Core Web API apps. It simplifies the creation of interactive API documentation using the OpenAPI (Swagger) specification. This package helps developers to effortlessly visualize, test, and debug their API endpoints directly from the browser.

## Package Features

1. **Authorization**: Enable `Bearer` authorization by adding JWT bearer token to test authorized APIs.

![Authorization](https://raw.githubusercontent.com/AhmedFathyDev/Fathy.Swagger/master/images/Authorization.png)

![Bearer](https://raw.githubusercontent.com/AhmedFathyDev/Fathy.Swagger/master/images/Bearer.png)

2. **Localization**: Enable localization by sending the `Accept-Language` header, facilitating better internationalization.

![Accept-Language](https://raw.githubusercontent.com/AhmedFathyDev/Fathy.Swagger/master/images/Accept-Language.png)

3. **Minimal APIs**: Enable interactive UI for minimal API endpoints to explore and test directly in the browser.

```csharp
var app = builder.Build();

///

app.MapGet("/", () => "Hello, World!");

///

app.Run();
```
![Minimal APIs](https://raw.githubusercontent.com/AhmedFathyDev/Fathy.Swagger/master/images/Minimal-APIs.png)

4. **Query Parameters**: Enable sending date in the query string as query parameters, enhancing API usability and understanding.

```csharp
[HttpGet]
public IActionResult Verify([FromQuery] string code) => code == VerificationCode ?
    Ok("Verified...") : BadRequest("Wrong verification code!!!");
```
![Query Parameters](https://raw.githubusercontent.com/AhmedFathyDev/Fathy.Swagger/master/images/Query-Parameters.png)

## Installing Package

```shell
$ dotnet add package Fathy.Swagger
```

## Adding Service

```csharp
var builder = WebApplication.CreateBuilder(args);

///

var openApiInfo = new OpenApiInfo
{
    Title = "HelloWorld.API",
    Version = "v1"
};

builder.Services.AddSwaggerService(openApiInfo);

///

var app = builder.Build();
///
```

## Using Service

```csharp
///
var app = builder.Build();

///

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/{openApiInfo.Version}/swagger.json", openApiInfo.Title);
});

///

app.Run();
```

## Test your API

```
APPLICATION_URL/swagger/index.html
```