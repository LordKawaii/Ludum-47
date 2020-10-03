using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCon : MonoBehaviour
{

    [SerializeField]
    GameObject enemy;

    public void Spawn(int num)
    {
        if (enemy != null)
        {
            for (int i = 0; i <= num; i++)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
            }
        }
    }
}
