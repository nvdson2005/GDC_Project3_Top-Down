using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNightScript : MonoBehaviour
{
    [SerializeField] private float dayLength = 5f;
    [SerializeField] private float timeChangeDuration = 1f;
    
    private Volume _volume;
    private float _timeSinceLastDay = 0;
    private enum TIME {Day, Night};

    private TIME _time;
    
    // Start is called before the first frame update
    private void Start()
    {
        _volume = GetComponent<Volume>();
        _time = TIME.Day;
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
        float elapsedTime = 0f;
        float startWeight = _volume.weight;
        float endWeight = (time == TIME.Day) ? 0f : 1f;

        while (elapsedTime < timeChangeDuration)
        {
            _volume.weight = Mathf.Lerp(startWeight, endWeight, elapsedTime / timeChangeDuration);
            elapsedTime += UnityEngine.Time.deltaTime;
            yield return null;
        }

        _volume.weight = endWeight;
    }
}