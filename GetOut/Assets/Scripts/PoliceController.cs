using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public float Pospeed = 50f;
    public GameObject policeman;
    public SpriteRenderer Policestate;
    public float Direction = 1f;
    public GameObject KeyGround;
    private GameObject KeyClone;
    // Start is called before the first frame update
    void Start()
    {
        Policestate = GetComponent<SpriteRenderer>();
        Policestate.flipX = false;
        Direction = -1f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * (Pospeed / 10) * Direction);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walltypeobj"))
        {
            Policestate.flipX = !Policestate.flipX;
            Direction = -Direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanThrow"))
        {
            Destroy(policeman.gameObject);
            Instantiate(KeyGround, policeman.transform.position - new Vector3 (0, -0.5f, 0), policeman.transform.rotation).SetActive(true);
        }   
    }

}
