Combobox binding foreign key
https://stackoverflow.com/questions/20509957/how-to-bind-a-combobox-with-foreign-key-in-wpf-mvvm
https://docs.telerik.com/devtools/wpf/controls/radcombobox/features/selection

---------------------------------------------------------------------------
- SQL software laden  (Let op sqlLite zet de database gewoon in een folder)
---------------------------------------------------------------------------
Tabellen of bestanden maken
1, Connection class en zelf bouwen
2. Entity Framework 6
3. Entity Framework Core (is de laatste)


>Menu Tools
>Nu het package manager
>Package manager console
Op het prompt kun je commando's intoetsen. Het volgende commanda laad het Entity Framework in je applciatie.
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer


In plaats hiervan kun je ook een inmemory optie of de sqlserver gebruiken:
PM> Install-Package Microsoft.EntityFrameworkCore.Sqlite
PM> Install-Package Microsoft.EntityFrameworkCore.Inmemory

---------------------------------------------------------------------------
- creeren van een model
---------------------------------------------------------------------------
Een model is een class dat een object (klant, order e.d.) beschrijft. Al deze gegevens wil je opslaan.
Entity Framework core vereist dat je deze objecten in een Context class zet zodat het weet wat het moet doen.
Er zijn minimaal 2 vereisten:
- een context (deze bevat de tabellen en de naam van de database)
- de tabellen die je wilt opslaan (minimaal 1)

Nadat je dit gemaakt hebt moet je de tabellen maken 


---------------------------------------------------------------------------
- creeren van een database         SQLite
---------------------------------------------------------------------------
Initieel de software laden
>Menu Tools
>Nu het package manager
>Package manager console
PM> Install-Package Microsoft.EntityFrameworkCore.Tools

---------------------------------------------------------------------------
- Database voorzien van de laatste tabellen
---------------------------------------------------------------------------

En vervolgens bij elke update van de tabellen
>Menu Tools
>Nu het package manager
>Package manager console
PM> get-help NuGet    (bij vragen)

PM> Add-Migration  InitialCreate -Context  MyContext
PM> Update-Database -c MyContext

Daarna
PM>Add-Migration
PM> Update-Database -c MyContext


insert into [WpfStefEFC].[dbo].speler values('Speler1','s1','w1','1')
insert into [WpfStefEFC].[dbo].speler values('Speler2','s2','w2','1')
insert into [WpfStefEFC].[dbo].speler values('Speler3','s3','w3','1')
insert into [WpfStefEFC].[dbo].speler values('Speler4','s4','w4','1')
insert into [WpfStefEFC].[dbo].speler values('Speler5','s5','w5','1')
insert into [WpfStefEFC].[dbo].speler values('Speler6','s6','w6','0')
insert into [WpfStefEFC].[dbo].speler values('Speler7','s7','w7','0')

insert into [WpfStefEFC].[dbo].coach values('Coach1','Harry','1')
insert into [WpfStefEFC].[dbo].coach values('Coach2','Roel','1')
insert into [WpfStefEFC].[dbo].coach values('Coach3','Tia','1')
insert into [WpfStefEFC].[dbo].coach values('Coach4','v4','1')

insert into [WpfStefEFC].[dbo].[Team]values('t1','Tennis',2,1,2)
insert into [WpfStefEFC].[dbo].[Team]values('t2','Schaken',2,2,3)
insert into [WpfStefEFC].[dbo].[Team]values('t3','Vissen',3,3,4)
insert into [WpfStefEFC].[dbo].[Team]values('t4','Hardlopen',2,4,5)

---------------------------------------------------------------------------
-- Modelling
---------------------------------------------------------------------------
https://docs.microsoft.com/en-us/ef/core/modeling/
Definieer je eigen object (lees tabellen)

Relaties tussen tabellen (1:1, 1:N, N:M)
https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key

Statusveld conversie, of ook enum conversie
https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions

---------------------------------------------------------------------------
-- Database connectie maken
---------------------------------------------------------------------------

  public class MyContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=WindowsFormsApp3;trusted_connection=true;Integrated Security=True;");
            //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.Url)
                .IsUnique();
        }

    }
---------------------------------------------------------------------------
-- Ouderwetse database connectie maken
---------------------------------------------------------------------------        
        SqlDataReader rdr = null;
        SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from Customers", conn);
        rdr = cmd.ExecuteReader();
        
        conn.Close();


---------------------------------------------------------------------------
-- Controle numerieke invoer
---------------------------------------------------------------------------
 //string input = KeyComboFld.Text;
            //if (string.IsNullOrEmpty(input)) input = "0";
            //Boolean isNumeric = Regex.IsMatch(input, @"^\d+$");
            //KeyId = 0;
            //if (!isNumeric)
            //{
            //    MessageBox.Show("Veld niet numeriek, invoer stopt", "Invoer", MessageBoxButtons.OK);
            //    return false;
            //}
            // KeyId = Int32.Parse(input);



get-help NuGet
PM> Add-Migration  InitialCreate -Context  MyContext
PM> Update-Database -c MyContext



USE [WindowsFormsApp3]
drop table team
drop table Speler
drop table Posts
drop table Coach
drop table Blogs
drop table __EFMigrationsHistory

USE [WindowsFormsApp3]
drop table team
drop table Speler
drop table Posts
drop table Coach
drop table Blogs
drop table reviews
drop table users
drop table __EFMigrationsHistory

