/* George Tang
 * MoveToCommand.cs 
 * Assignment 7
 * when executed the player will move to click position, when undo 
 *  the moves will be retraced and go back to the orignial position 
 */
using UnityEngine;
using System.Collections;

public class MoveToCommand : Command
{
    private Vector3 _destination;
    private Vector3 originalPosition;

    public MoveToCommand(IEntity entity, Vector3 destination) : base(entity)
    {
       _destination = destination;
    }
    public override void Execute()
    {
        originalPosition = _entity.transform.position;
        _entity.MoveFromTo(originalPosition, _destination);
    }

    public override void Undo()
    {
        _entity.MoveFromTo(_entity.transform.position, originalPosition);
    }
}
