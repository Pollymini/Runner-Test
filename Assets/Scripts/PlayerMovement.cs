using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    
    public Animator animator;
    public Rigidbody rb;
    public GameObject SD;
    public GameObject Player;
    public IUControls UI;

    public Vector3 LastPos;
    public float ThreshHold = 0.05f;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float limitValue;

    public bool Dead;
    public bool Win;
    public bool Live;
    public bool TurnR;
    public bool TurnL;
    public bool Straight;

    public float turningSpeed;
    public float lastMpose;
    public float mPos;
    private void Start()
    {
        SD = GameObject.Find("Swing Dancing");
        animator = GetComponentInChildren<Animator>();

        Player = GameObject.Find("Player");
        Player.SetActive(true);
        rb = GetComponent<Rigidbody>();

        LastPos = Player.transform.position;

        SD.SetActive(false);
        Dead = false;
        Win = false;
        Live = true;

        TurnR = false;
        TurnL = false;
        Straight = false;

        lastMpose = (Input.mousePosition.x);
        turningSpeed = 1.0f;
    }
    


    void Update()
    {
        
        mPos = (Input.mousePosition.x);

        if (Input.GetMouseButton(0) && Live)
        {
            MovePlayerWithM();
            /*MovePlayerWithUI();*/
        }


        }
        private void MovePlayerWithM()
    {
        float halfScreen = Screen.width / 2;
        
        
        float xPos = (Input.mousePosition.x - halfScreen) / halfScreen;
        float finalXPos = Mathf.Clamp(xPos * limitValue, -limitValue, limitValue);



        playerTransform.localPosition = new Vector3(finalXPos, 0, 0);

       

        if (lastMpose > mPos)
        {
            lastMpose = mPos;
            animator.SetBool("TurnR", true);
            animator.SetBool("TurnL", false);
            animator.SetBool("Straight", false);
        }

        else if (lastMpose < mPos)
        {
            lastMpose = mPos;
            animator.SetBool("TurnR", false);
            animator.SetBool("TurnL", true);
            animator.SetBool("Straight", false);
        }
        else if (lastMpose == mPos)
        {
            lastMpose = mPos;
            animator.SetBool("TurnR", false);
            animator.SetBool("TurnL", false);
            animator.SetBool("Straight", true);
        }
    }

    private void MovePlayerWithUI()
    {
        if (Input.mousePosition.x < Screen.width / 2)
        {
            playerTransform.localPosition = new Vector3(Player.transform.position.x * turningSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            rb.AddForce(new Vector3(Player.transform.position.x * -turningSpeed * Time.deltaTime, 0, 0));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            Dead = true;
            Live = false;
        }
    }
    public void Winner()
    {
        animator.SetTrigger("Win");
        Win = true;
        Live = false;
        SD.SetActive(true);
        Player.SetActive(false);
    }
}
       
           
           
            
   



    
       
        
    

