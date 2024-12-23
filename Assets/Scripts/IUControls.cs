using Dreamteck.Splines.Primitives;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IUControls : MonoBehaviour
{
    public GameObject[] LvlCount;

    public SingletonSimple sS;

    public Text text;
    public int LVL;
    public GameObject DeathUI;
    public GameObject RegularUI;
    public GameObject WinUI;
    public int LvlNow;
    public PlayerMovement pm;

    public int currLvl;
    
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
        


       
    }
    void Start()
    {

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
        
        PM.Live = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        currLvl += 1;

        for (int i =0; i < LvlCount.Length; i++)
        {
            LvlCount[i].SetActive(i == sS.lvl);
        }

        

        pm.NextLVL();

        WinUI.SetActive(false);
        RegularUI.SetActive(true);
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
    public void LoadWinterLVL()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
    public void LoadSummerLVL()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void LoadSpringLVL()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

}
        
        
        

       
