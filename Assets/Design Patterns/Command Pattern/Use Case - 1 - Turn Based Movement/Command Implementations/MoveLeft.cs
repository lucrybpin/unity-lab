using UnityEngine;

public class MoveLeft : ITurnCommand
{
    Transform _target;
    public string Name { get { return "MoveUp"; } set { } }

    public MoveLeft(Transform target)
    {
        _target = target;
    }

    public void Execute()
    {
        _target.Translate(Vector3.left);
    }

    public void Undo()
    {
        _target.Translate(Vector3.right);
    }
}
