using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class TurnOnLights : MonoBehaviour
{
    float time = 0f;
    //This is equal to DayLength in game object Global Volume, but there is some error when get this component from 
    //Global Volume (DayNightScript.cs) so I initialize it here
    private float DayLength = 40f;
    bool isDay = true;
    [SerializeField] float intensity = 2f;
    private Light2D _selflight;
    // Start is called before the first frame update
    void Start()
    {   
        _selflight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= DayLength)
        {
            time = 0f;
            isDay = !isDay;
        }
        if (!isDay)
        {
            _selflight.intensity = intensity;
        }
        else
        {
            _selflight.intensity = 0f;
        }
    }
}
