namespace MementoTextEditor
{
    public class Caretaker
    {
        private readonly Stack<Memento> _undoStack = new();
        private readonly Stack<Memento> _redoStack = new();

        public void SaveState(TextEditor textEditor)
        {
            _undoStack.Push(textEditor.SaveToMemento());
            _redoStack.Clear();
        }

        public bool Undo(TextEditor textEditor) 
        {
            if (_undoStack.Count > 1)
            {
                _redoStack.Push(textEditor.SaveToMemento());
                _undoStack.Pop();
                textEditor.GetFromMemento(_undoStack.Peek());
                return true;
            }
            return false;
        }

        public bool Redo(TextEditor textEditor)
        {
            if( _redoStack.Count > 0)
            {
                _undoStack.Push(textEditor.SaveToMemento());
                textEditor.GetFromMemento(_redoStack.Pop());
                return true;
            }
            return false;
        }
    }
}
