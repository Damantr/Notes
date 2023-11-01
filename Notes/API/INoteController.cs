using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.API; 

public interface INoteController {
    IReadOnlyList<INote> Notes { get; }

    INote Add(INote note);
    INote Remove(INote note);
    INote Update(INote note);
    INote Delete(INote note);
    INote GetById(int id);
}
