using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 100f;
    public float jumpHeight = 5f;

    private Rigidbody2D playerRb;
    public bool isOnGround = true;
    private BoxCollider2D PlayerBox;
    public bool Invis = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        PlayerBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move left and right
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right  * playerSpeed * horizontalInput / 10);
        }
        //Crouching
        {
            float crouchInput = Input.GetAxis("Vertical");
            if (crouchInput < 0)
            {
                transform.localScale = new Vector3(1,1,1);
                PlayerBox.transform.localScale = new Vector3(1, 1, 1);
                playerSpeed = 0.5f;
            }else if (crouchInput >= 0)
            {
                transform.localScale = new Vector3(1, 2, 1);
                PlayerBox.transform.localScale = new Vector3(1, 2, 1);
                playerSpeed = 1;
            }
        }
        
        //Jump Mechanic

        if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W))) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isOnGround = false;
        //Invisible Mechanic

        if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Hello World");
                Invis = true;
                StartCoroutine(InvisCountdownRoutine());
                
            }
        }

        IEnumerator InvisCountdownRoutine()
        {
            yield return new WaitForSeconds(2);
            Invis = false;
            PlayerBox.enabled = true;
        }
    }
    //Jump on floor
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Invis)
        {

        }
    }

}
