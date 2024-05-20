// using project.Utilities;
// using project;
// using Microsoft.OpenApi.Models;
// using project.Services;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Authentication.Google;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();

// // builder.Services.AddSwaggerGen();
// //to use with extension method
// builder.Services.AddTask();
// builder.Services.AddUser();
// builder.Services.AddLogin();
// //add 
// builder.Services.AddAuthentication(options =>
//                 {
//                     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//                 })
//                 .AddJwtBearer(cfg =>
//                 {
//                     cfg.RequireHttpsMetadata = false;
//                     cfg.TokenValidationParameters = TokenService.GetTokenValidationParameters();
//                 });

// builder.Services.AddAuthorization(cfg =>
//     {
//         cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
//         cfg.AddPolicy("User", policy => policy.RequireClaim("type", "User"));
        
//     }
//     );

// builder.Services.AddControllers();
// builder.Services.AddHttpContextAccessor();
// builder.Services.AddSwaggerGen(opt =>
// {
//     opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
//     opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         In = ParameterLocation.Header,
//         Description = "Please enter JWT with Bearer into field",
//         Name = "Authorization",
//         Type = SecuritySchemeType.ApiKey
//     });

//     opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//     {
//         {
//             new OpenApiSecurityScheme
//             {
//                 Reference = new OpenApiReference
//                 {
//                     Type=ReferenceType.SecurityScheme,
//                     Id="Bearer"
//                 }
//             },
//             new string[]{}
//         }
//     });
// });

// //ClearProviders מידלוואר מובנה
// builder.Logging.ClearProviders();
// //מידלוואר שכותב לקונסול
// builder.Logging.AddConsole();
// var app = builder.Build();

// app.Map("/favicon.ico", (a) =>
//     a.Run(async c => await Task.CompletedTask));

// app.UseMyLogMiddleware();
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// app.UseHttpsRedirection();
// /*js*/
// app.UseDefaultFiles();
// app.UseStaticFiles();
// /*js (remove "launchUrl" from Properties\launchSettings.json*/
// // builder.Services.AddAuthentication()
// //     .AddGoogle(options =>
// //     {
// //         options.ClientId = "640571382877-7i7sdendsk9omjkghvh7gkd3va2oqu3l.apps.googleusercontent.com";
// //         options.ClientSecret = "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";
// //     });
//     builder.Services.AddAuthentication(options =>
// {
//     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddGoogle(options =>
// {
//     options.ClientId = "640571382877-7i7sdendsk9omjkghvh7gkd3va2oqu3l.apps.googleusercontent.com";
//     options.ClientSecret = "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";
// });


// app.UseAuthentication();
// app.UseAuthorization();

// app.MapControllers();

// app.Run();


using project.Utilities;
using project;
using Microsoft.OpenApi.Models;
using project.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTask();
builder.Services.AddUser();
builder.Services.AddLogin();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;})
//     .AddGoogle(options =>
//     {
//        options.ClientId = "640571382877-7i7sdendsk9omjkghvh7gkd3va2oqu3l.apps.googleusercontent.com";
//        options.ClientSecret = "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";
//     }
// )
.AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.TokenValidationParameters = TokenService.GetTokenValidationParameters();
});

builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
    cfg.AddPolicy("User", policy => policy.RequireClaim("type", "User"));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.Map("/favicon.ico", (a) =>
    a.Run(async c => await Task.CompletedTask));

app.UseMyLogMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

// builder.Services.AddAuthentication()
//     .AddGoogle(options =>
//     {
//        options.ClientId = "640571382877-7i7sdendsk9omjkghvh7gkd3va2oqu3l.apps.googleusercontent.com";
//        options.ClientSecret = "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";
//     });

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

