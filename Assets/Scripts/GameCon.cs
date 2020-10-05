using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameCon : MonoBehaviour
{
    [HideInInspector]
    public static GameCon Instance;

    GameObject startMenuImage;

    [SerializeField]
    List<Sprite> hearts;

    [SerializeField]
    AudioClip never;
    bool neverHasPlayed = false;

    [SerializeField]
    AudioClip hint;
    bool hintHasPlayed = false;


    public int loopTimes = 0;

    AudioSource au;

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
            SpawnEnemies(spawners, GameState.LoopNum +3);

    }

    
    // Update is called once per frame
    void Update()
    {
        if (startMenuImage == null)
            startMenuImage = GameObject.FindGameObjectWithTag("StartImg");

        if(au == null)
            au = GetComponent<AudioSource>();

        if (GameState.LoopNum == 1 && !neverHasPlayed)
        {
            au.PlayOneShot(never);
            neverHasPlayed = true;
        }

        if (GameState.LoopNum == 4 && !hintHasPlayed)
        {
            au.PlayOneShot(hint);
            hintHasPlayed = true;

        }

        if (!GameState.GameStart)
            Time.timeScale = 0;
        else
        {
            startMenuImage.SetActive(false);
            
            Time.timeScale = 1;
        }
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
            spawners[randSpawner].GetComponent<SpawnerCon>().Spawn(1);
        }
    }

    public void RestartLoop()
    {
        GameState.LoopNum++;
        SceneManager.LoadScene(0);
    }    

    public void StartGame()
    {
        GameState.GameStart = true;
        
    }

    public void PlayLaugh()
    {
        au.Play();
    }
}
