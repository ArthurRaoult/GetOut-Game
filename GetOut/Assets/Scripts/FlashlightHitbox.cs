using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FlashlightHitbox : MonoBehaviour
{
    
    public GameObject Player;
    private PlayerController Pcscript;
    private PolygonCollider2D Flhitbox;
    // Start is called before the first frame update
    void Start()
    {
        Pcscript = Player.GetComponent<PlayerController>();
        Flhitbox = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Pcscript.Invis == true)
        {
            Flhitbox.enabled = false;
            
        }
        else
        {
            Flhitbox.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("RestartScene");
        }
    }
}
