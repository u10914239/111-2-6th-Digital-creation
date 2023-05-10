using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mousePosition : MonoBehaviour
{
    //*遊戲基本程式
    public GameObject Search;
    public GameObject Battle;
    public GameObject Mouse;
    public Vector3 mousePositions;
    public bool Drag;
    public GameObject DragItem;
    public static bool EndBattle;
    //*遊戲關卡
    public GameObject LevelTest;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public int WhichLevel = 0;
    public bool GameStart = false;
    public Text TimeShow;
    public float TimeLeft;
    public ParticleSystem Hit;
    public float ParticleDelay = 0;
    public CameraShake cameraShake;
    public static bool BossTrigger ;
    public GameObject ResetButton;
    public int LifeCost;

    void Start()
    {
        Hit.Stop();
    }

    void Update()
    {
        
        //Debug.Log(TimeLeft);
        if(GameStart == true && TimeLeft >0)
        {
            TimeCount();
        }
        if(GameStart == true && TimeLeft <=0)
        {
            TimeCount();
        }
        if(ParticleDelay == 0 && TimeShow.text == "10")
        {
            Hit.Play();
            StartCoroutine(cameraShake.Shake(.15f,20f));
            ParticleDelay += 1;
        }
        if(ParticleDelay <= 0 && TimeShow.text == "5")
        {
            Hit.Play();
            StartCoroutine(cameraShake.Shake(.15f,20f));
            ParticleDelay += 2;
        }
        if(ParticleDelay <= 0 && TimeShow.text == "0")
        {
            Hit.Play();
            StartCoroutine(cameraShake.Shake(.15f,20f));
            EndBattle = true;
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            LifeCost = 0;
            Invoke("Translate2",1.5f);
            
            ParticleDelay += 1;
            
        }

        if(ParticleDelay>0)
        {
            ParticleDelay -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        
        mousePositions = Input.mousePosition;
        mousePositions.z = 0;
        Mouse.transform.position = Camera.main.ScreenToWorldPoint(mousePositions);
    }
    void OnTriggerEnter2D(Collider2D touch)
    {
        if(touch.gameObject.tag == "Player")
        {
            Hit.Play();
            StartCoroutine(cameraShake.Shake(.15f,20f));
            Debug.Log("touch");
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            ResetButton.SetActive(true);
            
            LifeCost += 1;
        }
        if(LifeCost >=3 && touch.gameObject.tag == "Player")
        {
            Hit.Play();
            StartCoroutine(cameraShake.Shake(.15f,20f));
            EndBattle = true;
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
             LifeCost = 0;
            Invoke("Translate2",1.5f);
           
        }
        if(touch.gameObject.tag == "Exit")
        {
            if(BossTrigger == true)
            {
                Debug.Log("Demo End");
                Debug.Log("Exit");
                EndBattle = true;
                Level1.SetActive(false);
                Level2.SetActive(false);
                Level3.SetActive(false);
                LifeCost = 0;
                Invoke("Translate4",1.5f);
                BossTrigger = false;
            }else
            {
                Debug.Log("Exit");
                EndBattle = true;
                Level1.SetActive(false);
                Level2.SetActive(false);
                Level3.SetActive(false);
                LifeCost = 0;
                Invoke("Translate3",1.5f);
            }




            
        }
        if(touch.gameObject.tag == "Start")
        {
            //LevelTest.SetActive(true);
            if(WhichLevel ==0)
            {
                WhichLevel = Random.Range(1,3);
            }
            LevelDesign();
            GameStart = true;
            TimeLeft = 15;
            ResetButton.SetActive(false);
            
        }
    }
    void TimeCount()
    {
        TimeLeft -= Time.deltaTime;
        TimeShow.text = TimeLeft.ToString("0");
    }
    void OnTriggerStay2D(Collider2D touch)
    {
        if(touch.gameObject.tag == "Player")
        {
            if(Input.GetMouseButton(0))
            {
                DragItem.transform.position = Camera.main.ScreenToWorldPoint(mousePositions);
            }
        }
    }
    void OnTriggerExit2D(Collider2D touch)
    {
        if(touch.gameObject.tag == "Player")
        {
            Debug.Log("touched");
        }
    }

    public void Translate()
    {
        Search.SetActive(true);
        Battle.SetActive(false);
    }
    public void Translate2()
    {
        SceneManager.LoadScene("Scene3");
    }
    public void Translate3()
    {
        SceneManager.LoadScene("Scene4");
    }
    public void Translate4()
    {
        SceneManager.LoadScene("Scene5");
    }
    void LevelDesign()
    {
        if(BossTrigger ==true)
        {
            Level3.SetActive(true);
        }else if(BossTrigger == false && WhichLevel ==2)
        {
            Level2.SetActive(true);
        }else if(BossTrigger == false && WhichLevel ==1)
        {
            Level1.SetActive(true);
        }
    }
}
