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
    Ray ray;
    public static bool TriggerBattle;
    public GameObject MainCamera;
    public float High = 41.1f;
    void Start()
    {
        cam = GameObject.Find("Main Camera Player").GetComponent<Camera>();
        building = GameObject.Find("A1").GetComponent<Collider>();
    }

    void Update()
    {
        //transform.position = cam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,41.1f));
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider == building)
            {
                transform.position = Vector3.MoveTowards(transform.position,hit.point,20);
                transform.position = new Vector3 (transform.position.x,High,transform.position.z);
                Debug.Log(hit.point);
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x-10,MainCamera.transform.position.y,MainCamera.transform.position.z);
        }
        if(Input.GetKey(KeyCode.D))
        {
            MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x+10,MainCamera.transform.position.y,MainCamera.transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            High = High + 170.1f;
            MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x,MainCamera.transform.position.y+170.1f,MainCamera.transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            High = High - 170.1f;
            MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x,MainCamera.transform.position.y-170.1f,MainCamera.transform.position.z);
        }
    }
    void OnTriggerEnter(Collider monster)
    {
        if(monster.gameObject.tag == "Monster")
        {
            TriggerBattle = true;
        }
        if(monster.gameObject.tag == "Monster")
        {
            Invoke("Translate",2f);
        }
    }
    public void Translate()
    {
        Battle.SetActive(true);
        Search.SetActive(false);
    }

    public void CameraMoveRight()
    {
        Debug.Log("asdasdsa");
        MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x+10,MainCamera.transform.position.y,MainCamera.transform.position.z);
    }

    public void CameraMoveLeft()
    {
        MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x-10,MainCamera.transform.position.y,MainCamera.transform.position.z);
    }

}
