using C_Sharp_TranslateCUI;

class Program {

    public static void Main(String[] args) {
        DeeplTranslateAPI deepl = DeeplTranslateAPI.GetAPI("I'm mochineko.");
        Console.WriteLine(deepl.translations[0].text);
    }
}