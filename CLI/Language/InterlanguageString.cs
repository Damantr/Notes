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

// идентификаторы для строчек по которым мы получаем строчку на нужном языке.
internal enum CLIStringDescriptors {
    DescriptionForAddNoteName,
    DescriptionForAddNoteText,
    AddableNoteNullErrorMessage,
    NoteHasBeenAddedSuccess,
}

// наши строчки
internal static class TextConstants {
    private static Dictionary<CLIStringDescriptors, InterlanguageString> _strings;

    static TextConstants() {
        _strings = new() {
            { CLIStringDescriptors.DescriptionForAddNoteName, new InterlanguageString(
                ruValue: "Название заметки >>> ", 
                enValue: "Note name >>> ") 
            },

            { CLIStringDescriptors.DescriptionForAddNoteText, new InterlanguageString(
                ruValue: "Текст заметки: ",
                enValue: "Note text: ")
            },

            { CLIStringDescriptors.AddableNoteNullErrorMessage, new InterlanguageString(
                ruValue: "Имя или текст заметки отсутствует. Заметка не добавлена.",
                enValue: "Message name or text has not add. Note isn't added.")
            },

            { CLIStringDescriptors.NoteHasBeenAddedSuccess, new InterlanguageString(
                ruValue: "Заметка была успешно добавлена.",
                enValue: "Note has been added success.")
            },
        };
    }

    public static IReadOnlyDictionary<CLIStringDescriptors, InterlanguageString> CLIStrings => _strings;
}
