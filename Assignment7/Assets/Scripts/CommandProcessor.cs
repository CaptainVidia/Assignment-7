/* George Tang
 * CommandProcessor.cs 
 * Assignment 7
 * stores the players click (commands) and then will undo the commands when told
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandProcessor : MonoBehaviour
{
    private List<Command> _commands = new List<Command>();
    private int _currentCommandIndex;

    public void ExecuteCommand(Command command)
    {
        _commands.Add(command);
        command.Execute();
        _currentCommandIndex = _commands.Count - 1;
    }

    public void Undo()
    {
        if (_currentCommandIndex < 0)
        {
            return;
        }
        _commands[_currentCommandIndex].Undo();
        _commands.RemoveAt(_currentCommandIndex);
        _currentCommandIndex--;
    }

    public void Redo()
    {
        _commands[_currentCommandIndex].Execute();
        _currentCommandIndex++;
    }
}
