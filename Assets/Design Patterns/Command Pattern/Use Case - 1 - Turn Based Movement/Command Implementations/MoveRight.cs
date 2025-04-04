using UnityEngine;

public class MoveRight : ITurnCommand
{
    Transform _target;
    public string Name { get { return "MoveUp"; } set { } }

    public MoveRight(Transform target)
    {
        _target = target;
    }

    public void Execute()
    {
        _target.Translate(Vector3.right);
    }

    public void Undo()
    {
        _target.Translate(-Vector3.right);
    }
}
