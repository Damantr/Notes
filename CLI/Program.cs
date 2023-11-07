using CLI;
using CLI.Language;
using Notes.Standard;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Notes.API;

var cmndStrings = TextConstants.CLIStrings;

var cliController = new CLIController();
var noteController = new NoteController();

var commands = new List<CustomCommand> {
    new CustomCommand(AddNote, "/addnt"),
    new CustomCommand(GetAllNotes, "/getallnt"),
    //TODO:
    //new CustomCommand(AddNote, "/getnt"),
    //new CustomCommand(AddNote, "/findnt"),
    //new CustomCommand(AddNote, "/deletent"),
    //new CustomCommand(AddNote, "/exit"),
    //new CustomCommand(AddNote, "/cancel"),
};

cliController.Inject(commands);

cliController.ReadCommands();

void GetAllNotes() {
    foreach (var n in noteController.Notes) {
        if (n is Note note) {
            Console.WriteLine(note.ToString());
        }
        else {
            Console.WriteLine(_localToString(n));
        }
    }

    string? _localToString(INote? note) {
        if (note == null) {
            return null;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(
            $"---------------------------------\n" + 
            $"[Id]:\t\t| {note.Id}\n" +
            $"[Title]:\t| {note.Title}\n" +
            $"[Text]:\t\t| {note.Text}\n"
        );

        if (note.Topic != null) {
            sb.Append($"[Topic]:\t\t| {note.Topic}\n");
        }

        return sb.ToString();
    }
}

void AddNote() {
    Console.Write(cmndStrings[CLIStringDescriptors.DescriptionForAddNoteName]);
    var noteName = Console.ReadLine();

    Console.Write(cmndStrings[CLIStringDescriptors.DescriptionForAddNoteText]);
    var noteTextSB = new StringBuilder();
    string? userEnter = string.Empty;
    Console.WriteLine("\n");
    do {
        noteTextSB.AppendLine(userEnter);
        Console.Write("\t\t");
        userEnter = Console.ReadLine();
    } while (userEnter != string.Empty);

    var noteText = noteTextSB.ToString();

    if (noteText == null || noteName == null) {
        Console.WriteLine(cmndStrings[CLIStringDescriptors.AddableNoteNullErrorMessage]);
        return;
    }

    noteController.Add(new Note(noteName, noteText));
    Console.WriteLine(cmndStrings[CLIStringDescriptors.NoteHasBeenAddedSuccess]);
}
