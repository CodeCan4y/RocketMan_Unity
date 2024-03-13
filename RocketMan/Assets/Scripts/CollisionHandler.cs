using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float LoadSceneDelay = 1f;
   [SerializeField] AudioClip deathAudio;
   [SerializeField] AudioClip SuccessAudio;

   [SerializeField] ParticleSystem successParticles;
   [SerializeField] ParticleSystem explosionParticles;
   AudioSource SourceAudio;

   bool IsTransitioning = false;
   bool CollisionDisable = false;

   void Start()
   {
    SourceAudio = GetComponent<AudioSource>();
   }

   void Update()
   {
        DebugKeys();
   }

    void OnCollisionEnter(Collision other)
   {
        if(IsTransitioning || CollisionDisable)
        {
            return;
        }
        switch(other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("fuel added");
                break;
            case "Friendly":
                Debug.Log("Friendly Fire");
                break;
            case "Finish":
                Debug.Log("Game Khatam brooo");
                SuccessSquence();
                break; 
            case "Respawn":
                break;  
            default:
                Debug.Log("Dead");
                CrashSquence();
                break;           
        }
        
   }

   void SuccessSquence()
   {
    IsTransitioning = true;
    SourceAudio.Stop();
    SourceAudio.PlayOneShot(SuccessAudio);
    successParticles.Play();
    GetComponent<RocketScript>().enabled = false;
    Invoke("NextLevel", LoadSceneDelay);
   }
   void CrashSquence()
   {
    IsTransitioning = true; 
    SourceAudio.Stop();
    SourceAudio.PlayOneShot(deathAudio);
    explosionParticles.Play();
    GetComponent<RocketScript>().enabled = false;
    Invoke("ReloadScene", LoadSceneDelay);
   } 
   void ReloadScene()
   {
    int CurrentScene = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(CurrentScene);
   }

   void NextLevel()
   {
    int CurrentScene = SceneManager.GetActiveScene().buildIndex;
    int NextScene = CurrentScene + 1;
    if(NextScene == SceneManager.sceneCountInBuildSettings)
    {
        NextScene = 0;
    }
    SceneManager.LoadScene(NextScene);  
   }

   void DebugKeys()
   {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            CollisionDisable = !CollisionDisable;
        }
   }
           
}
