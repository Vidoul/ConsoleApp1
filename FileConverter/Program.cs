Console.WriteLine("Hello, World!");

Console.WriteLine("Quel est votre recherche ?");
string? recherche = Console.ReadLine();

var allAlbumsText = from line in File.ReadAllLines(@$"{Directory.GetCurrentDirectory()}/Text/Albums.txt")
                    where line.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
                    select line;

foreach (var line in allAlbumsText)
{
    Console.WriteLine(line);
}