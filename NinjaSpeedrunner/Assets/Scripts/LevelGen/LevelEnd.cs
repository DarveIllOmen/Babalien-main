using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    [SerializeField]
    private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Win");
            door.GetComponent<DoorController>().OpenDoor();
        }
    }
}
