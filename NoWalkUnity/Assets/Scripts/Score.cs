using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public static List<string> levelScores = new List<string>();


    private void Awake()
    {
        levelScores.Add("");
        //print(levelScores);
    }
}
