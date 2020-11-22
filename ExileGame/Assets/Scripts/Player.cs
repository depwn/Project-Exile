using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Collider PlayerCol;
    Animator PlayerAnim;
    [SerializeField]
    Animation Idle;
    float RotationSpeed = 10.0f;
    float PlayerSpeed = 5f;
    
    [SerializeField]
    GameObject MainPlayer;
    public Camera cam;
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        //Idle = GetComponent<Animation>();
    }

    private void FixedUpdate()
    {
        
        PlayerMovement();
        LeftClickAction();
        //RightClickAction();
        GatherResources();
        //StatusSystem();
    }
    void PlayerMovement()
    {
        float XDir = Input.GetAxis("Horizontal");
        float ZDir = Input.GetAxis("Vertical");
        Vector3 MoveDir = new Vector3(XDir, 0.0f, ZDir);
        transform.position += MoveDir * PlayerSpeed * Time.deltaTime;
        if (MoveDir!= Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDir), RotationSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            PlayerAnim.SetBool("IsWalking", true);
        }
        else
        {
            PlayerAnim.SetBool("IsWalking", false);
        }
    }
    
    
    void LeftClickAction()
    {
        //TO DO: Move this to the AXE Scriptable object's left click
        if (Input.GetMouseButtonDown(0)) {
            //Idle.Stop();
            PlayerAnim.SetBool("IsAttacking", true);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.CompareTag("Interactable")) {                    
                    StartCoroutine(WaitAndDestroy(hitObject, 1.5f));                    
                }
            }
        }
        else {
            PlayerAnim.SetBool("IsAttacking", false);
        }
    }
    //Delay the destruction of Interactable to line up with the animation WIP
    IEnumerator WaitAndDestroy(GameObject obj,float time) {
        // suspend execution for 'time' seconds
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }

    void StatusSystem()
    {
        //Calculate player status such as Life , Hunger , Water , Sanity etc.
    }
    void GatherResources()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerAnim.SetBool("IsGathering", true);

        }
        else
        {
            PlayerAnim.SetBool("IsGathering", false);
        }
    }
}
