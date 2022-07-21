using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public Rigidbody2D rb;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform gun;
    public bool bulAcol = false;
    Vector2 lastVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 0;
    }
    
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
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
        if(Input.GetMouseButtonUp(0) & Gun.bulAcool)
        {
            rb.MovePosition(rb.position + rb.velocity * Time.fixedDeltaTime);
        }
        lastVelocity = rb.velocity;

    }
    */
    void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0);
    }
}
