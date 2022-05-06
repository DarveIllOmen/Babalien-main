using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private float turningSpeed;

    [SerializeField]
    private float shootingSpeed;

    [SerializeField]
    private GameObject turretHead;

    [SerializeField]
    private GameObject bullet;

    private GameObject ninja;

    private float timer;

    private void Start()
    {
        ninja = GameObject.Find("Ninja");
        timer = shootingSpeed;
    }

    private void Update()
    {
        //turretHead.transform.Rotate((new Vector3(0, turningSpeed, 0) * Time.deltaTime), Space.World);

        //turretHead.transform.Rotate((new Vector3(turningSpeed, 0, 0) * Time.deltaTime * Mathf.Sin(Time.time)), Space.Self);

        Vector3 direction = (ninja.transform.position + Vector3.up - turretHead.transform.position);
        direction.Normalize();
        turretHead.transform.forward = Vector3.Lerp(turretHead.transform.forward, direction, turningSpeed * Time.deltaTime);


        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = shootingSpeed;

            Instantiate(bullet, turretHead.transform.position, transform.rotation);
        }
    }
}
