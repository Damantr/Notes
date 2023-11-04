new CLIController().ReadCommand();

/*
 *                       *--------------------*
 *                      /|  _____я на кубике /|
 *                     / |  |0 0|           / |
 *                    /  |  \_-_/          /  |
 *                   /   |   /|\          /   |
 *                  /    |  / | \        /    |
 *                 /     |   *-*        /     |
 *                /      |  / /        /      |
 *               *-------+-/-/--------*-------|
 *               |       * | |        |       *
 *               |      /  | |        |      /
 *               |     /              |     /
 *               |    /               |    /
 *  очко         |   /                |   /
 *               |  /                 |  /
 *               | /                  | /
 *               |/                   |/
 *               *--------------------*
 */              



// тут еще ниче не сделали 
internal class CLIController {
    public void ReadCommand() {
        var strConstants = TextConstants.CLIStrings;

        while (true) { //вівод команд
            Console.WriteLine(strConstants[CLIStringDescriptors.Hello]);
            Console.WriteLine(strConstants[CLIStringDescriptors.OfferOfChangingLanguage]);

            var val = Console.ReadLine();
            if (val == "en") {
                InterlanguageString.CurrentLanguage = Languages.EN;
            }
            if (val == "ru") {
                InterlanguageString.CurrentLanguage = Languages.RU;
            }
            Console.Clear();
        }
    }
}

// идентификаторы для строчек по которым мы получаем строчку на нужном языке
internal enum CLIStringDescriptors {
    Hello,
    OfferOfChangingLanguage,
}

// наши строчки
internal static class TextConstants {
    static TextConstants() {
        _strings = new() {
            { CLIStringDescriptors.Hello, new InterlanguageString("Привет", "Hello") },
            { CLIStringDescriptors.OfferOfChangingLanguage, new InterlanguageString("en - сменить язык", "ru - change language") },
        };
    }

    private static Dictionary<CLIStringDescriptors, InterlanguageString> _strings;
    public static IReadOnlyDictionary<CLIStringDescriptors, InterlanguageString> CLIStrings => _strings;
}

// какие у нас есть языки
internal enum Languages {
    RU,
    EN,
}

// как обычная строчка, только она переводится на выбранный язык
internal class InterlanguageString {
    public InterlanguageString(string ruValue, string enValue) {
        _allStrings = new() {
            { Languages.RU, ruValue },
            { Languages.EN, enValue },
        };
    }

    // все значения надписи под каждый язык
    private Dictionary<Languages, string> _allStrings;

    // текущий язык
    public static Languages CurrentLanguage { get; set; } = Languages.RU; // default value :-)

    // надпись на текущем языке
    protected string CurrentValue => _allStrings[CurrentLanguage];

    // этот метод используется в writeline
    public override string? ToString() {
        switch (CurrentLanguage) {
            case Languages.RU:
                return _allStrings[Languages.RU];
            case Languages.EN:
                return _allStrings[Languages.EN];
            default:
                break;
        }

        return null;
    }

    // хихи хаха 
    public static implicit operator string(InterlanguageString val) {
        return val.CurrentValue;
    }
}