using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float constMaxSpeed;
    private float maxSpeed;
    public float slowSpeed;
    public float distEnd;
    public float distStart;
    private List<GameObject> killedEnemiesA = new List<GameObject>();
    private List<GameObject> killedEnemiesD = new List<GameObject>();
    public GameObject gun;
    private LayerMask mask;
    private Vector2 direction = new Vector2(0, 0);
    private Vector2 direction1;
    private Vector2 direction2;
    private Vector2 pointA;
    private Vector2 pointD;
    private Vector2 pos;
    private Rigidbody2D rb;
    [SerializeField] private Transform bulletA;
    [SerializeField] private Transform bulletD;
    [SerializeField] private GameObject spriteA;
    [SerializeField] private GameObject spriteD;
    public Transform laserPoint;
    public float cooldown;
    //public float shtraf;
    private bool killA = false;
    private bool killD = false;
    public bool existA = false;
    public bool existD = false;
    //public bool spaceAcool = true;
    //public bool spaceDcool = true;
    private bool minCheckA = false;
    private bool minCheckD = false;
    private bool maxCheckA = false;
    private bool maxCheckD = false;
    public bool bulAcol;
    public bool bulDcol;
    private bool booldistA = false;
    private bool booldistD = false;
    void Start()
    {
        maxSpeed = constMaxSpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 0;
        mask = LayerMask.GetMask("Enemy", "Block");
        spriteA.GetComponent<SpriteRenderer>().enabled = false;
        spriteD.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        //print(transform.GetChild(1).GetComponent<Gun>().bulAcool);
        Vector2 pos1 = this.transform.position;
        Vector2 pos2A = bulletA.position;
        Vector2 pos2D = bulletD.position;
        Vector2 directionA = pos2A - pos1;
        Vector2 directionD = pos2D - pos1;
        float distA = Vector2.Distance(pos1, pos2A);
        float distD = Vector2.Distance(pos1, pos2D);
        killedEnemiesA = new List<GameObject>();
        killedEnemiesD = new List<GameObject>();
        booldistA = false;
        booldistD = false;
        RaycastHit2D[] hitsA = Physics2D.RaycastAll(this.transform.position, directionA, mask);
        if (Input.GetMouseButtonDown(1))
        {
            print("bag1");
            print(hitsA.Length);
        }
        if (hitsA.Length > 0) //bag (вроде исправил) когда т€нусь к двум пул€м, то рейкаст не находит пересечений вообще (¬ нормальном случае нашЄл 2 пересечни€, хот€ это странно)
        {
            for (int i = 0; i < hitsA.Length; i++)
            {
                RaycastHit2D hitA = hitsA[i];
                
                if (hitA.collider != null)
                {
                    
                    if (hitA.collider.gameObject.CompareTag("Enemy"))
                    {
                        killA = true; // bag
                        killedEnemiesA.Add(hitA.collider.gameObject);
                    }
                }
                
            }
        }
        RaycastHit2D[] hitsD = Physics2D.RaycastAll(this.transform.position, directionD, mask);
        if (hitsD.Length > 0)
        {
            for (int i = 0; i < hitsD.Length; i++)
            {
                RaycastHit2D hitD = hitsD[i];
                if (hitD.collider != null)
                {
                    if (hitD.collider.gameObject.CompareTag("Enemy"))
                    {
                        killD = true;
                        killedEnemiesD.Add(hitD.collider.gameObject);
                    }
                }
            }
        }
        if (killedEnemiesA.Count > 0)
            booldistA = Vector2.Distance(pos1, killedEnemiesA[0].transform.position) <= distA;
        if (killedEnemiesD.Count > 0)
            booldistD = Vector2.Distance(pos1, killedEnemiesD[0].transform.position) <= distD;
        bulAcol = bulletA.GetComponent<BulletA>().bulAcol;
        bulDcol = bulletD.GetComponent<BulletD>().bulDcol;
        if (Input.GetMouseButtonDown(1))
        {
            print(Input.GetKey("a") & existA & killA);
        }
        if (Input.GetMouseButtonDown(1) & Input.GetKey("a") & existA & killA & !bulAcol & gun.GetComponent<Gun>().bulAcool & booldistA)
        {
            //spaceAcool = false;
            //StartCoroutine(Cooldown(1, cooldown));
            gun.GetComponent<Gun>().bulAcool = false;
            StartCoroutine(gun.GetComponent<Gun>().Cooldown(1, gun.GetComponent<Gun>().cooldown));
            transform.position = bulletA.position;
            spriteA.GetComponent<SpriteRenderer>().enabled = false;
            bulletA.GetComponent<BulletA>().rb.velocity = new Vector3(0, 0, 0);
            gun.GetComponent<Gun>().points[1] = this.transform;
            existA = false;
            for (int i = 0; i < killedEnemiesA.Count; i++)
            {
                if (Vector2.Distance(pos1, killedEnemiesA[i].transform.position) <= distA)
                {
                    Destroy(killedEnemiesA[i]);
                }
            }
        }
        if (Input.GetMouseButtonDown(1) & Input.GetKey("d") & existD & killD & !bulDcol & gun.GetComponent<Gun>().bulDcool & booldistD)
        {
            //spaceDcool = false;
            //StartCoroutine(Cooldown(2, cooldown));
            gun.GetComponent<Gun>().bulDcool = false;
            StartCoroutine(gun.GetComponent<Gun>().Cooldown(2, gun.GetComponent<Gun>().cooldown));
            transform.position = bulletD.position;
            spriteD.GetComponent<SpriteRenderer>().enabled = false;
            bulletD.GetComponent<BulletD>().rb.velocity = new Vector3(0, 0, 0);
            gun.GetComponent<Gun>().points[3] = this.transform;
            existD = false;
            for (int i = 0; i < killedEnemiesD.Count; i++)
            {
                if (Vector2.Distance(pos1, killedEnemiesD[i].transform.position) <= distD)
                {
                    Destroy(killedEnemiesD[i]);
                }
            }
        }
        killA = false;
        killD = false;
    }
    void FixedUpdate()
    {
        pos = this.transform.position;
        pointA = bulletA.position;
        pointD = bulletD.position;
        minCheckA = Vector2.Distance(pos, pointA) >= distStart;
        minCheckD = Vector2.Distance(pos, pointD) >= distStart;
        maxCheckA = Vector2.Distance(pos, pointA) >= distEnd;
        maxCheckD = Vector2.Distance(pos, pointD) >= distEnd;
        
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (Input.GetKey("a") & moveA & spaceAcool & killA & gun.GetComponent<Gun>().bulAcool)
            {
                spaceAcool = false;
                StartCoroutine(Cooldown(1, cooldown));
                gun.GetComponent<Gun>().bulAcool = false;
                StartCoroutine(gun.GetComponent<Gun>().Cooldown(1, gun.GetComponent<Gun>().cooldown));
                transform.position = bulletA.position;
                bulletA.GetComponent<BulletA>().render.enabled = false;
                bulletA.GetComponent<BulletA>().rb.velocity = new Vector3(0, 0, 0);
                gun.GetComponent<Gun>().points[1] = this.transform;
                moveA = false;
                Destroy(killedEnemy); 
            }
            else if (Input.GetKey("d") & moveD & spaceDcool & killD & gun.GetComponent<Gun>().bulDcool)
            {
                spaceDcool = false;
                StartCoroutine(Cooldown(2, cooldown));
                gun.GetComponent<Gun>().bulDcool = false;
                StartCoroutine(gun.GetComponent<Gun>().Cooldown(2, gun.GetComponent<Gun>().cooldown));
                transform.position = bulletD.position;
                bulletD.GetComponent<BulletD>().render.enabled = false;
                bulletD.GetComponent<BulletD>().rb.velocity = new Vector3(0, 0, 0);
                gun.GetComponent<Gun>().points[3] = this.transform;
                moveD = false;
                Destroy(killedEnemy);
            }
        }
        */
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            maxSpeed = constMaxSpeed;
            if (Input.GetKey("a") & Input.GetKey("d") & minCheckA & minCheckD & existA & existD)
            {
                direction1 = (pointA - pos).normalized;
                direction2 = (pointD - pos).normalized;
                direction = direction1 + direction2;
                rb.MovePosition(rb.position + direction * maxSpeed * Time.fixedDeltaTime);
            }
            else if (Input.GetKey("a") & existA)
            {
                direction = (pointA - pos).normalized;
                if (!minCheckA)
                {
                    maxSpeed = gun.GetComponent<Gun>().speedBull;
                }
                rb.MovePosition(rb.position + direction * maxSpeed * Time.fixedDeltaTime);
            }
            else if (Input.GetKey("d") & existD)
            {
                direction = (pointD - pos).normalized;
                if (!minCheckD)
                {
                    maxSpeed = gun.GetComponent<Gun>().speedBull;
                }
                rb.MovePosition(rb.position + direction * maxSpeed * Time.fixedDeltaTime);
            }
            /*
            else if (!minCheckA || !minCheckD)
            {
                maxSpeed = gun.GetComponent<Gun>().speedBull;
                rb.MovePosition(rb.position + direction * maxSpeed * Time.fixedDeltaTime);
                //StartCoroutine(Cooldown(3, shtraf));
            }
            */
            else
            {
                rb.MovePosition(rb.position + direction * slowSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {

            if (maxCheckA & maxCheckD & existA & existD)
            {
                direction1 = (pointA - pos).normalized;
                direction2 = (pointD - pos).normalized;
                direction = direction1 + direction2;
            }
            else if (maxCheckA & existA)
            {
                direction = (pointA - pos).normalized;
            }
            else if (maxCheckD & existD)
            {
                direction = (pointD - pos).normalized;
            }
            rb.MovePosition(rb.position + direction * slowSpeed * Time.fixedDeltaTime);
        }
    }
    
    IEnumerator Cooldown(int tip, float time)
    {
        yield return new WaitForSeconds(time);
        //if (tip == 1)
        //{
        //    spaceAcool = true;
        //}
        //else if (tip == 2)
        //{
        //    spaceDcool = true;
        //}
    }
    
}