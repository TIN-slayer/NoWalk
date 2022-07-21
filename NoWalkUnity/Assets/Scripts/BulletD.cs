using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletD : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public Rigidbody2D rb;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform gun;
    public bool bulDcol = false;
    Vector2 lastVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 0;

    }


    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(1))
        {
            transform.rotation = gun.rotation;
            transform.position = shotPoint.position;
            rb.velocity = transform.right * speed;
        }
        */
        lastVelocity = rb.velocity;

    }

    /*
    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(1))
        {
            rb.MovePosition(rb.position + rb.velocity * Time.fixedDeltaTime);
        }

    }
    */

    void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0);
    }
}
