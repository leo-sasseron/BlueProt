using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public string Tag;
    public float offset;

    public Transform BulletSpawner;
    public GameObject bulletPrefab;

    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;    

    // Start is called before the first frame update
    void Start()
     {
        target = GameObject.FindGameObjectWithTag(Tag).GetComponent<Transform>();        
    }

     // Update is called once per frame
     void Update()
     {
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {        
        Instantiate(bulletPrefab, BulletSpawner.position, BulletSpawner.rotation);
    }
}