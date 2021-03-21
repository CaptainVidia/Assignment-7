 /* George Tang
 * ClickInputReader.cs 
 * Assignment 7
 * A simple raycast and click to move scripts. attach to player 
 */
using UnityEngine;
using System.Collections;

public class ClickInputReader : MonoBehaviour
{
    public Vector3? GetClickPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                return hitInfo.point;
            }
        }
        return null;
    }
    
}
