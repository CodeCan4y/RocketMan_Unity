using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RocketScript : MonoBehaviour
{   
    
    [SerializeField] float MainThrust = 100f;
    [SerializeField] float RotationThrust = 500f;
    
    [SerializeField] AudioClip Thurst;

    [SerializeField] ParticleSystem MainThrustParticle_1;
    [SerializeField] ParticleSystem MainThrustParticle_2;
    [SerializeField] ParticleSystem MainThrustParticle_3;
    [SerializeField] ParticleSystem RightThrustParticle;
    [SerializeField] ParticleSystem LeftThrustParticle;

    [SerializeField] Light MainThrustLight;

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
            MainThrustParticle_1.Play();
            MainThrustParticle_2.Play();
            MainThrustParticle_3.Play();
            MainThrustLight.intensity = 10f;
        } 
       else
       {
            SourceAudio.Stop();
            MainThrustParticle_1.Stop();
            MainThrustParticle_2.Stop();
            MainThrustParticle_3.Stop();
            MainThrustLight.intensity = 0f;
        }

    }

    void RocketRotation()
    {
       if(Input.GetKey(KeyCode.A))
       {
            Rotate(RotationThrust);
            Debug.Log("left");
            RightThrustParticle.Play();
       }
        
        else if(Input.GetKey(KeyCode.D))
        {
             Rotate(-RotationThrust);
             Debug.Log("Right");
             LeftThrustParticle.Play();
        }
        else
        {
            RightThrustParticle.Stop();
            LeftThrustParticle.Stop();
        }
    }

     void Rotate(float rotationthisframe)
    {
        //rb.freezeRotation = true;
        //transform.Rotate(Vector3.forward * rotationthisframe * Time.deltaTime);
        rb.AddTorque(Vector3.forward * rotationthisframe * Time.deltaTime);
        //rb.freezeRotation = false;   
    }

    

}   

