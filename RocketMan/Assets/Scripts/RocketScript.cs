using UnityEngine;

public class RocketScript : MonoBehaviour
{   
    Rigidbody rb;
    [SerializeField] float MainThrust = 100f;
    [SerializeField] float RotationThrust = 1f;
    AudioSource ThrustAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThrustAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RocketThrust();
        RocketRotation();
        
        
    }
    void RocketThrust()
    {
       if(Input.GetKey(KeyCode.Space))
       {
        rb.AddRelativeForce(Vector3.up*MainThrust*Time.deltaTime);
        Debug.Log("Thrust");
            if(!ThrustAudio.isPlaying)
            {
                ThrustAudio.Play();
            }
       } 
       else
            {
                ThrustAudio.Stop();
            }

    }

    void RocketRotation()
    {
       if(Input.GetKey(KeyCode.A))
        {
            Rotate(RotationThrust);
            Debug.Log("left");
        }
        
        else if(Input.GetKey(KeyCode.D))
       {
             Rotate(-RotationThrust);
             Debug.Log("Right");
       }  
    }

     void Rotate(float rotationthisframe)
    {   
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationthisframe * Time.deltaTime);
        rb.freezeRotation = false;   
    }

}   

