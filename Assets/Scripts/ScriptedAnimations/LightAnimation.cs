using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LightAnimation : MonoBehaviour
{
    public float period = 1.5f;
    public float amplitudeCoef = 0.1f;
    private Vector3 startScale;
    void Start()
    {
        startScale = transform.localScale;
    }
    void Update()
    {
        transform.localScale = sinWave(Time.time / period, startScale, startScale * (amplitudeCoef + 1));
    }

    Vector3 sinWave(float value, Vector3 minValue, Vector3 maxValue)
    {
        return minValue - Mathf.Cos(value * Mathf.PI * 2) * (minValue - maxValue);
    }
}
