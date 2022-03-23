using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

   private Rigidbody2D playerRb;
   private Animator playerAnimator;
   public float speed;
   public float jumpForce;
   public bool isLookLeft;
   public Transform groundCheck;
   private bool     isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxisRaw("Horizontal");
          
          if(eixoX > 0 && isLookLeft == true){
              Flip();
          }else if(eixoX < 0 && isLookLeft == false){
              Flip();
          }


        float speedY = playerRb.velocity.y;

         if(Input.GetButtonDown("Jump") && isGrounded == true){
             playerRb.AddForce(new Vector2(0,jumpForce));
         }
        
         if(Input.GetButtonDown("Fire1")){
             playerAnimator.SetTrigger("attack");
         }

        playerRb.velocity = new Vector2(eixoX * speed, speedY);


        playerAnimator.SetInteger("movX", (int)eixoX);
        playerAnimator.SetBool("isGrounded",isGrounded);
        playerAnimator.SetFloat("speedY",speedY); 
    }


    void FixedUpdate() {
       isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.02f);    
    }

    void Flip(){
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x,transform.localScale.y, transform.localScale.z);
    }
}
