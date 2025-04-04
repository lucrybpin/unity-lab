public interface ITurnCommand
{
    public string Name { get; set; }
    void Execute();
    void Undo();
}