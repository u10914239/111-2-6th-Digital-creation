using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        
    }

    void Update()
    {

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
            Debug.Log("touch");
        }
        if(touch.gameObject.tag == "Exit")
        {
            Debug.Log("Exit");
            EndBattle = true;
            Invoke("Translate",1.5f);
            
        }
        if(touch.gameObject.tag == "Start")
        {
            LevelTest.SetActive(true);
        }
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
    void LevelDesign()
    {

    }
}
