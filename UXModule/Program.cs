using MementoTextEditor;

namespace UXModule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TextEditor editor = new();
            Caretaker caretaker = new();

            while (true)
            {
                Console.WriteLine("Enter text (or type 'undo', 'redo', 'read', or 'exit'):");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "undo")
                {
                    bool undone = caretaker.Undo(editor);
                    if (undone)
                    {
                        Console.WriteLine("Successful Undo");
                    }
                    else
                    {
                        Console.WriteLine("Nothing to Undo");
                    }
                }
                else if (userInput.ToLower() == "redo")
                {
                    bool undone = caretaker.Redo( editor );
                    if (undone)
                    {
                        Console.WriteLine( "Successful Redo" );
                    }
                    else
                    {
                        Console.WriteLine( "Nothing to Redo" );
                    }
                }
                else if (userInput.ToLower() == "read")
                {
                    Console.WriteLine("Current Text: " + editor.GetText());
                }
                else if (userInput.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    editor.SetText(userInput);
                    caretaker.SaveState(editor);
                }
            }
        }
    }
}
