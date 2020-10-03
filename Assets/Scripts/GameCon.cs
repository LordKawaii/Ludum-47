using System.Collections;
using System.Collections.Generic;
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
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
