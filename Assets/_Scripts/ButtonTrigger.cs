using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    //winAction isnt needed but checking shit isnt either.
    //levelManager doesnt count all buttonTriggers you yourself assign the necessary ones
    //meaning you can have as many as you want and only 1 is needed to complete the level

    [Header("GameObject for the correct block for the position")]
    [SerializeField] private GameObject expectedBlock;

    [Header("winAction optional")]
    [SerializeField] private UnityEvent winAction;

    [Header("The other alternatives in order with the actions they trigger")]
    [SerializeField] private GameObject[] unexpectedBlocks;
    [SerializeField] private UnityEvent[] actions;

    [Header("LevelManager")]
    [SerializeField] private LevelManager levelManager;
    public bool active = false;

    private GameObject currentBlock;

    private void OnTriggerEnter2D(Collider2D other)
    {
        BoxMovement box = other.GetComponent<BoxMovement>();
        if (!box) return;

        if (box.gameObject == expectedBlock)
        {
            active = true;
            if (winAction != null)
            {
                winAction.Invoke();
            }
            else
            {
                levelManager.WinCheck();
            }
        }

        for (int i = 0; i < unexpectedBlocks.Length; i++)
        {
            if (box.gameObject == unexpectedBlocks[i])
            {
                actions[i].Invoke();
                return;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        BoxMovement box = other.GetComponent<BoxMovement>();
        if (!box) return;

        ErrorMessage();
        if (box.gameObject == expectedBlock)
        {
            if (winAction != null) winAction.Invoke();
            active = false;
        }
    }

    public void IncorrectOperator()
    {
        Debug.Log("This value is incompatible with this operator");
    }

    private void ErrorMessage()
    {
        Debug.Log("Operation missing value");
    }
}
