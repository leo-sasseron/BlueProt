using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private PlayerController player;
    public GameObject bullet;    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();        
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {            
            StartCoroutine(Attack());
            //player.Damage(1);
        }     

        //ienumerator playercontroller
        //StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bullet, transform.position, transform.rotation);
        StartCoroutine(Attack());
    }  
}