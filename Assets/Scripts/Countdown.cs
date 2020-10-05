using FMOD;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    TextMeshProUGUI timer;
    [SerializeField]
    float timeLeft = 2f;

    bool timerEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.GetComponent<TextMeshProUGUI>();
        timer.text = "2.00";
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 10)
            timer.color = Color.red;
        if (timeLeft < 0)
            timeLeft = 0;
        timer.text = timeLeft.ToString();



        if (timerEnded == false && timeLeft <=0)
        {
            GameCon.Instance.PlayLaugh();
            timerEnded = true;
        }
    }
}
