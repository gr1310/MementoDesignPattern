/******************************************************************************
* Filename    = Memento.cs
*
* Author      = Garima Ranjan
*
* Product     = SoftwareDesignPatterns
* 
* Project     = MementoPatternDemo
*
* Description = Saves the state of the originator.
*****************************************************************************/

namespace MementoTextEditor
{

    /// <summary>
    /// Stores the state of the TextEditor
    /// </summary>
    public class Memento
    {
        private readonly string _state; // stores the state (text)

        /// <summary>
        /// Constructor to initialize the private variable.
        /// </summary>
        /// <param name="state">The string that needs to be stored.</param>
        public Memento(string state)
        {
            _state = state;
        }

        /// <summary>
        /// Returns the present state.
        /// </summary>
        public string GetState()
        {
            return _state;
        }
    }
}
