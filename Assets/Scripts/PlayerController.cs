using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 16;
    public static int indexCount = 0;
    public int characterIndex;

    public bool selected = false;
    public GameObject player;
    public float turnSpeed;
    public Camera camera;
    
    public Behaviour halo;

    public List<Vector3> moveLocations;

    public GameObject attackTarget;


    private void Awake(){
        PlayerController.indexCount += 1;
        characterIndex = PlayerController.indexCount;
        
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        Debug.Log(camera);
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;

        if (characterIndex == 1){
            selected = true;
            halo.enabled = true;
        }
    }

    private void Update() {
        if (Input.GetKeyDown("1")){
            if (characterIndex == 1){
                selected = true;
                halo.enabled = true;
            }else{
                selected = false;
                halo.enabled = false;
            }
        }else if (Input.GetKeyDown("2")){
            if (characterIndex == 2){
                selected = true;
                halo.enabled = true;
            }else{
                selected = false;
                halo.enabled = false;
            }
        }

        if (Input.GetMouseButtonDown(1) && selected){
            Vector3 mousePosition = Input.mousePosition;
            Ray mouseClickRay = camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(mouseClickRay, out RaycastHit mouseClickHit)){
                if (Input.GetKey("left shift")){
                    moveLocations.Add(new Vector3(mouseClickHit.point.x, transform.position.y, mouseClickHit.point.z));
                }else{
                    moveLocations.Clear();
                    moveLocations.Add(new Vector3(mouseClickHit.point.x, transform.position.y, mouseClickHit.point.z));
                }
            }
        }

        if (moveLocations.Count > 0){
            if (moveLocations[0] == transform.position){
                moveLocations.RemoveAt(0);
            }else{
                transform.position = Vector3.MoveTowards(transform.position, moveLocations[0], _speed * Time.deltaTime);
            }
        }

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, Mathf.Infinity)){

            Vector3 relativePos = hit.point - player.transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            toRotation.x = 0;
            toRotation.z = 0;

            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, toRotation, _speed*Time.deltaTime);
        }
    }
}
