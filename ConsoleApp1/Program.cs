Console.WriteLine("Hello, World!");

Console.WriteLine("Enter username:");

string userName = Console.ReadLine() ?? "";

bool t1 = true;
string nb1 = "";
string nb2 = "";

foreach (char elt in userName)
{
    if (elt == '+')
    {
        t1 = false;
    }
    else
    {
        if (t1)
        {
            nb1 = nb1 + elt;
        }
        else
        {
            nb2 = nb2 + elt;
        }
    }
}

int a = int.Parse(nb1);
int b = int.Parse(nb2);

Console.WriteLine($"Résultat: {a + b}");
