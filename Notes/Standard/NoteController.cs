using Notes.API;

namespace Notes.Standard;

public class NoteController : INoteController {
    // все текущие заметки.
    private readonly List<INote> _notes = new List<INote>();

    public NoteController() {
        
    }

    /// <summary>
    /// Current existing notes.
    /// </summary>
    public IReadOnlyList<INote> Notes => _notes;

    /// <summary>
    /// Adds note.
    /// </summary>
    /// <param name="note">Addable note.</param>
    /// <returns>Added note.</returns>
    public INote Add(INote note) {
        _notes.Add(note);
        return note;
    }

    /// <summary>
    /// Gets note by id to result.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="result">Result. If note was not found result будет налл я не ебу как это перевести блять.</param>
    /// <returns>True, if result is not null, otherwise false.</returns>
    public bool GetById(int id, out INote? result) {
        foreach (INote note in _notes) {
            if (note.Id == id) {
                result = note;
                return true;
            }
        }
        result = null;
        return false;
    }

    /// <summary>
    /// Removes note.
    /// </summary>
    /// <param name="note">Removing note.</param>
    /// <returns>Removed note.</returns>
    public INote? Remove(INote note) {
        _notes.Remove(note);
        return note;
    }

    /// <summary>
    /// хуле тут не понятно
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool IsExist(int id) {
        return GetById(id, out INote? _);
    }
}
