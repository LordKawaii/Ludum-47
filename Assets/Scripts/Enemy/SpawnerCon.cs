using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SpawnerCon : MonoBehaviour
{

    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float spawnDelay = .5f;
    public void Spawn(int num)
    {
        if (enemy != null)
        {
            StartCoroutine(spawnTimer(spawnDelay, num));
        }
    }

    IEnumerator spawnTimer(float time, int numSpawns)
    {
        for (int i = 0; i < numSpawns; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
