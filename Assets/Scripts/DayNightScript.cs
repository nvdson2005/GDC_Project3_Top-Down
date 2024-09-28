using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayNightScript : MonoBehaviour
{
    /////
    /////
    /// Change from using volume to light2d
    
    private float startrpoint = 1f, startgpoint = 1f, startbpoint = 1f;
    private float rpoint = 0.1374674f, gpoint = 0.1231968f, bpoint = 0.4566037f;
    //Using new settings for light
    private Light2D _light;
    [SerializeField] private float dayLength = 5f;
    [SerializeField] private float timeChangeDuration = 1f;
    private Volume _volume;
    private float _timeSinceLastDay = 0;
    public enum TIME {Day, Night};

    public TIME _time;
    
    // Start is called before the first frame update
    private void Start()
    {
        _light = GetComponent<Light2D>();
        _volume = GetComponent<Volume>();
        _time = TIME.Day;
        _light.color = Color.white;
    }

    // Update is called once per frame
    private void Update()
    {
        _timeSinceLastDay += UnityEngine.Time.deltaTime;

        if (_timeSinceLastDay >= dayLength)
        {
            _timeSinceLastDay = 0;
            _time = (_time == TIME.Day) ? TIME.Night : TIME.Day;
            StartCoroutine(ChangeTime(_time));
            Debug.Log("Time change!");
        }
    }

    private IEnumerator ChangeTime(TIME time)
    {
        // float elapsedTime = 0f;
        // float startWeight = _volume.weight;
        // float endWeight = (time == TIME.Day) ? 0f : volumeCustomization;

        // while (elapsedTime < timeChangeDuration)
        // {
        //     _volume.weight = Mathf.Lerp(startWeight, endWeight, elapsedTime / timeChangeDuration);
        //     elapsedTime += UnityEngine.Time.deltaTime;
        //     yield return null;
        // }

        // _volume.weight = endWeight;
        float elapsedTime = 0f;
        while(elapsedTime < timeChangeDuration){
            
            float rr= Mathf.Lerp(startrpoint, rpoint, elapsedTime / timeChangeDuration);
            float gg = Mathf.Lerp(startgpoint, gpoint, elapsedTime / timeChangeDuration);
            float bb = Mathf.Lerp(startbpoint, bpoint, elapsedTime / timeChangeDuration);
            _light.color = new Color(rr, gg, bb, 1f);
            elapsedTime += UnityEngine.Time.deltaTime;
            yield return null;
        }
        (startrpoint, rpoint) = (rpoint, startrpoint);
        (startgpoint, gpoint) = (gpoint, startgpoint);
        (startbpoint, bpoint) = (bpoint, startbpoint);
    }
}