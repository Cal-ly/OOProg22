Console.WriteLine("Running...\n");
ReciteAllTheWords()
    .ContinueWith(_ => StopProgram())
    .Wait();

Task ReciteAllTheWords()
{
    Random ranNum = new();
    string[] danish = ["En", "To", "Tre", "Fire", "Fem", "Seks", "Syv", "Otte"];
    string[] english = ["One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight"];
    string[] german = ["Eins", "Zwei", "Drei", "Vier", "Funf", "Sechs", "Sieben", "Acht"];

    // Wrap each call of Recite into a separate Task object.
    Task t1 = Task.Run(() => Recite(danish, ranNum));
    Task t2 = Task.Run(() => Recite(english, ranNum));
    Task t3 = Task.Run(() => Recite(german, ranNum));

    return Task.WhenAll(t1, t2, t3);
}

void Recite(string[] words, Random randomNum)
{
    foreach (string s in words)
    {
        Console.WriteLine(s);
        Thread.Sleep(randomNum.Next(1000) + 50);
    }
}

void StopProgram()
{
    Console.WriteLine("Reciting Completed (press any key to close App)...");
    Console.ReadLine();
}