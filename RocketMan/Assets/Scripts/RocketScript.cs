using UnityEngine;

public class RocketScript : MonoBehaviour
{   
    
    [SerializeField] float MainThrust = 100f;
    [SerializeField] float RotationThrust = 1f;
    [SerializeField] AudioClip Thurst;
    AudioSource SourceAudio;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SourceAudio = GetComponent<AudioSource>();
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
            if(!SourceAudio.isPlaying)
            {
                SourceAudio.PlayOneShot(Thurst);
            }
       } 
       else
            {
                SourceAudio.Stop();
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

