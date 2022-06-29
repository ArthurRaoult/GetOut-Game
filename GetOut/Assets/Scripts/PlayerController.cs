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

    //invisibility
    public bool Invis = false;
    private float InvisStart = 0f;
    private float InvisCooldown = 8f;
    private float InvisTime = 2f;
    //color
    private SpriteRenderer PlayerState;
    public float translu = 0.25f;
    public Color Playercolorchanger = Color.white;
    //trash
    public bool hastrash = false;
    public GameObject trashcan;
    public GameObject player;
    public BoxCollider2D TrashCollision;
    public float Difficultyinteger;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        PlayerBox = GetComponent<BoxCollider2D>();
        PlayerState = GetComponent<SpriteRenderer>();
        TrashCollision = GetComponentInChildren<BoxCollider2D>();
        trashcan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Move left and right
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right  * playerSpeed * horizontalInput / 10);
            //Look left and right
            if (horizontalInput < 0) {
                PlayerState.flipX = true;
            } else if(horizontalInput > 0)
            {
                PlayerState.flipX = false;
            }
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

        if ((Input.GetKeyDown(KeyCode.W)) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isOnGround = false;

        }
        //Invisible Mechanic

            if (Input.GetKeyDown(KeyCode.Q) && Time.time > InvisStart + InvisCooldown)
            {
                Debug.Log("Hello World");
                InvisStart = Time.time;
                Invis = true;
            PlayerState.material.color = new Color (1f, 1f, 1f, translu);
                StartCoroutine(InvisCountdownRoutine());

            }
        IEnumerator InvisCountdownRoutine()
        {
            yield return new WaitForSeconds(InvisTime);
            Invis = false;
            PlayerState.material.color = new Color(1f, 1f, 1f, 1f);

        }
        //Trash Movement
        trashcan.transform.position = player.transform.position + new Vector3(-0.6f, 1.8f, 0);
        //Trash Throw

    }

    //Jump on floor
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Walltypeobj"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Trashcan") && Input.GetKeyDown(KeyCode.E) && !hastrash)
        {
            Debug.Log("Trash enabled");
            hastrash = true;
            trashcan.SetActive(true);
        }
    }
   


}
