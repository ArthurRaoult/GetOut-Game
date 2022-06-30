using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentController : MonoBehaviour
{
    public GameObject Player;
    private PlayerController Pcscript;
    public string nextstageName;

    // Start is called before the first frame update
    void Start()
    {
        Pcscript = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pcscript.VentActive == true)
        {
            SceneManager.LoadScene(nextstageName);
            Pcscript.VentActive = false;
            Debug.Log("escape");
        }
    }
}
