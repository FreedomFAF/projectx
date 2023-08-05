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

    public List<GameObject> attackTargets;


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
        // hotkeying between the players Constructs
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
        // movement assignments
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
        // actually moving the player 
        if (moveLocations.Count > 0){
            if (moveLocations[0] == transform.position){
                moveLocations.RemoveAt(0);
            }else{
                transform.position = Vector3.MoveTowards(transform.position, moveLocations[0], _speed * Time.deltaTime);
            }
        }

        // attack list assignment 
        if (attackTargets.Count == 0){
            List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            if (enemies.Count != 0){
                GameObject nearist;
                Vector3 nearestDisplacement;
                for (int i = 0; i < enemies.Count; i += 1){
                    // find distance between enemy and player 
                    // check it against the nearestsDisplacement 
                    // if it is less override the nearest and nearest displacement with the new nearest  
                }
                // set the nearest one to be the attackTarget
            }
        }
        // the spawn units controller should have a count of the number of enemies that are still alive
            // first thing to do is check that that is not 0 

                // do a find game objects with tag Enemy 
                // find the closest
                // assign it to the first option on the attackTargets list  


        // rotating the player towards the target or the mouse depending on the game state
        if (attackTargets.Count == 0){ // if attack targets is still empty aka no enemies to attack 
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit, Mathf.Infinity)){

                Vector3 relativePos = hit.point - player.transform.position;
                Quaternion toRotation = Quaternion.LookRotation(relativePos, Vector3.up);
                toRotation.x = 0;
                toRotation.z = 0;

                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, toRotation, _speed*Time.deltaTime);
            }
        }else{
            // rotate towards the first item in the attack targets list 
        }
    }

    // when an enemy dies it will need to be call the player object to remove itself from attack target lists
}
