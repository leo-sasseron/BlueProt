using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepoint : MonoBehaviour
{
    public Transform BulletSpawner;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
     {
        StartCoroutine(Attack());
    }

     // Update is called once per frame
     void Update()
     {
            
     }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(3);
        Instantiate(bulletPrefab, BulletSpawner.position, BulletSpawner.rotation);
        StartCoroutine(Attack());
    }
}