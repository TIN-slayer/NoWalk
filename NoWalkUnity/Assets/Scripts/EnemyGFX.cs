using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    [SerializeField] private GameObject trackEnemy;
    void OnBecameVisible()
    {
        trackEnemy.GetComponent<TrackEnemy>().vision = true;
    }
    void OnBecameInvisible()
    {
        trackEnemy.GetComponent<TrackEnemy>().vision = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (aiPath.desiredVelocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        */
    }
}
