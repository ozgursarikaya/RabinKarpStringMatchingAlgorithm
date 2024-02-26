using RabinKarpStringMatchingAlgorithm;

string text = "abracadabra";
string pattern = "abr";
List<int> positions = RabinKarp.Search(text, pattern);

if (positions.Count == 0)
    Console.WriteLine("Pattern bulunamadı");
else
{
    Console.Write("Pattern pozisyonu: ");
    foreach (int pos in positions)
    {
        Console.Write(pos + " ");
    }
}

Console.ReadLine();