using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCon : MonoBehaviour
{
    [HideInInspector]
    public static GameCon Instance;

    [SerializeField]
    List<Sprite> hearts;

    public int loopTimes = 0;


    [HideInInspector]
    public List<GameObject> spawners;
    bool hasSpawned = false;

    
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
            DontDestroyOnLoad(gameObject);
        }

        spawners = new List<GameObject>();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawners.Add(obj);
        }

        if (spawners.Count > 0)
            SpawnEnemies(spawners, GameState.LoopNum +1);

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealthIco(int lvl)
    {
        GameObject healthIco = GameObject.FindGameObjectWithTag("HealthIco");
        healthIco.GetComponent<Image>().sprite = hearts[lvl - 1];
    }

    void SpawnEnemies(List<GameObject> spawners, int numSpawns)
    {
        for (int i = 0; i < numSpawns; i++)
        {
            int randSpawner = UnityEngine.Random.Range(0, spawners.Count);
            spawners[randSpawner].GetComponent<SpawnerCon>().Spawn(numSpawns/2 + 1);
        }
    }

    public void RestartLoop()
    {
        GameState.LoopNum++;
        SceneManager.LoadScene(0);
    }    
}
