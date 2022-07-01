using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanThrowController : MonoBehaviour
{
    public GameObject Player;
    private PlayerController Pcscript;
    private Rigidbody2D CanRb;
    public float ThrowSpeed = 20f;
    public float RotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<GameObject>();
        Pcscript = Player.GetComponent<PlayerController>();
        CanRb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * ThrowSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Police")
        {
            Pcscript.TheCan.SetActive(false);
            Destroy(Pcscript.TheCan);
        }
    }
}