using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject Police;
    public PoliceController Polscript;
    public SpriteRenderer Flashlightstate;
    
    // Start is called before the first frame update
    void Start()
    {
        Police = GetComponent<GameObject>();
        Polscript = Police.GetComponent<PoliceController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Police.transform.position + new Vector3(0.5f * Polscript.Direction, 0, -0.1f);
        Flashlightstate.flipX = Polscript.Policestate.flipX;
        
    }
}
