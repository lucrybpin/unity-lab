using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StoredMovementProcessor : MonoBehaviour
{
    [SerializeField] Transform _character;
    [SerializeField] Transform _uiParent;
    [SerializeField] UITurnCommandLine _uiLineCommandPrefab;
    [SerializeField] Button _moveUp;
    [SerializeField] Button _moveDown;
    [SerializeField] Button _moveLeft;
    [SerializeField] Button _moveRight;
    [SerializeField] Button _execute;

    // The magic is here, the list of commands. 
    // We are storing the history in actions and we can replay it later
    List<ITurnCommand> _commands;

    void Start()
    {
        _commands = new List<ITurnCommand>();

        _moveUp.onClick.AddListener(() => {
            ITurnCommand moveUp = new MoveUp(_character);
            _commands.Add(moveUp);
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=black>Move Up");
        });

        _moveDown.onClick.AddListener(() => {
            ITurnCommand moveDown = new MoveDown(_character);
            _commands.Add(moveDown);
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=purple>Move Down");
        });

        _moveLeft.onClick.AddListener(() => {
            ITurnCommand moveLeft = new MoveLeft(_character);
            _commands.Add(moveLeft);
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=blue>Move Left");
        });

        _moveRight.onClick.AddListener(() => {
            ITurnCommand moveRight = new MoveRight(_character);
            _commands.Add(moveRight);
            Instantiate<UITurnCommandLine>(_uiLineCommandPrefab, _uiParent).SetText("<color=red>Move Right");
        });

        _execute.onClick.AddListener(async () => {
            if(_commands.Count == 0)
                return;

            // Here we are simply reexecuting command by command
            // exaclty how they were stored, simple but really fun
            // mechanic!
            foreach(ITurnCommand command in _commands)
            {
                Destroy(_uiParent.GetChild(0).gameObject);
                command.Execute();
                await Task.Delay(TimeSpan.FromSeconds(0.52f));
            }
            _commands.Clear();
        });
    }
}
