using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 16;
    public GameObject player;
    public float turnSpeed;
    public Camera camera;

    private void Awake(){
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        Debug.Log(camera);
    }

    private void Update() {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 400)){
            Debug.Log(hit.point);
            Debug.Log("hitting the floor");
            Vector3 relativePos = hit.point - player.transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos, Vector3.up);

            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, toRotation, _speed*Time.deltaTime);
        }
    }
}
