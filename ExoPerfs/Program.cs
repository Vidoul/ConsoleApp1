using System.Diagnostics;

Console.WriteLine("Calcul de performance. ");

var sw = Stopwatch.StartNew();
double sum = 1;
// on exécute 50 millions de calculs
Parallel.For(0, 50_000_000, i =>
{
    //cosinus
    sum += Math.Sin(i) + Math.Cos(i);

    //Racine carrée
    sum += Math.Sqrt(i);

    //Exp + Log
    sum += Math.Exp(i) + Math.Log(i + 1);

    //puissance
    sum += Math.Pow(i % 100, 3);

    //Multiplication rule
    sum += 1.0000001;

});

sw.Stop();

Console.WriteLine($"Calculated in {sw.ElapsedMilliseconds} ms");