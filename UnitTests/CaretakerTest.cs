using MementoTextEditor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CaretakerTest
    {
        [TestMethod]
        public void TestUndoShouldRevertToPreviousState()
        {
            Caretaker caretaker = new();

            string initialText = "Initial Text";
            TextEditor editor = new();

            editor.SetText(initialText);
            caretaker.SaveState(editor);
            Assert.AreEqual( initialText , editor.GetText() );

            string finalText = "Final Text";
            editor.SetText(finalText);
            caretaker.SaveState( editor );
            Assert.AreEqual(finalText, editor.GetText());

            bool canBeUndone = caretaker.Undo( editor );
            Assert.IsTrue( canBeUndone );
            Assert.AreEqual(initialText, editor.GetText() );
        }

        [TestMethod]
        public void TestUndoNoPreviousState()
        {
            Caretaker caretaker = new();

            string initialText = "Initial Text";
            TextEditor editor = new();

            editor.SetText( initialText );
            caretaker.SaveState( editor );
            Assert.AreEqual( initialText , editor.GetText() );

            bool canBeUndone = caretaker.Undo( editor );
            Assert.IsFalse( canBeUndone );
            Assert.AreEqual( initialText , editor.GetText() );
        }

        [TestMethod]
        public void TestRedoShouldGoToNextState()
        {
            Caretaker caretaker = new();
            TextEditor editor = new();

            string initialText = "Initial Text";
            editor.SetText( initialText );
            caretaker.SaveState( editor );
            Assert.AreEqual( initialText , editor.GetText() );

            string finalText = "Final Text";
            editor.SetText( finalText );
            caretaker.SaveState( editor );
            Assert.AreEqual( finalText , editor.GetText() );

            caretaker.Undo( editor );

            bool canBeRedone = caretaker.Redo( editor );
            Assert.IsTrue( canBeRedone );
            Assert.AreEqual( finalText , editor.GetText() );
        }
        
        [TestMethod]
        public void TestRedoNoNextState()
        {
            Caretaker caretaker = new();
            TextEditor editor = new();

            string initialText = "Initial Text";
            editor.SetText( initialText );
            caretaker.SaveState( editor );
            Assert.AreEqual( initialText , editor.GetText() );

            string finalText = "Final Text";
            editor.SetText( finalText );
            caretaker.SaveState( editor );
            Assert.AreEqual( finalText , editor.GetText() );

            bool canBeRedone = caretaker.Redo( editor );
            Assert.IsFalse( canBeRedone );
            Assert.AreEqual( finalText , editor.GetText() );
        }
    }
}
