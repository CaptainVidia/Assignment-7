/* George Tang
 * ClickToMove.cs 
 * Assignment 7
 * A simple click to move then backspace to undo all action of player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CommandProcessor))]
[RequireComponent(typeof(ClickInputReader))]
public class ClickToMove : MonoBehaviour, IEntity
{
    private CommandProcessor _commandProcessor;
    private ClickInputReader clickInputReader;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Awake()
    {
        _commandProcessor = GetComponent<CommandProcessor>();
        clickInputReader = GetComponent<ClickInputReader>();
    }

    // Update is called once per frame
    private void Update()
    {
        var position = clickInputReader.GetClickPosition();
        if (position != null)
        {
            _commandProcessor.ExecuteCommand(new MoveToCommand(this, position.Value));
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _commandProcessor.Undo();
        }
    }

    public void MoveFromTo(Vector3 startPosition, Vector3 endPosition)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(MoveFromToAsync(startPosition, endPosition));
    }
    private IEnumerator MoveFromToAsync(Vector3 startPostion, Vector3 endPosition)
    {
        float elasped = 0;
        while (elasped < 1f)
        {
            transform.position = Vector3.Lerp(startPostion, endPosition, elasped);
            elasped += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
    }
}

