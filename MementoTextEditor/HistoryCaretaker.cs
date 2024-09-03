/************************************************************************************************************
* Filename    = HistoryCaretaker.cs
*
* Author      = Garima Ranjan
*
* Product     = SoftwareDesignPatterns
* 
* Project     = MementoPatternDemo
*
* Description = CareTaker : Stores and restores the Memento objects. Undo and Redo states for TextEditor.
************************************************************************************************************/

namespace MementoTextEditor
{

    /// <summary>
    /// Keeps stack of current text string and pop/push to undo/redo
    /// </summary>
    public class HistoryCaretaker
    {
        private readonly Stack<Memento> _undoStack = new(); // undo stack to keep track of previous state
        private readonly Stack<Memento> _redoStack = new(); // redo stack to keep track of next state

        /// <summary>
        /// Saves the current text by updating undo stack and clearing redo stack
        /// </summary>
        /// <param name="textEditor">The originator: object of TextEditor class.</param>
        public void SaveState(TextEditor textEditor)
        {
            _undoStack.Push(textEditor.SaveToMemento());
            _redoStack.Clear(); // nothing to redo on arrival of new text
        }

        /// <summary>
        /// Undos the current text by popping undo stack and updating redo stack
        /// </summary>
        /// <param name="textEditor">The originator: object of TextEditor class.</param>
        public bool Undo(TextEditor textEditor) 
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(textEditor.SaveToMemento());
                _undoStack.Pop();
                if (_undoStack.Count == 0)  // No state exists before this
                {
                    textEditor.GetFromMemento( null );

                }
                else
                {
                    textEditor.GetFromMemento( _undoStack.Peek() );
                }
                return true;
            }

            return false; // no previous text exists
        }

        /// <summary>
        /// Redos the current text by popping redo stack and updating undo stack
        /// </summary>
        /// <param name="textEditor">The originator: object of TextEditor class.</param>
        public bool Redo(TextEditor textEditor)
        {
            if( _redoStack.Count > 0)
            {
                _undoStack.Push(textEditor.SaveToMemento());
                textEditor.GetFromMemento(_redoStack.Pop());
                return true;
            }

            return false; // no next state exists
        }
    }
}
