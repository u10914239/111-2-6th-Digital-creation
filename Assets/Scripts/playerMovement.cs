using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject Search;
    public GameObject SearchCam;
    public GameObject BattleCam;
    public GameObject Battle;
    Camera cam;
    Collider building;
    RaycastHit hit;
    public Vector3 Mouse;
    Ray ray;
    public static bool TriggerBattle;
    public GameObject MainCamera;
    public float High = 41.1f;
    public GameObject Player;
    public LayerMask LayerToHit;
    
    public bool TransformDelay = false;
    
    void Start()
    {
        cam = GameObject.Find("Main Camera Player").GetComponent<Camera>();
        building = GameObject.Find("A1").GetComponent<Collider>();
    }

    void Update()
    {
        //transform.position = cam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,41.1f));
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Mouse = Input.mousePosition;
        //Debug.Log(Mouse);
        if(Physics.Raycast(ray, out hit,10000f,LayerToHit))
        {
            if(hit.collider == building && Mouse.x > 0 && Mouse.x < 1920 && Mouse.y >180)
            {
                transform.position = Vector3.MoveTowards(transform.position,hit.point,20);
                transform.position = new Vector3 (transform.position.x,High,transform.position.z);
                //Debug.Log(Mouse);
            }
        }
        //Debug.Log(MainCamera.transform.position);
        if(Input.GetKey(KeyCode.A) && MainCamera.transform.position.x>160 && MainCamera.transform.position.x < 1370)
        {
            MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x-1,MainCamera.transform.position.y,MainCamera.transform.position.z);
        }
        if(Input.GetKey(KeyCode.D) && MainCamera.transform.position.x> 150 && MainCamera.transform.position.x < 1360)
        {
            MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x+1,MainCamera.transform.position.y,MainCamera.transform.position.z);
        }
        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //    High = High + 170.1f;
        //    MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x,MainCamera.transform.position.y+170.1f,MainCamera.transform.position.z);
        // }
        //if(Input.GetKeyDown(KeyCode.S))
        //{
        //    High = High - 170.1f;
        //    MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x,MainCamera.transform.position.y-170.1f,MainCamera.transform.position.z);
        //}
    }
    void OnTriggerEnter(Collider monster)
    {
        if(TransformDelay == false && monster.gameObject.tag == "Monster")
        {
            TriggerBattle = true;
        }
        if(TransformDelay == false && monster.gameObject.tag == "Monster")
        {

            Invoke("Translate",2f);
            TransformDelay = true;
        }
        if(TransformDelay == false && monster.gameObject.tag == "Boss")
        {
            mousePosition.BossTrigger = true;
            TriggerBattle = true;
            
        }
        if(TransformDelay == false && monster.gameObject.tag == "Boss")
        {
            mousePosition.BossTrigger = true;
            Invoke("Translate",2f);
            TransformDelay = true;
        }
    }

    public void Translate()
    {
        Battle.SetActive(true);
        TransformDelay = false;
        Search.SetActive(false);
    }

    public void CameraMoveRight()
    {
        //Debug.Log("asdasdsa");
        MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x+0.01f,MainCamera.transform.position.y,MainCamera.transform.position.z);
    }

    public void CameraMoveLeft()
    {
        MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x-0.01f,MainCamera.transform.position.y,MainCamera.transform.position.z);
    }

}
