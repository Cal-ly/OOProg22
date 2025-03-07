namespace CrossTalk;

public static class Reciter
{
    private readonly static Random _rng = new();

    /// <summary>
    /// Recites a set of lists of words.
    /// </summary>
    public static Task ReciteAllTheWords()
    {
        string[] danish = ["En", "To", "Tre", "Fire", "Fem", "Seks", "Syv", "Otte"];
        string[] english = ["One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight"];
        string[] german = ["Eins", "Zwei", "Drei", "Vier", "Funf", "Sechs", "Sieben", "Acht"];

        // Wrap each call of Recite into a separate Task object.
        Task t1 = Task.Run(() => Recite(danish));
        Task t2 = Task.Run(() => Recite(english));
        Task t3 = Task.Run(() => Recite(german));

        return Task.WhenAll(t1, t2, t3);
    }

    /// <summary>
    /// Recites (i.e. prints on screen with a bit of delay
    /// between each line) the provided list of strings.
    /// </summary>
    public static void Recite(string[] words)
    {
        foreach (string s in words)
        {
            Console.WriteLine(s);
            Thread.Sleep(_rng.Next(1000) + 50);
        }
    }
}
