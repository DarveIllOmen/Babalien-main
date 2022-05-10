using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class savevalues : MonoBehaviour
{
    public int healthkept = 10;
    public int scorekept = 0;

    public bool armourgot;
    public bool doublejumpgot;
    public bool lifegot;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        healthkept = GameObject.Find("Ninja").GetComponent<PlayerController>().life;
        scorekept = GameObject.Find("Score").GetComponent<Score>().currentscore;

        armourgot = GameObject.Find("Store").GetComponent<Store>().armourbought;
        doublejumpgot = GameObject.Find("Store").GetComponent<Store>().doublejumpbought;
        lifegot = GameObject.Find("Store").GetComponent<Store>().lifebought;
    }   
}
