using Dreamteck.Splines.Primitives;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IUControls : MonoBehaviour
{
    public Text text;
    public int LVL;
    public GameObject DeathUI;
    public GameObject RegularUI;
    public GameObject WinUI;
    public int LvlNow;
    
    PlayerMovement PM;
    // Start is called before the first frame update
    private void Awake()
    {
        PM = GameObject.Find("Player").GetComponent<PlayerMovement>();
        RegularUI.SetActive(true);
        DeathUI.SetActive(false);
        WinUI.SetActive(false);
        LVL = SceneManager.GetActiveScene().buildIndex;
        LvlNow = LVL++;
        LVLCheck();
    }
    void Start()
    {

        
       
    }
    public void LVLCheck()
    {
        text.text = "Level " + LvlNow.ToString() ;
        /*if (LVL < 0)
        {
            text.text = "Level 1";
        }
        else if (LVL > 1)
        {
            text.text = "Level 3";
        }
        else
        {
            text.text = "Level 2";
        }*/


    }

    public void Death()
    {
            RegularUI.SetActive(false);
            DeathUI.SetActive(true);
            Time.timeScale = 0f;
    }
    public void WinLVL()
    {
        RegularUI.SetActive(false);
        WinUI.SetActive(true);
    }
    public void Restart()
    {
        PM.Dead = false;
        PM.Live = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        
    }
    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PM.Live = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    void Update()
    {
        if (PM.Dead)
        {
            Death();
        }
        if (PM.Win)
        {
            WinLVL();
        }
        
    }

}
        
        
        

       
