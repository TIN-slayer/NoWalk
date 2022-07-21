using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform[] points;
    [SerializeField] private LineController line;
    public float offset;
    [SerializeField] private GameObject bulletA;
    [SerializeField] private GameObject bulletD;
    [SerializeField] private GameObject spriteA;
    [SerializeField] private GameObject spriteD;
    [SerializeField] private GameObject gamer;
    public Transform player;
    public Transform shotPoint;
    public Image fillA;
    public Image fillD;
    public float cooldown;
    public float speedBull;
    public bool bulAcool = true;
    public bool bulDcool = true;
    private float timeBtwShots;
    public float startTimeBtwShots;

    void Start()
    {
        points = new Transform[] {player, player, player, player};
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        line.SetUpLine(points);
        if (timeBtwShots <= 0)
        {
            if (Input.GetKey("a") & Input.GetMouseButtonDown(0) & bulAcool)
            {
                bulAcool = false;
                StartCoroutine(Cooldown(1, cooldown));
                gamer.GetComponent<PlayerController>().existA = true;
                points[1] = bulletA.transform;
                timeBtwShots = startTimeBtwShots;
                bulletA.transform.rotation = this.transform.rotation;
                bulletA.transform.position = shotPoint.position;
                spriteA.GetComponent<SpriteRenderer>().enabled = true;
                spriteA.transform.rotation = Quaternion.Euler(bulletA.transform.rotation.x, bulletA.transform.rotation.y, -bulletA.transform.rotation.z);
                bulletA.GetComponent<BulletA>().rb.velocity = bulletA.transform.right * speedBull;
                //BulletA.rb.velocity = bulletA.transform.right * speedBull;
            }
            if (Input.GetKey("d") & Input.GetMouseButtonDown(0) & bulDcool)
            {
                bulDcool = false;
                StartCoroutine(Cooldown(2, cooldown));
                gamer.GetComponent<PlayerController>().existD = true;
                points[3] = bulletD.transform;
                timeBtwShots = startTimeBtwShots;
                bulletD.transform.rotation = this.transform.rotation;
                bulletD.transform.position = shotPoint.position;
                spriteD.GetComponent<SpriteRenderer>().enabled = true;
                spriteD.transform.rotation = Quaternion.Euler(bulletD.transform.rotation.x, bulletD.transform.rotation.y, -bulletD.transform.rotation.z);
                bulletD.GetComponent<BulletD>().rb.velocity = bulletD.transform.right * speedBull;
                //BulletD.rb.velocity = bulletD.transform.right * speedBull;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public IEnumerator Cooldown(int tip, float time)
    {
        if (tip == 1)
        {
            fillA.GetComponent<Cooldown>().StartCounter();
            yield return new WaitForSeconds(time);
            bulAcool = true;

        }
        else if (tip == 2)
        {
            fillD.GetComponent<Cooldown>().StartCounter();
            yield return new WaitForSeconds(time);
            bulDcool = true;
        }
    }
}
