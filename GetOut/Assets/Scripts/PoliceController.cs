using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public float Pospeed = 50f;
    public GameObject policeman;
    public SpriteRenderer Policestate;
    private float Direction = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Policestate = GetComponent<SpriteRenderer>();
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
}
