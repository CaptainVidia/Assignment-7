/* George Tang
 * Command.cs 
 * Assignment 7
 * abstract class for command for methods 
 */
using UnityEngine;
using System.Collections;

public abstract class Command
{

    protected IEntity _entity;
    public Command(IEntity entity)
    {
        _entity = entity;
    }
    public abstract void Execute();
    public abstract void Undo();
}
