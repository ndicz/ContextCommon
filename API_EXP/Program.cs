using R_APIStartUp;

var loBuilder = WebApplication.CreateBuilder(args);
loBuilder
    .R_RegisterServices(builder =>
    {
        builder.R_DisableAuthentication();
        //builder.R_DisableSwagger();
        //builder.R_DisableGlobalException();
        //builder.R_DisableContext();
        builder.R_DisableDatabase();
    })
    .Build()
    .R_SetupMiddleware()
    .Run();





// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
//
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();
