using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDirection : MonoBehaviour
{
    [SerializeField] private Transform flag;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Vector2 pos1 = this.transform.position;
        Vector2 pos2 = flag.position;
        Vector2 direction = (pos2 - pos1).normalized;
        this.transform.rotation = Quaternion.LookRotation(direction);
        */

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos1 = this.transform.position;
        Vector3 pos2 = flag.position;
        Vector3 direction = pos2 - pos1;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
