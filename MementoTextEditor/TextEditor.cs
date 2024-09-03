/*****************************************************************************************
* Filename    = TextEditor.cs
*
* Author      = Garima Ranjan
*
* Product     = SoftwareDesignPatterns
* 
* Project     = MementoPatternDemo
*
* Description = The originator: supports text manipulation and state saving/restoration
******************************************************************************************/

namespace MementoTextEditor
{

    /// <summary>
    /// Methods for text and state manipulation
    /// </summary>
    public class TextEditor
    {
        private string _text;

        /// <summary>
        /// Constructor to initialize the private variable to empty string.
        /// </summary>
        public TextEditor()
        {
            _text = string.Empty;   // initializes to empty string
        }

        /// <summary>
        /// Method to set the private string to user entered string.
        /// </summary>
        /// <param name="state">The user entered string.</param>
        public void SetText(string text)
        {
            if (_text != string.Empty)
            {
                _text = _text + " " + text; // adding space between words typed
            }
            else
            {
                _text = text;
            }
        }

        /// <summary>
        /// Method to get the private string.
        /// </summary>
        public string GetText()
        {
            return _text;
        }

        /// <summary>
        /// Method to save the present state in memento.
        /// </summary>
        public Memento SaveToMemento()
        {
            Memento memento = new(_text);
            return memento;
        }

        /// <summary>
        /// Method to restore the state from memento.
        /// </summary>
        /// <param name="state">The memento from which state is to be restored.</param>
        public void GetFromMemento(Memento? memento)
        {
            if (memento == null)    // to handle the case of the very first state being undo
            {
                _text = string.Empty;
            }
            else
            {
                _text = memento.GetState();
            }
        }
    }
}
