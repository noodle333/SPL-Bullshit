using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private ButtonTrigger[] winTriggers;
    [SerializeField] private UnityEvent action;

    public void WinCheck()
    {
        for (int i = 0; i < winTriggers.Length; i++)
        {
            if (!winTriggers[i].active) return;
        }
        action.Invoke();
    }

}

//last com