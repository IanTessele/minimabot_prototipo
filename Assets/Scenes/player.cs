using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    public Vector2 jumpForce;
    public bool canJump;
    public Rigidbody2D rb;
    void Awake()
    {
        checkPlayer();    
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        jumpPlayer();
    }

    void FixedUpdate()
    {
        walkPlayer();
    }

    void walkPlayer()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;

        this.transform.position = new Vector3(
            (this.transform.position.x + h)
            , this.transform.position.y
            , 0);
    }
    void jumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    void checkPlayer()
    {
        if (!this.gameObject.GetComponent<BoxCollider2D>())
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        if (rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            gameObject.AddComponent<Rigidbody2D>();
            rb = GetComponent<Rigidbody2D>();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = false;
    }
}