insert into Speler (naam) values('ik1')
insert into Speler (naam) values('ik2')
insert into Speler (naam) values('ik3')

insert into Coach  (Voornaam, naam, Active) values ('Roel', 'De Lange1', 1)
insert into Coach  (Voornaam, naam, Active) values ('Desiree', 'De Lange2', 1)
insert into Coach  (Voornaam, naam, Active) values ('Wesley', 'De Lange3', 1)
insert into Coach  (Voornaam, naam, Active) values ('Stefan', 'De Lange4', 1)


---------------------------------------------------------------------------
-- Foutcontrole strategie                       
---------------------------------------------------------------------------
Idee:

- Start save in scherm

- Vervolgens save in 
  try:  save in controller
  catch toon fouten

---------------------------------------------------------------------------
-- Binding                     
---------------------------------------------------------------------------
{Binding}                       Current DataContext
{Binding Path=NameOfProperty}   default path of binding
{Binding propertyNameOfProperty}
{Binding Path=Text, ElementName=txtValue}  

---------------------------------------------------------------------------
-- SqlIte                     
---------------------------------------------------------------------------

SqlLite
NuGet  UWPSQLITEEFCORE.SLN
of zoeken naar SQLITE download
of https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite

https://www.sqlite.org/index.html
https://www.sqlite.org/matrix/download.html
---------------------------------------------------------------------------
-- StringFormat                     
---------------------------------------------------------------------------
C=Currency
D=Decimal
    value = 12345;
    Console.WriteLine(value.ToString("D"));
    // Displays 12345
    Console.WriteLine(value.ToString("D8"));
    // Displays 00012345
    decimal.ToString("D", CultureInfo.InvariantCulture)

string a = ("Format Decimal: {0:n2}", num);

//Add in   NuGet   Microsoft.UI.Xaml.Controls   for amount fields

// 
System.Windows.Controls.AlternationConverter
System.Windows.Controls.BooleanToVisibilityConverter
System.Windows.Documents.ZoomPercentageConverter
System.Windows.Navigation.JournalEntryListConverter

Xceed.Wpf.DataGrid.Converters.CurrencyConverter
Xceed.Wpf.DataGrid.Converters.DateTimeToStringConverter
Xceed.Wpf.DataGrid.Converters.GreaterThanZeroConverter
Xceed.Wpf.DataGrid.Converters.IndexToOddConverter
Xceed.Wpf.DataGrid.Converters.IntAdditionConverter
Xceed.Wpf.DataGrid.Converters.InverseBooleanConverter
Xceed.Wpf.DataGrid.Converters.LevelToOpacityConverter
Xceed.Wpf.DataGrid.Converters.MultimodalResultConverter
Xceed.Wpf.DataGrid.Converters.NegativeDoubleConverter
Xceed.Wpf.DataGrid.Converters.NullToBooleanConverter
Xceed.Wpf.DataGrid.Converters.SourceDataConverter
Xceed.Wpf.DataGrid.Converters.StringFormatConverter
Xceed.Wpf.DataGrid.Converters.ThicknessConverter
Xceed.Wpf.DataGrid.Converters.TypeToBooleanConverter
Xceed.Wpf.DataGrid.Converters.TypeToVisibilityConverter
Xceed.Wpf.DataGrid.Converters.ValueToMaskedTextConverter


// Amount veld.
Set culture:
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
    CultureInfo nlNLs = new CultureInfo("nl-NL");
// Make TextBox, zorg dat bij focus heel het veld geselecteerd word.
        private void Price44_GotFocus(object sender, RoutedEventArgs e)
        {
            Price44.SelectAll(); 
        }
// Defineer veld in WXAML
        <TextBox TextAlignment="Right" Grid.Row="4" Grid.Column="1" Width="200" Height="35" Name="Price44"
                 Text="{Binding Price4, StringFormat=n,  
                                        Mode=TwoWay                                          
                 }" FontSize="16" Background="#FF6EF279" PreviewTextInput="TextBox_PreviewTextInput" GotFocus="Price44_GotFocus"  />
// Bovenstaand veld is altijd met 2 decimalen door de StringFormat=n en kan ook negatieve getallen aan
// Bijzonder is dat bij mij de punt op het toetsenbord ook werkte als komma
// en dat een 2.245 ook afgerond wordt als 2.25

// StringFormat=n1 is 1 decimal, n4 is 4 decimalen
/  Super dus!

// Bedrag afronden
decimal a = 1.994444M;
Math.Round(a, 2); //returns 1.99


Regex moneyR = new Regex(@"\$\d+\.\d{2}");
        string[] money = new string[] { "$0.99", 
                                        "$1099999.00", 
                                        "$10.25", 
                                        "$90,999.99", 
                                        "$1,990,999.99", 
                                        "$1,999999.99" };
        foreach (string m in money){
            Console.WriteLine(m);
            Console.WriteLine(moneyR.IsMatch(m));
        }

// Indien je de decimal wilt controleren op aantal cijfers voor en na de punt of komma
Regex.IsMatch(strInput, @"[\d]{1,4}([.,][\d]{1,2})?");
and explain:

[\d]{1,4}    any character of: digits (0-9) between 1 and 4 times

[.,]         any character of: '.', ','

[\d]{1,2}    any character of: digits (0-9) between 1 and 2 times

(...)?       match the expression or not (zero or one)



//==================================
// https://executecommands.com/crud-operations-in-wpf-efcore-sqlite-net-core/  ef en wpf example
