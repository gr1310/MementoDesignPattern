using MementoTextEditor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MementoTest
    {
        [TestMethod]
        public void TestMementoConstructor()
        {
            string expectedOutput = "Initial Text";
            Memento memento = new(expectedOutput);
            Assert.AreEqual(memento.GetState(), expectedOutput);
        }

        [TestMethod]
        public void TestGetState()
        {
            string initialState = "Initial state";
            Memento memento = new(initialState);

            string finalState = memento.GetState();
            Assert.AreEqual(initialState, finalState);
        }

    }
}
