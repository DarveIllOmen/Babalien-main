using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rooms;

    [SerializeField]
    private GameObject entrance;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private GameObject door;

    [SerializeField]
    private int length;

    private List<GameObject> validRooms;

    private GameObject newPreviousRoom;

    private void Start()
    {
        validRooms = new List<GameObject>();

        newPreviousRoom = entrance;
        GameObject previousRoom = entrance; 
        if(length > 0)
        {
            for (int l = 0; l <= length; l++)
            {
                validRooms.Clear();
                for (int r = 0; r < rooms.Length; r++)
                {
                    bool isValid = true;
                    for (int p = 0; p < 9; p++)
                    {
                        if (previousRoom.GetComponent<LayerData>().exits[p] - rooms[r].GetComponent<LayerData>().entrances[p] == 1)
                        {
                            isValid = false;
                        }
                    }
                    if (isValid == true)
                    {
                        validRooms.Add(rooms[r]);
                    }
                }
                GameObject selectedRoom = validRooms[Random.Range(0, validRooms.Count)];

                Instantiate(selectedRoom, previousRoom.GetComponent<LayerData>().spawner.transform.position, transform.rotation);
                previousRoom = newPreviousRoom;


            }
        }
        
        Instantiate(exit, previousRoom.GetComponent<LayerData>().spawner.transform.position, transform.rotation);



        door.GetComponent<DoorController>().OpenDoor();
    }

    public void GetRoom(GameObject newRoom)
    {
        newPreviousRoom = newRoom;
    }
}
