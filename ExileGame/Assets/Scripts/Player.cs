using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator PlayerAnim;
    float RotationSpeed = 10.0f;
    Rigidbody PlayerRB;
    float PlayerSpeed = 5f;
    [SerializeField]
    GameObject MainPlayer;
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        PlayerMovement();
        MainAttackAction();
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
    void MainAttackAction()
    {
        //Make the player do a melee attack with the right click.
        if (Input.GetMouseButtonDown(1))
        {
            PlayerAnim.SetBool("IsAttacking", true);

        }
        else  
        {
            PlayerAnim.SetBool("IsAttacking", false);
        }
    }

    void StatusSystem()
    {
        //Calculate player status such as Life , Hunger , Water , Sanity etc.
    }
    void GatherResources()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnim.SetBool("IsGathering", true);

        }
        else
        {
            PlayerAnim.SetBool("IsGathering", false);
        }
    }
}
