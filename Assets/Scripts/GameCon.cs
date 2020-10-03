using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameCon : MonoBehaviour
{
    [HideInInspector]
    public static GameCon Instance;

    public int loopTimes = 0;

    [HideInInspector]
    public List<GameObject> spawners;

    
    void Awake()
    {        ///Set this to be main Game Controller
        if (Instance)
        {
            Debug.Log("I already exist: destroying self");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        spawners = new List<GameObject>();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawners.Add(obj);
        }

        if (spawners.Count > 0)
            SpawnEnemies(spawners, loopTimes +1);

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies(List<GameObject> spawners, int numSpawns)
    {
        for (int i = 0; i < numSpawns; i++)
        {
            int randSpawner = UnityEngine.Random.Range(0, spawners.Count);
            spawners[randSpawner].GetComponent<SpawnerCon>().Spawn(numSpawns/2 + 1);
        }
    }

}
