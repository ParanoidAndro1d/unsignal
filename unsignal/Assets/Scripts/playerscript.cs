
using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]

  
public class playerscript : MonoBehaviour {
    
    public float speed;        
    public bool isGrounded;
    public float jump;    

    private Rigidbody2D rb2d;  
    private SpriteRenderer mySpriteRenderer;      

    void Start()
    {
    //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //FLIP SPRITE 
        if (moveHorizontal < 0)
        {
            flip();
        }
        else if (moveHorizontal > 0)
        {
            mySpriteRenderer.flipX = false;
        }

        void flip()
        { 
            mySpriteRenderer.flipX = true;
        }



        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        /*Call the AddForce function of our Rigidbody2D rb2d 
        supplying movement multiplied by speed to move our player.*/
        rb2d.AddForce (movement * speed);

                if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            
            rb2d.AddForce(new Vector3(0, jump, 0), ForceMode2D.Impulse);

            isGrounded = false;
           
            Debug.Log("in the air");
        } 

    }

        void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {

           
                isGrounded = true;
                Debug.Log ("is grounded");
            
        }
        

        }
        

    }




/*ALGORITHMS AS ANEMIES */