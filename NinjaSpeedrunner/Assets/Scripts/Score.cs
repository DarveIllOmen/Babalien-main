using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text texto;
    public int currentscore = 0;
    public string sscore;

    void Start()
    {
        currentscore = GameObject.Find("value keeper").GetComponent<savevalues>().scorekept;
    }

    
    void Update()
    {
        sscore = currentscore.ToString();
        texto.text = "Score:" + sscore;
    }
}
