using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField]
    float period = 2f;

    [SerializeField]
    Vector3 movementVector;

    float movementFactor;

    Vector3 startingPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        float tau = Mathf.PI * 2;
        float rawSine = Mathf.Sin(cycles * tau);
        movementFactor = (rawSine + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
