using System.Collections.Generic;
using UnityEngine;

public class TurnBasedMovementProcessor : MonoBehaviour
{
    [SerializeField] Transform _character;
    [SerializeField] Transform _uiParent;
    [SerializeField] UITurnCommandLine _uiLineCommandPrefab;
    List<ITurnCommand> _commands;

    void Start()
    {
        _commands = new List<ITurnCommand>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ITurnCommand moveUp = new MoveUp(_character);
            _commands.Add(moveUp);
            moveUp.Execute();
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=black>Move Up");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ITurnCommand moveDown = new MoveDown(_character);
            _commands.Add(moveDown);
            moveDown.Execute();
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=purple>Move Down");
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ITurnCommand moveLeft = new MoveLeft(_character);
            _commands.Add(moveLeft);
            moveLeft.Execute();
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=blue>Move Left");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ITurnCommand moveRight = new MoveRight(_character);
            _commands.Add(moveRight);
            moveRight.Execute();
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=red>Move Right");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            UndoLastCommand();
        }
    }

    void UndoLastCommand()
    {
        if(_commands.Count == 0)
            return;

        ITurnCommand lastCommand = _commands[_commands.Count-1];
        lastCommand.Undo();
        _commands.Remove(lastCommand);
        Destroy(_uiParent.GetChild(_uiParent.childCount -1).gameObject);
    }
}
