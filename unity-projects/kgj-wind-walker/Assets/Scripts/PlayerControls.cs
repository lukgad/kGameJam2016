using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    public Vector2 jumpForce = new Vector2(0, 300);
    private bool isJumping = false;
    private ScrollingScript scroll;

    void Awake()
    {
        var difficulty = GameplayControl.Instance;
        scroll = GetComponent<ScrollingScript>();
    }
    void Start()
    {
        GetComponentInChildren<Animator>().SetBool("Running", true);
    }

    // Update is called once per frame
    void Update()
    {
       
        var jumpPressed = Input.GetButtonDown("Jump");
        if (jumpPressed && !isJumping)
        {
            Debug.Log(jumpPressed);
            isJumping = true;
            //jumpTime = Time.time + jumpDuration;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            SoundEffectsHelper.Instance.MakeJumpSound();
        }

    }

    void FixedUpdate()
    {
        
    }

    public void GoBack()
    {
        Debug.Log("going back");
        var trans = transform.Find("RunneyWhole").transform;
        Quaternion temp = trans.rotation;
        temp.y = 180;
        trans.rotation = temp;
        var scroll = GetComponent<ScrollingScript>();
        scroll.StartMoving();
        scroll.Reverse();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "groundTag")
        {
            isJumping = false;
            SoundEffectsHelper.Instance.MakeRunnningSound();
        }
        if (other.gameObject.tag == "wellTag")
        {
            isJumping = false;
            other.gameObject.GetComponentInParent<WellControls>().DebugTime();
            other.gameObject.GetComponentInParent<WellControls>().touched = true;
            scroll.isLinkedToCamera = true;
            GetComponent<ScrollingScript>().speed = Vector2.zero;
            GameplayControl.Instance.StopBackground();
            GameplayControl.Instance.StopGround();
            GameplayControl.Instance.InitReverseRun();
        }

        if (other.gameObject.tag == "waterTarget")
        {
            isJumping = false;
            other.gameObject.GetComponentInParent<WaterTargetControl>().DebugTime();
            other.gameObject.GetComponentInParent<WaterTargetControl>().touched = true;
            scroll.isLinkedToCamera = true;
            GetComponent<ScrollingScript>().speed = Vector2.zero;
            GameplayControl.Instance.StopBackground();
            GameplayControl.Instance.StopGround();
            GameplayControl.Instance.GetComponent<TimeController>().StopTimer();
            Application.LoadLevel("RitualScene");

        }

        if(other.gameObject.tag == "groundEnemy")
        {
            DestroyObject(other.gameObject);
            GameplayControl.Instance.GetComponent<TimeController>().collisionWithObstacle();
        }
    }

}
