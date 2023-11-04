namespace Notes.API;

public interface INoteController {
    IReadOnlyList<INote> Notes { get; }
    
    INote Add(INote note);
    INote? Remove(INote note);

    bool IsExist(int id);
    bool GetById(int id, out INote? result);
}
