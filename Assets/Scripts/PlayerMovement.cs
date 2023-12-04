using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    
    public Animator animator;
    public Rigidbody rb;
    public GameObject SD;
    public GameObject Player;
    public IUControls UI;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float limitValue;

    public bool Dead;
    public bool Win;
    public bool Live;

    private void Start()
    {
        SD = GameObject.Find("Swing Dancing");
        animator = GetComponentInChildren<Animator>();

        Player = GameObject.Find("Player");
        Player.SetActive(true);

        SD.SetActive(false);
        Dead = false;
        Win = false;
        Live = true;
    }
    


    void Update()
    {

        if (Input.GetMouseButton(0) && Live)
        {
            MovePlayer();

        }
      
    }
    private void MovePlayer()
    {
        float halfScreen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreen) / halfScreen;
        float finalXPos = Mathf.Clamp(xPos * limitValue, -limitValue, limitValue);

        playerTransform.localPosition = new Vector3(finalXPos, 0, 0);    
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
       
           
           
            
   



    
       
        
    

