using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Lab4.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));//настройка поставщика бд
});
builder.Services.AddScoped<IContactRepository, ContactRepository>();//сервис создается единожды для каждого запроса

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/notes", async (IContactRepository repository) =>
    Results.Ok(await repository.GetContactsAsync()))
    .Produces<List<Contact>>(StatusCodes.Status200OK)
    .WithName("GetAllContacts")
    .WithTags("Getters");

app.MapGet("/notes/{id}", async (int id, IContactRepository repository) =>
    await repository.GetContactAsync(id) is Contact contact
    ? Results.Ok(contact)
    : Results.NotFound())
    .Produces<Contact>(StatusCodes.Status200OK)
    .WithName("GetContact")
    .WithTags("Getters");

app.MapPost("/notes", async ([FromBody] ContactCreateModel contact, IContactRepository repository) =>
{
    await repository.InsertContactAsync(contact);
    await repository.SaveAsync();
    return Results.NoContent();
})
    .Accepts<ContactCreateModel>("application/json")
    .Produces<Contact>(StatusCodes.Status201Created)
    .WithName("CreateContact")
    .WithTags("Creators");

app.MapPut("/notes", async ([FromBody] Contact contact, IContactRepository repository) => {
    await repository.UpdateContactAsync(contact);
    await repository.SaveAsync();
    return Results.NoContent();
})
    .Accepts<Contact>("application/json")
    .WithName("UpdateContact")
    .WithTags("Updaters");

app.MapDelete("notes/{id}", async (int id, IContactRepository repository) => {
    await repository.DeleteContactAsync(id);
    await repository.SaveAsync();
    return Results.NoContent();
}).WithName("DeleteContact")
    .WithTags("Deleters");

app.MapGet("/contacts/search/name/{query}",
    async (string query, IContactRepository repository) =>
        await repository.GetContactByNameAsync(query) is IEnumerable<Contact> contacts
            ? Results.Ok(contacts)
            : Results.NotFound(Array.Empty<Contact>()))
    .Produces<List<Contact>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("SearchContactByName")
    .WithTags("Getters");

app.MapGet("/contacts/search/surname/{query}",
    async (string query, IContactRepository repository) =>
        await repository.GetContactBySurnameAsync(query) is IEnumerable<Contact> contacts
            ? Results.Ok(contacts)
            : Results.NotFound(Array.Empty<Contact>()))
    .Produces<List<Contact>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("GetContactBySurname")
    .WithTags("Getters");

app.MapGet("/contacts/search/phone/{query}",
    async (string query, IContactRepository repository) =>
        await repository.GetContactByPhoneAsync(query) is IEnumerable<Contact> contacts
            ? Results.Ok(contacts)
            : Results.NotFound(Array.Empty<Contact>()))
    .Produces<List<Contact>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("GetContactByPhone")
    .WithTags("Getters");

app.MapGet("/contacts/search/email/{query}",
    async (string query, IContactRepository repository) =>
        await repository.GetContactByEmailAsync(query) is IEnumerable<Contact> contacts
            ? Results.Ok(contacts)
            : Results.NotFound(Array.Empty<Contact>()))
    .Produces<List<Contact>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("GetContactByEmail")
    .WithTags("Getters");

app.UseHttpsRedirection();

app.Run();
