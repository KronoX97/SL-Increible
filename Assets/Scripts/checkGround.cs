using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{


    //Instancia del Script PlayerController
    private PlayerController Pcontroller;



    // Start is called before the first frame update
    void Start()
    {
        Pcontroller = GetComponentInParent<PlayerController>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Pcontroller.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Pcontroller.grounded = false;
        }
    }
}
