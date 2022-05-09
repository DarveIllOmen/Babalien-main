using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float timer = 7f;
    private void Start()
    {
        GameObject ninja = GameObject.Find("Ninja");

        transform.LookAt(ninja.transform.position + Vector3.up);
    }

    private void Update()
    {
        timer = timer - Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
