using MementoTextEditor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class HistoryCaretakerTest
    {
        [TestMethod]
        public void TestUndoShouldRevertToPreviousStateNotEmpty()
        {
            HistoryCaretaker history = new();

            string initialText = "Hello";
            TextEditor editor = new();

            editor.SetText(initialText);
            history.SaveState(editor);

            Assert.AreEqual( initialText , editor.GetText() );

            string finalText = "World";
            editor.SetText(finalText);
            history.SaveState( editor );

            Assert.AreEqual(initialText + " " + finalText, editor.GetText());

            bool canBeUndone = history.Undo( editor );

            Assert.IsTrue( canBeUndone );
            Assert.AreEqual(initialText, editor.GetText() );
        }

        [TestMethod]
        public void TestUndoShouldRevertToPreviousStateEmpty()
        {
            HistoryCaretaker history = new();

            string initialText = "Hello";
            TextEditor editor = new();

            editor.SetText(initialText);
            history.SaveState(editor);

            Assert.AreEqual( initialText , editor.GetText() );

            bool canBeUndone = history.Undo( editor );

            Assert.IsTrue( canBeUndone );
            Assert.AreEqual(string.Empty, editor.GetText() );
        }

        [TestMethod]
        public void TestUndoNoPreviousState()
        {
            HistoryCaretaker history = new();
            TextEditor editor = new();

            bool canBeUndone = history.Undo( editor );
            Assert.IsFalse( canBeUndone );
        }

        [TestMethod]
        public void TestRedoShouldGoToNextState()
        {
            HistoryCaretaker history = new();
            TextEditor editor = new();

            string initialText = "Hello";
            editor.SetText( initialText );
            history.SaveState( editor );
            Assert.AreEqual( initialText , editor.GetText() );

            string finalText = "World";
            editor.SetText( finalText );
            history.SaveState( editor );
            Assert.AreEqual( "Hello World" , editor.GetText() );

            history.Undo( editor );

            bool canBeRedone = history.Redo( editor );
            Assert.IsTrue( canBeRedone );
            Assert.AreEqual( "Hello World" , editor.GetText() );
        }
        
        [TestMethod]
        public void TestRedoNoNextState()
        {
            HistoryCaretaker history = new();
            TextEditor editor = new();

            string initialText = "Hello";
            editor.SetText( initialText );
            history.SaveState( editor );
            Assert.AreEqual( initialText , editor.GetText() );

            string finalText = "World";
            editor.SetText( finalText );
            history.SaveState( editor );
            Assert.AreEqual( "Hello World" , editor.GetText() );

            bool canBeRedone = history.Redo( editor );

            Assert.IsFalse( canBeRedone );
            Assert.AreEqual( "Hello World" , editor.GetText() );
        }
    }
}
