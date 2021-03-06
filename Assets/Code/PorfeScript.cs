using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float currentGravity;//Accel

    
    bool grounded;

    bool jumping;

    //float jumpSpeed;
    float jumpAccel = 1;

    float maxTimeJump;
    float timeJumping;

    bool canJump;

    float speedV;
    
    void Start()
    {
        grounded = false;
        currentGravity = -10;
        
        speedV = 0;
        jumping = false;

        maxTimeJump = 0.5f;
        timeJumping = 0;

        canJump = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -1) {
            transform.position = new Vector2(transform.position.x, -1);
            
            speedV = 0;
            grounded = true;
            canJump = true;
        }

       
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h* maxSpeed * Time.deltaTime, 0);
       
        grav();
       
        if (Input.GetButtonDown("Jump") && canJump) {
            Debug.Log("J " + Input.GetAxis("Jump"));
           
            grounded = false;
            jumping = true;
        }
        if (Input.GetButton("Jump") && canJump) {
           
                timeJumping += Time.deltaTime;

        }
        if (Input.GetButtonUp("Jump")) {
            jumping = false;
            timeJumping = 0;
            canJump = false;
        }

        if (jumping && !(timeJumping >= maxTimeJump))
         {
            speedV += jumpAccel;
           
        }

        transform.position += new Vector3(0, speedV * Time.deltaTime);
    }

    void grav() {
        if (!grounded) {
            speedV += (currentGravity*Time.deltaTime);
           
        } else {
            speedV = 0;
            timeJumping = 0;
            canJump = true;
        }
    
    }
   
}
