// Memento class
class TextMemento
{
    public string Text { get; set; }
    public int CursorPosition { get; set; }
}


// CareTaker class
class TextUndoCareTaker
{
    private Stack<TextMemento> _mementos;

    public TextUndoCareTaker()
    {
        _mementos = new Stack<TextMemento>();
    }

    public TextMemento TextMemento
    {
        get { return _mementos.Pop(); }
        set { _mementos.Push(value); }
    }
}


// Originator class
class TextOriginator
{
    public string Text { get; set; }
    public int CursorPosition { get; set; }

    private TextUndoCareTaker _textCareTaker;

    public TextOriginator()
    {
        _textCareTaker = new TextUndoCareTaker();
    }

    public void Save()
    {
        _textCareTaker.TextMemento = new TextMemento
        {
            CursorPosition = this.CursorPosition,
            Text = this.Text
        };
    }

    public void Undo()
    {
        TextMemento previousTextMemento = _textCareTaker.TextMemento;

        CursorPosition = previousTextMemento.CursorPosition;
        Text = previousTextMemento.Text;
    }

    public override string ToString()
    {
        return $"text: {Text}, cursor position: {CursorPosition}";
    }
}