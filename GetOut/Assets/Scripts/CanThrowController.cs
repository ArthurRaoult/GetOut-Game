using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanThrowController : MonoBehaviour
{
    public GameObject Player;
    public PlayerController Pcscript;
    private Rigidbody2D CanRb;
    public float ThrowSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<GameObject>();
        Pcscript.GetComponent<PlayerController>();
        CanRb.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        CanRb.transform.Translate(Vector3.right * ThrowSpeed);
    }
}
