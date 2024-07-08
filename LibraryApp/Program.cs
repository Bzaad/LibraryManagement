using Plugins.DataStore.InMemory;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;
using UseCases.TransactionUseCases;
using UseCases.BooksUseCases;
using Plugins.DataStore.SQL;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryManagement"));
});

builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryManagement"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
    builder.Services.AddSingleton<IBookRepository, BooksInMemoryRepository>();
    builder.Services.AddSingleton<ITransactionRepository, TransactionsInMemoryRepository>();
}
else
{
    builder.Services.AddTransient<ICategoryRepository, CategorySQLRepository>();
    builder.Services.AddTransient<IBookRepository, BookSQLRepository>();
    builder.Services.AddTransient<ITransactionRepository, TransactionSQLRepository>();
}

builder.Services.AddTransient<IViewCategoriesUseCases, ViewCategoriesUseCases>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();

builder.Services.AddTransient<IAddTransactionUseCase, AddTransactionUseCase>();
builder.Services.AddTransient<IGetByDateBorrowedAndUserUseCase, GetByDateBorrowedAndUserUseCase>();
builder.Services.AddTransient<ISearchTransactionUseCase, SearchTransactionUseCase>();

builder.Services.AddTransient<IAddBookUseCase, AddBookUseCase>();
builder.Services.AddTransient<IDeleteBookUseCase, DeleteBookUseCase>();
builder.Services.AddTransient<IGetBooksByCategoryUseCase, GetBooksByCategoryUseCase>();
builder.Services.AddTransient<IGetBooksUseCase, GetBooksUseCase>();
builder.Services.AddTransient<IGetSingleBookUseCase, GetSingleBookUseCase>();
builder.Services.AddTransient<IUpdateBookUseCase, UpdateBookUseCase>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();