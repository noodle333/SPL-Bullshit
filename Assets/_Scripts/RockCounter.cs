using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockCounter : MonoBehaviour
{
    public TextMeshPro rocksNeededText;

    public int rocksNeeded = 15;
    public int amountPerRock = 5;
    public bool canSpawnRock = true;
    private bool stopToggle = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rocksNeededText.text = "int rocksNeeded = " + rocksNeeded.ToString() + ";";

        if(rocksNeeded == 0 && !stopToggle)
        {
            GetComponent<ToggleActive>().Toggle();
            stopToggle = true;
        }
    }

}
