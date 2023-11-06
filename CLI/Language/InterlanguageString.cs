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

namespace CLI.Language;

internal enum Languages {
    RU,
    EN,
}

// идентификаторы для строчек по которым мы получаем строчку на нужном языке.
internal enum CLIStringDescriptors {
    Hello,
    OfferOfChangingLanguage,
}

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

// наши строчки
internal static class TextConstants {
    private static Dictionary<CLIStringDescriptors, InterlanguageString> _strings;

    static TextConstants() {
        _strings = new() {
            { CLIStringDescriptors.Hello, new InterlanguageString(
                ruValue: "Привет", 
                enValue: "Hello") 
            },
            { CLIStringDescriptors.OfferOfChangingLanguage, new InterlanguageString(
                ruValue: "en - сменить язык", 
                enValue: "ru - change language") 
            },
        };
    }

    public static IReadOnlyDictionary<CLIStringDescriptors, InterlanguageString> CLIStrings => _strings;
}
