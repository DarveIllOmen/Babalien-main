using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public bool armourbought;
    public bool doublejumpbought;
    public bool lifebought;

    public bool canbuy;
    void Start()
    {
        armourbought = GameObject.Find("value keeper").GetComponent<savevalues>().armourgot;
        doublejumpbought = GameObject.Find("value keeper").GetComponent<savevalues>().doublejumpgot;
        lifebought = GameObject.Find("value keeper").GetComponent<savevalues>().lifegot;
    }

    // Update is called once per frame
    void Update()
    {
        int money = GameObject.Find("Score").GetComponent<Score>().currentscore;

        if (Input.GetKey(KeyCode.Q) && armourbought == false && money>0)
        {
            armourbought = true;
            GameObject.Find("Score").GetComponent<Score>().currentscore--;
        }
        if (Input.GetKey(KeyCode.E) && doublejumpbought == false && money >0)
        {
            doublejumpbought = true;
            GameObject.Find("Score").GetComponent<Score>().currentscore--;
        }
        if (Input.GetKey(KeyCode.R) && lifebought == false && money > 0)
        {
            lifebought = true;
            GameObject.Find("Score").GetComponent<Score>().currentscore--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            canbuy = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            canbuy = false;
        }
    }
}
