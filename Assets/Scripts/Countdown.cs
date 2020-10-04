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

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        timer.text = "2.00";
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = timeLeft.ToString().TrimEnd('x');
        timeLeft = timeLeft - Time.deltaTime;
    }
}
