using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notes.Standard;
using System.Diagnostics;

namespace Test.Standard;

[TestClass]
public class NoteControllerTest {
    private NoteController _controller = new NoteController();

    [TestMethod]
    public void Add() {
        int count = 1000;

        for (int i = 0; i < count; i++) {
            var result = _controller.Add(new Note(
                "Some title",
                "Some text",
                "Some topic"
                ));
            Assert.AreEqual(i, result.Id);
        }
    }
}
