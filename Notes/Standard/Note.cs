using Notes.API;

namespace Notes.Standard;

public class Note : INote {
    private readonly int _id;
    private string _title;
    private string _text;
    private string _topic;

    /// <summary>
    /// Makes new note with cool title, interesting text and some topic.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <param name="topic"></param>
    public Note(string title, string text, string topic) {
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
    public string Topic => _topic;
}
