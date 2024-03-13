using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 StartingPosition;
    [SerializeField] Vector3 MovementVector;
    [SerializeField] [Range(0,1)] float MovementFactor;
    [SerializeField] float Period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Period <= Mathf.Epsilon) { return; } 

        float Cycles = Time.time / Period;

        const float Tau = Mathf.PI * 2;
        //Debug.Log(Tau);

        float RawSinWave = Mathf.Sin(Cycles*Tau);


        MovementFactor = (RawSinWave + 1f) / 2f;
       // Debug.Log(MovementFactor);

        Vector3 offset = MovementVector * MovementFactor;
        transform.position = StartingPosition + offset; 

        
        
    }
}
