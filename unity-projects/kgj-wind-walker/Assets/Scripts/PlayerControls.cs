using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    public Vector2 jumpForce = new Vector2(0, 100);
    private bool isJumping = false;
    public float jumpDuration = 0.1f;
    private float jumpTime = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var jumpPressed = Input.GetButtonDown("Jump");
        if (jumpPressed && !isJumping)
        {
            Debug.Log(jumpPressed);
            isJumping = true;
            jumpTime = Time.time + jumpDuration;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (isJumping)
        {
            if (jumpTime >= Time.time)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(jumpForce);

            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().gravityScale = 4;
                isJumping = false;
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something has entered this zone.");
        //other.gameObject.tag maybe??
    }

}
