using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplesCounter : MonoBehaviour
{
    [SerializeField] private GameObject apples;
    public static int ateApples = 0;
    public static int maxApples = 0;
    // Start is called before the first frame update
    void Start()
    {
        ateApples = 0;
        maxApples = apples.transform.childCount;
        Score.levelScores[Score.levelScores.Count - 1] = ateApples.ToString("D2") + "/" + maxApples.ToString("D2");
        apples.GetComponent<Score>().score.text = ateApples.ToString("D2") + "/" + maxApples.ToString("D2");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ateApples += 1;
            //print(apples.GetComponent<Score>().levelScores.Count - 1);
            Score.levelScores[Score.levelScores.Count - 1] = ateApples.ToString("D2") + "/" + maxApples.ToString("D2");
            apples.GetComponent<Score>().score.text = ateApples.ToString("D2") + "/" + maxApples.ToString("D2");
            Destroy(this.gameObject);
        }
    }
}
