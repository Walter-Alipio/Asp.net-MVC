using Microsoft.EntityFrameworkCore;
using web2.Pepositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
// AddJsonOptions(options =>
//         {
//           options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//           options.JsonSerializerOptions.PropertyNamingPolicy = null;
//           options.JsonSerializerOptions.IncludeFields = true;
//         });

//add temporary dependencies 
builder.Services.AddTransient<IDataService, DataService>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
builder.Services.AddTransient<ICadastroRepository, CadastroRepository>();

//add session to maintain state 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//connection to db
builder.Services.AddDbContext<ApplicationContext>(opt =>
  opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// automatic database update - ChatGPT
builder.Services.BuildServiceProvider().GetRequiredService<IDataService>().InicializaDB();
//.EnsureCreated();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pedido}/{action=Carrossel}/{codigo?}");

app.Run();
