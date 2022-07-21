using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private LayerMask mask;
    public Transform target;
    private bool saw = false;
    public bool vision = false;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        mask = LayerMask.GetMask("Player", "Block");
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector2 pointA = this.transform.position;
        Vector2 pointB = target.position;
        //float dist = Vector2.Distance(pointA, pointB) <= 17;
        if (!saw)
        {
            RaycastHit2D hit = Physics2D.Linecast(pointA, pointB, mask);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player")) //bag
                {
                    saw = true;
                }
            }
                   
        }
        
        if (saw & vision)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            saw = false;
            agent.SetDestination(this.transform.position);
        }
        
    }
}
