using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletA;
    [SerializeField] private GameObject bulletD;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ManagerOfScenes.Load(0);
        }
        else if (collision.CompareTag("BulletA"))
        {
            bulletA.GetComponent<BulletA>().bulAcol = true;
        }
        else if (collision.CompareTag("BulletD"))
        {
            bulletD.GetComponent<BulletD>().bulDcol = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletA"))
        {
            bulletA.GetComponent<BulletA>().bulAcol = false;
        }
        else if (collision.CompareTag("BulletD"))
        {
            bulletD.GetComponent<BulletD>().bulDcol = false;
        }
    }
}
