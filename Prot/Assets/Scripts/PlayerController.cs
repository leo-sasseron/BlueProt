using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatisGround;

    private int extraJumps;
    public int extraJumpsValue;

    public int curHealth;
    public int maxhealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        curHealth = maxhealth;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        /*Vector3 Scaler = transform.localScale; //precisei mudar pq o ponto do tiro não trocava
        Scaler.x *= -1;
        transform.localScale = Scaler;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if(curHealth > maxhealth)
        {
            curHealth = maxhealth;
        }

        if(curHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Application.LoadLevel("SampleScene");
    }

    public void Damage (int dmg)
    {
        curHealth -= dmg;
    }

    //repulsao, joga o player longe
    /*
    public IEnumerator Knockback (float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {        
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }

        yield return null;
    }
    */
}
