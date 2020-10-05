using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    [SerializeField]
    float maxIntensity = 1.5f;
    [SerializeField]
    float dimmSpeed = 1f;
    Light light;
    bool dimming = true;

    
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (dimming)
        {
            light.intensity -= Time.deltaTime * dimmSpeed;
            if (light.intensity <= 0)
                dimming = false;
        }
        else
        {
            light.intensity += Time.deltaTime * dimmSpeed;
            if (light.intensity >= maxIntensity)
                dimming = true;
        }
    }
}
