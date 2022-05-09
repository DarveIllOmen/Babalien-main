using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerData : MonoBehaviour
{
    [Header("Entrances")]
    public int[] entrances;
    [Header("Exits")]
    public int[] exits;

    [Header("Spawner")]
    public GameObject spawner;


    private void Awake()
    {
        GameObject.Find("Generator").GetComponent<Generator>().GetRoom(this.gameObject);
    }
}
