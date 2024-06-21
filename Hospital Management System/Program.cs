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
 * Program.cs jest jedynie konstrukcj� uruchamiaj�c� aplikacj� webow� WebApplication.
 * Wszystkie modele (obiekty) zdefiniowane s� w HospitalManagementSystem.Domain.Models.*
 * Wszystkie serwisy (logika biznesowa) zdefiniowane s� w HospitalManagementSystem.Application.Services.*
 * Repozytoria (logika dost�pu do danych) zdefiniowane s� w HospitalManagementSystem.Infrastructure.Repository.*
 * Trwa�o�� wszystkich ekstensji zapewniona jest poprzez HospitalManagementSystem.Infrastructure.ApplicationDbContext
 * 
 * 
 * MP1
 * Ekstensja
 * Ekstensja - trwa�o��
 * Atrybut z�o�ony
 * Atrybut opcjonalny
 * Atrybut powtarzalny
 * Atrybut klasowy
 * Atrybut pochodny
 * Metoda klasowa
 * Przes�oni�cie
 * Przeci��enie
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
 * Polimorficzne wo�anie metody
 * Overlapping
 * Wielodziedziczenie
 * Wieloaspektowe
 * Dynamiczne
 * 
 * MP4
 * Atrybut�w
 * Unique
 * Subset
 * Ordered
 * Bag
 * Xor
 * Ograniczenie W�asne
 * 
 * MP5
 * MR - klasy
 * MR - asocjacje (liczno�ci 1:* lub *:*)
 * MR - dziedziczenie
 * 
 * 
 * Jak to dzia�a?
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




















