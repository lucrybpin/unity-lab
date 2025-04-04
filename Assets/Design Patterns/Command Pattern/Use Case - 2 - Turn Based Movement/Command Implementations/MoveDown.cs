using UnityEngine;

public class MoveDown : ITurnCommand
{
    Transform _target;
    public string Name { get { return "MoveUp"; } set { } }

    public MoveDown(Transform target)
    {
        _target = target;
    }

    public void Execute()
    {
        _target.Translate(-Vector3.forward);
    }

    public void Undo()
    {
        _target.Translate(Vector3.forward);
    }

}
