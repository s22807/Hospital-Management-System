using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseDeveloperExceptionPage();
//app.UseExceptionHandler("/Home/Error");


app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


/*
 * 
 * Program.cs jest jedynie konstrukcj¹ uruchamiaj¹c¹ aplikacjê webow¹ WebApplication.
 * Wszystkie modele (obiekty) zdefiniowane s¹ w HospitalManagementSystem.Domain.Models.*
 * Wszystkie serwisy (logika biznesowa) zdefiniowane s¹ w HospitalManagementSystem.Application.Services.*
 * Repozytoria (logika dostêpu do danych) zdefiniowane s¹ w HospitalManagementSystem.Infrastructure.Repository.*
 * Trwa³oœæ wszystkich ekstensji zapewniona jest poprzez HospitalManagementSystem.Infrastructure.ApplicationDbContext
 * 
 * 
 * MP1
 * Ekstensja
 * Ekstensja - trwa³oœæ
 * Atrybut z³o¿ony
 * Atrybut opcjonalny
 * Atrybut powtarzalny
 * Atrybut klasowy
 * Atrybut pochodny
 * Metoda klasowa
 * Przes³oniêcie
 * Przeci¹¿enie
 * 
 * MP2
 * Binarna
 * Z atrybutem
 * Kwalifikowana
 * Kompozycja
 * 
 * MP3
 * Disjoint
 * Klasa abstrakcyjna
 * Polimorficzne wo³anie metody
 * Overlapping
 * Wielodziedziczenie
 * Wieloaspektowe
 * Dynamiczne
 * 
 * MP4
 * Atrybutów
 * Unique
 * Subset
 * Ordered
 * Bag
 * Xor
 * Ograniczenie W³asne
 * 
 * MP5
 * MR - klasy
 * MR - asocjacje (licznoœci 1:* lub *:*)
 * MR - dziedziczenie
 * 
 * 
 * Jak to dzia³a?
 * Opis
 * 
 * 
 * 
 * 
 * 
kolejnosc tworzenia
model
irepo
repo
service
dto
controller
extensionsx2
viewsxgodknowshowmany
 * 
 * 
 */




















