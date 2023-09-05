namespace Knockout
{
    internal class Program
    {
        static Tuple<Competitor, Competitor> DrawCompetitors(List<Competitor> competitors)
        {
            var random = new Random();
            var index1 = random.Next(0, competitors.Count);
            var index2 = random.Next(0, competitors.Count);

            while (index1 == index2)
            {
                // Make sure the two competitors are not the same
                index2 = random.Next(0, competitors.Count);
            }

            var competitor1 = competitors[index1];
            var competitor2 = competitors[index2];

            // Remove the drawn competitors from the list
            competitors.RemoveAt(index1);
            if (index1 < index2)
            {
                // If the first competitor was removed, adjust the index
                index2--;
            }
            competitors.RemoveAt(index2);

            return Tuple.Create(competitor1, competitor2);
        }

        static void Main(string[] args)
        {
            var competitors = new List<Competitor>();

            Console.WriteLine("Enter the names of contestants (press Enter to finish):");
            while (true)
            {
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                    break;

                competitors.Add(new Competitor(name));
            }

            if (competitors.Count < 2)
            {
                Console.WriteLine("At least two contestants are required for a draw.");
                return;
            }

            while (competitors.Count >= 2)
            {
                var pair = DrawCompetitors(competitors);
                Console.WriteLine($"{pair.Item1.GetName()} vs {pair.Item2.GetName()}");
            }

            if (competitors.Count == 1)
            {
                Console.WriteLine($"{competitors[0].GetName()} has a bye");
            }
        }
    }
}