new CLIController().ReadCommand();


class CLIController {
    public void ReadCommand() {
        var strConstants = TextConstants.CLIStrings;

        while (true) {
            Console.WriteLine(strConstants[CLIStringDescriptors.Hello]);
            Console.WriteLine(strConstants[CLIStringDescriptors.OfferOfChangingLanguage]);
            var val = Console.ReadLine();
            if (val == "en") {
                CLITextValue.CurrentLanguage = Languages.EN;
            }
            if (val == "ru") {
                CLITextValue.CurrentLanguage = Languages.RU;
            }
            Console.Clear();
        }
    }
}


internal enum CLIStringDescriptors {
    Hello,
    OfferOfChangingLanguage,
}

internal static class TextConstants {
    static TextConstants() {
        _strings = new() {
            { CLIStringDescriptors.Hello, new CLITextValue("Привет", "Hello") },
            { CLIStringDescriptors.OfferOfChangingLanguage, new CLITextValue("en - сменить язык", "ru - change language") },
        };
    }

    private static Dictionary<CLIStringDescriptors, CLITextValue> _strings;
    public static IReadOnlyDictionary<CLIStringDescriptors, CLITextValue> CLIStrings => _strings;
}


internal enum Languages {
    RU,
    EN,
    CH
}

internal class CLITextValue {
    public CLITextValue(string ruValue, string enValue) {
        _allStrings = new() {
            { Languages.RU, ruValue },
            { Languages.EN, enValue },
        };
    }

    // все значения строчки под каждый язык
    private Dictionary<Languages, string> _allStrings;

    // текущий язык
    public static Languages CurrentLanguage { get; set; } = Languages.RU; // default value :-)

    protected string CurrentValue => _allStrings[CurrentLanguage];

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
}