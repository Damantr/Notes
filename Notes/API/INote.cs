namespace Notes.API; 

public interface INote {
    public int Id { get; }
    public string Title { get; }
    public string Text { get; }
    public string Topic { get; }
}
