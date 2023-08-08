using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickeringLight;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 1f;

    private float baseIntensity;
    private float timeOffset;

    private void Start()
    {
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }

        baseIntensity = flickeringLight.intensity;
        timeOffset = Random.Range(0f, 100f); // To create some randomness in the flicker pattern
    }

    private void Update()
    {
        float flickerValue = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin((Time.time + timeOffset) * flickerSpeed) + 1f) / 2f);
        flickeringLight.intensity = baseIntensity * flickerValue;
    }
}
