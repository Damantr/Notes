using Notes.API;
using System.Text;

namespace Notes.Standard;

public class Note : INote {
    private readonly int _id;
    private string _title;
    private string _text;
    private string? _topic;

    /// <summary>
    /// Makes new note with cool title, interesting text and some topic.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <param name="topic"></param>
    public Note(string title, string text, string? topic = null) {
        _id = IdCounter++;

        _title = title;
        _text = text;
        _topic = topic;
    }

    /// <summary>
    /// Unique id for a next note.
    /// </summary>
    protected static int IdCounter { get; private set; } = 0;

    /// <summary>
    /// Unique identifier for this note.
    /// </summary>
    public int Id => _id;

    /// <summary>
    /// Note title.
    /// </summary>
    public string Title => _title;

    /// <summary>
    /// Note text.
    /// </summary>
    public string Text => _text;
    
    /// <summary>
    /// Note topic.
    /// </summary>
    public string? Topic => _topic;

    public override string? ToString() {
        StringBuilder sb = new StringBuilder();
        sb.Append(
            $"[Id]:\t\t{Id}\n" +
            $"[Title]:\t{Title}\n" +
            $"[Text]:\t\t{Text}\n"
        );

        if (Topic != null) {
            sb.Append($"[Topic]:\t\t{Topic}\n");
        }

        return sb.ToString();
    }
}
