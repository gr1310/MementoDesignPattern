using MementoTextEditor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TextEditorTest
    {
        [TestMethod]
        public void TestSetText()
        {
            string expectedText = "Initial text";
            TextEditor editor = new();
            editor.SetText(expectedText);

            Assert.AreEqual(expectedText, editor.GetText());
        }

        [TestMethod]
        public void TestSaveToMemento()
        {
            Memento memento = new("Initial state");
            TextEditor editor = new();
            editor.SetText( "Initial state" );

            Assert.AreEqual(memento.GetState(), editor.SaveToMemento().GetState());
        }

        [TestMethod]
        public void TestGetFromMemento()
        {
            Memento memento = new( "Initial State" );
            TextEditor editor = new();
            editor.GetFromMemento( memento );

            Assert.AreEqual( memento.GetState() , editor.GetText() );
        }
    }
}
