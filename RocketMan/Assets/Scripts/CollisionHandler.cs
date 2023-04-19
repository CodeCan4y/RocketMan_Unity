using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float LoadSceneDelay = 1f;
   void OnCollisionEnter(Collision other)
   {
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
                NextLevel();
                break; 
            case "Respawn":
                break;  
            default:
                Debug.Log("Dead");
                CrashSquence();
                break;           
        }
        
   }
   void CrashSquence()
   {
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
           
}
