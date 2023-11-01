using Notes.API;

namespace Notes;

// я педик 

public class NoteController : INoteController {
    public IReadOnlyList<INote> Notes => throw new NotImplementedException();

    public INote Add() {
        
    }

    public INote Delete() {
        throw new NotImplementedException();
    }

    public INote GetById(int id) {
        throw new NotImplementedException();
    }

    public INote Update() {
        throw new NotImplementedException();
    }
}