using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToToggle;

    public void Toggle()
    {
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(!objectsToToggle[i].activeInHierarchy);
        }
    }
}

