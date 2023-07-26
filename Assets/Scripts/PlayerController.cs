using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 16;
    public GameObject player;
    public float turnSpeed;
    public Camera camera;

    public Vector3 lastClickedLocation;

    private void Awake(){
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        Debug.Log(camera);
        lastClickedLocation = transform.position;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)){
            Vector3 mousePosition = Input.mousePosition;
            Ray mouseClickRay = camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(mouseClickRay, out RaycastHit mouseClickHit)){
               lastClickedLocation = new Vector3(mouseClickHit.point.x, transform.position.y, mouseClickHit.point.z);
            }
        }

        if (lastClickedLocation != transform.position){
            transform.position = Vector3.MoveTowards(transform.position, lastClickedLocation, _speed * Time.deltaTime);
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
