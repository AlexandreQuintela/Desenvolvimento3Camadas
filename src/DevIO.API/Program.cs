try
{
    var builder = WebApplication.CreateBuilder(args);
    SerilogExtension.AddSerilogApi(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);
    Log.Information("Iniciando API");
    //builder.Services.AddControllers();

    // Exexmplo para ignorar verificação padrao do modelstate e deixar por nossa conta
    builder.Services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressModelStateInvalidFilter = true;
                    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<MeuDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Pelo assemblies ele vai procurar todos os profiles

    builder.Services.ResolveDependencies();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host foi encerrado inesperadamente");
}
finally
{
    Log.Information("Aplicação API finalizada...");
    Log.CloseAndFlush();
}