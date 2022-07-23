using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NumberOfLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = "Количество уровней: " + (SceneManager.sceneCountInBuildSettings - 3).ToString() + "\n-------------------------------------------------";
    }

}
