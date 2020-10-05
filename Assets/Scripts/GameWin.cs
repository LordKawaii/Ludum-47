using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWin : MonoBehaviour
{
    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            winText.text = "You Win";
    }
}
