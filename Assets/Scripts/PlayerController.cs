using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //velocidad del objeto [a,d]
    public float speed = 25f;

    //velocidad maxima que no debe superar el objeto
    public float maxspeed = 5f;

    //Fuerza de salto que tendrá el objeto [SpaceBar]
    public float jumpForce = 5f;

    //Valor que define si el objeto está en tocando el suelo o no
    public bool grounded;
    

    //componente de masas de objeto
    private Rigidbody2D rb2D;

    //componente de animaciones del objeto
    private Animator anim;

    //coordenada horizontal del objeto
    private float x;
    



    void Start()
    {
        //relacionamos el componente animator y el componente de masas
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("grounded", grounded);
    }

    void FixedUpdate()
    {

        x = Input.GetAxis("Horizontal");
        rb2D.AddForce(Vector2.right * speed * x);

        if(x < 0){
            
        }

        //Comprobación y corrección de que no supere la velocidad máxima en positivo
        float limitedSpeed = Mathf.Clamp(rb2D.velocity.x, -maxspeed, maxspeed);
        rb2D.velocity = new Vector2(limitedSpeed , rb2D.velocity.y);

        if(x > 0.1f)
        {
            transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        } 
        if(x < -0.1f)
        {
            transform.localScale = new Vector3(-1.5f,1.5f,1.5f);
        }

        //Adición de fuerza de salto a el objeto
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1)){
            rb2D.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
        }
    }
}
