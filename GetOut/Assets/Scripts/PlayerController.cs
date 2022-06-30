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
    public float Direction = 1;
    public bool isCrouching = true;
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
    private BoxCollider2D TrashCollision;
    public GameObject trashhitBox;
    //Key and Door
    public bool haskey = false;
    public GameObject keyinventory;
    public GameObject keyground;
    private BoxCollider2D DoorCollision;
    public GameObject Door;
    //can throw
    public GameObject Player;
    public GameObject TheCan;
    public bool CanThrowing;
    private Rigidbody2D canRb;
    //Vent
    public GameObject Vent;
    private BoxCollider2D VentCollision;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        PlayerBox = GetComponent<BoxCollider2D>();
        PlayerState = GetComponent<SpriteRenderer>();
        TrashCollision = trashhitBox.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        DoorCollision = Door.GetComponent<BoxCollider2D>();
        VentCollision = Vent.GetComponent<BoxCollider2D>();
        
        trashcan.SetActive(false);
        keyinventory.SetActive(false);
        //can throw
        Player.GetComponent<GameObject>();
        CanThrowing = false;
        canRb = TheCan.GetComponent<Rigidbody2D>();

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
                Direction = -1;
            } else if(horizontalInput > 0)
            {
                PlayerState.flipX = false;
                Direction = 1;
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
                isCrouching = true;
            }else if (crouchInput >= 0)
            {
                transform.localScale = new Vector3(1, 2, 1);
                PlayerBox.transform.localScale = new Vector3(1, 2, 1);
                playerSpeed = 1;
                isCrouching = false;
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
        //Key Movement
        keyinventory.transform.position = player.transform.position + new Vector3(0.6f, 1.8f, 0);
        //Key Throw
        if (Input.GetKeyDown(KeyCode.Space) && hastrash == true) 
        {
            trashcan.SetActive(false);
            Debug.Log("Input Updated");
            if(PlayerState.flipX == false)
            Instantiate(TheCan, Player.transform.position, new Quaternion(0,0,0,0));
            else
            {
                Instantiate(TheCan, Player.transform.position, new Quaternion(0, 180, 0, 0));
            }
            CanThrowing = true;
            canRb.transform.Translate(new Vector3(2f, 0, 0));
            hastrash = false;
        }
        //Door Unlock

    }

    //Jump on floor
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Walltypeobj"))
        {
            isOnGround = true;
        }
    }
    //Can Collect
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Trashcan") && Input.GetKeyDown(KeyCode.E) && !hastrash)
        {
            Debug.Log("Trash enabled");
            hastrash = true;
            trashcan.SetActive(true);
        }
        if ((collision.gameObject.tag == "KeyGround") && Input.GetKeyDown(KeyCode.E) && !haskey)
        {
            Debug.Log("Key enabled");
            haskey = true;
            keyinventory.SetActive(true);
            keyground.SetActive(false);
            Destroy(GameObject.FindWithTag("KeyGround"));
        }
        if ((collision.gameObject.tag == "Door") && Input.GetKeyDown(KeyCode.E) && haskey)
        {
            keyinventory.SetActive(false);
            haskey = false;
            Destroy(Player);
        }
        if ((collision.gameObject.tag == "Vent") && (isCrouching == true) && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(Player);
        }
    }
}


