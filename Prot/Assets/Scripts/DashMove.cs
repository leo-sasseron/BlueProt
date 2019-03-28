using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float starDashTime;
    private int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = starDashTime;
    }

    private void Update() //limitar quantidade de dashs por tempo, e não deixar usá-los no ar.
    {
        if(direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                direction = 1;
            }else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = 2;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = starDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.AddForce( Vector2.left * dashSpeed);
                }else if(direction == 2)
                {
                    rb.AddForce( Vector2.right * dashSpeed);
                }
            }
        }
    }
}
