using UnityEngine;

public class MoveUp : ITurnCommand
{
    Transform _target;
    public string Name { get { return "MoveUp"; } set { } }

    public MoveUp(Transform target)
    {
        _target = target;
    }

    public void Execute()
    {
        _target.Translate(Vector3.forward);
    }

    public void Undo()
    {

        _target.Translate(-Vector3.forward);
    }
}
