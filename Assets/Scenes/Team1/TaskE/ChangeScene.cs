using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "t1-task-Initial") {
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(0);
        }
    }
}
