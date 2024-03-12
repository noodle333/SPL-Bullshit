using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    [Header("SpawnBlocks")]
    public RockCounter rockCounter;
    public GameObject blockToSpawn;
    public Transform spawnPos;
    private int totalAmountToSpawn = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BlockSpawn()
    {
        StartCoroutine(StartBlockSpawn());
    }

    public IEnumerator StartBlockSpawn()
    {
        if (rockCounter.canSpawnRock)
        {
            for (int i = 0; i < totalAmountToSpawn; i++)
            {
                Instantiate(blockToSpawn, spawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(.2f);
            }
        }
        rockCounter.canSpawnRock = false;
    }
}
