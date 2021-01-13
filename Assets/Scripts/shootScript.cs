using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireRate = 0.3f;
    public float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.unscaledTime > nextFire)
        {
            nextFire = Time.unscaledTime + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
