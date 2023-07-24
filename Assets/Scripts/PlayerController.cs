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
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(direction * _speed * Time.deltaTime); 

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 400)){

            Vector3 relativePos = hit.point - player.transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            toRotation.x = 0;
            toRotation.z = 0;

            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, toRotation, _speed*Time.deltaTime);
        }
    }
}
