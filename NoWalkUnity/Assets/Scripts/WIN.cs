using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIN : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //print(SceneManager.GetActiveScene().buildIndex);
            ManagerOfScenes.Load(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
