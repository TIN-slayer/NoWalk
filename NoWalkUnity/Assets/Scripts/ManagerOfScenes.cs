using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerOfScenes : MonoBehaviour
{
    public static void Load(int scene)
    {
        print(scene);
        SceneManager.LoadSceneAsync(scene);        
    }

}
