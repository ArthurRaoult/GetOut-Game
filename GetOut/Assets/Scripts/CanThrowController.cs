using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanThrowController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Target;
    public GameObject TheCan;
    public PlayerController PCscript;
    public bool CanThrowing;

    private Vector3 spawnpos = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<GameObject>();
        Target.GetComponent<GameObject>();
        PCscript.GetComponent<PlayerController>();
        CanThrowing = false;
    }
    // Update is called once per frame
    void Update()
    {
        spawnpos = Player.transform.position;
        if (Input.GetKeyDown(KeyCode.Space) && PCscript.hastrash == true)
        {
            Debug.Log("Input Updated");
            Instantiate(TheCan, spawnpos, TheCan.transform.rotation);
            CanThrowing = true;
            transform.Translate(new Vector3(Target.transform.position.x - Player.transform.position.x, Target.transform.position.y - Player.transform.position.y, 0));
            //transform.Rotate(new Vector3(transform.RotateAround(position.x, transform.position.y, 0));
        } else if (CanThrowing == false)
        {
            transform.Translate(new Vector3(Player.transform.position.x, Player.transform.position.y, 0));
        }
    }
}
