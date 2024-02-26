namespace RabinKarpStringMatchingAlgorithm
{
    public class RabinKarp
    {
        public static List<int> Search(string text, string pattern)
        {
            List<int> positions = new List<int>();
            int n = text.Length;
            int m = pattern.Length;

            const int prime = 101; // Asal sayı
            const int d = 256; // Karakter sayısı

            int h = 1;
            int p = 0; // pattern hash
            int t = 0; // text hash

            // h = d^(m-1) % prime
            for (int i = 0; i < m - 1; i++)
                h = (h * d) % prime;

            for (int i = 0; i < m; i++)
            {
                p = (d * p + pattern[i]) % prime;
                t = (d * t + text[i]) % prime;
            }

            for (int i = 0; i <= n - m; i++)
            {

                if (p == t)
                {
                    bool match = true;
                    for (int j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                        positions.Add(i);
                }

                if (i < n - m)
                {
                    t = (d * (t - text[i] * h) + text[i + m]) % prime;
                    if (t < 0) 
                        t += prime;
                }
            }

            return positions;
        }
    }
}
