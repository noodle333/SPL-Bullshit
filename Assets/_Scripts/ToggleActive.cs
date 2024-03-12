using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ToggleActive : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToToggle;
    [SerializeField] private float TimeBetweenBlocksToToggle;

    public void Toggle()
    {
        StartCoroutine(StartToggle());
    }

    public IEnumerator StartToggle()
    {
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(!objectsToToggle[i].activeInHierarchy);
            yield return new WaitForSeconds(TimeBetweenBlocksToToggle);
        }
    }

}

