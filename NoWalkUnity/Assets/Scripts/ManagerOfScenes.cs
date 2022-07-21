using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ManagerOfScenes
{
    // Start is called before the first frame update
    public static void Load(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

}
