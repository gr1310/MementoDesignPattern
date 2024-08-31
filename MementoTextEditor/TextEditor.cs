namespace MementoTextEditor
{
    public class TextEditor
    {
        private string _text;

        public void SetText(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }

        public Memento SaveToMemento()
        {
            Memento memento = new(_text);
            return memento;
        }

        public void GetFromMemento(Memento memento)
        {
            _text = memento.GetState();
        }
    }
}
