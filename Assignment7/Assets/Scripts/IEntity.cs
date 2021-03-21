/* George Tang
 * IEntity.cs 
 * Assignment 7
 * an entity to store the MoveFromTo method and control the start and end postion 
 */
using UnityEngine;
using System.Collections;

public interface IEntity
{
    Transform transform { get; }
    void MoveFromTo(Vector3 startPosition, Vector3 endPosition);
   
}
