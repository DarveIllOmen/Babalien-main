using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private float timer;


    private float speed;
    private bool opening;
    private float trueTimer;

    private void Start()
    {
        speed = 3.3f / timer;
        opening = false;
        trueTimer = timer;
    }

    private void Update()
    {
        if (opening && trueTimer >= 0)
        {
            if (!isOpen)
            {
                door.transform.position += Vector3.up * Time.deltaTime * speed;
            }
            else
            {
                door.transform.position += Vector3.down * Time.deltaTime * speed;
            }

            trueTimer -= Time.deltaTime;
        }
        else if(!opening)
        {
            trueTimer = timer;
        }
    }

    public void OpenDoor()
    {
        opening = true;
    }
}
