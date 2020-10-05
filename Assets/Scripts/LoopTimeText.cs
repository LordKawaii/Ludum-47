using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoopTimeText : MonoBehaviour
{
    TextMeshProUGUI loopTimeText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = GameState.LoopNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
