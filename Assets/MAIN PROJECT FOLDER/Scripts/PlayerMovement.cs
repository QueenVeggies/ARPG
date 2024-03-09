using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script

    public float speed = 10f; //Controls velocity multiplier
    public Vector3 jump;
    public float jumpForce = 2f;

    public bool isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player

        jump = new Vector3(0f, 2f, 0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        //vertical movement
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1
        
        Vector3 movement = new Vector3(xMove, 0f, zMove).normalized;
        rb.AddForce(movement * speed * 150 * Time.deltaTime);

        if (Input.GetKey("space") && isGrounded)
        {

            rb.AddForce(jump * jumpForce * 70 * Time.deltaTime, ForceMode.Impulse);
            Debug.Log(movement);
            isGrounded = false;
        }
    }
}