using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScores : MonoBehaviour
{
    public GameObject apples;
    public List<string> sp = new List<string>();
    private string ans = "";
    // Start is called before the first frame update
    void Start()
    {
        sp = Score.levelScores;
        print(sp.Count);
        for (int i = 0; i < sp.Count; i++)
        {
            if (sp[i] != "")
            {
                if (i == 0)
                {
                    ans += (i + 1).ToString() + ". " + sp[i];
                }
                else
                {
                    ans += "\n" + (i + 1).ToString() + ". " + sp[i];
                }
            }
        }
        this.GetComponent<Text>().text = ans;
    }
}
