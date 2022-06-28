using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHitbox : MonoBehaviour
{
    
    public GameObject Player;
    public PlayerController Pcscript;
    private BoxCollider2D Flhitbox;
    // Start is called before the first frame update
    void Start()
    {
        Pcscript = Player.GetComponent<PlayerController>();
        Flhitbox = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Pcscript.Invis == true)
        {
            Flhitbox.enabled = false;
        }
        else if (Pcscript.Invis == false)
        {
            Flhitbox.enabled = true;
        }
    }
  
}
