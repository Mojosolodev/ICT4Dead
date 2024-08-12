using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float maximumSpeed;
    private Vector2 move;
    public float rotationSpeed=0.15f;
    public GameObject playerCharacter;
    private Animator playerAnim;
    public UiManager UImanagerScript;
    public float crouchFactor=0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnim=playerCharacter.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if(UImanagerScript.walking_crouching==true)
        {
            playerAnim.SetLayerWeight(1,Mathf.Lerp(playerAnim.GetLayerWeight(1),0f,Time.deltaTime*10f));
        }
        else if(UImanagerScript.walking_crouching==false)
        {
            playerAnim.SetLayerWeight(1,Mathf.Lerp(playerAnim.GetLayerWeight(1),1f,Time.deltaTime*10f));
        }
    }

    public void onMove(InputAction.CallbackContext context)
    {
        move=context.ReadValue<Vector2>();
    }

    public void movePlayer()
    {
        
        Vector3 movement=new Vector3(move.x,0f,move.y);

        float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        
        //only if joystick input is high enough to avoid little motion
        //on walking layer
        if(inputMagnitude>=0.3f && UImanagerScript.walking_crouching==true)
        {
            //play walk
            playerAnim.SetBool("Walking",true);
            playerAnim.SetBool("Idle",false);
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),rotationSpeed);
            transform.position+=transform.forward*Time.deltaTime*maximumSpeed;
        }
        else if(inputMagnitude<0.3f && UImanagerScript.walking_crouching==true)
        {
            //stay on Walk idle
            playerAnim.SetBool("Walking",false);
            playerAnim.SetBool("Idle",true);
        }
        //on Crouching Layer
        if(inputMagnitude>=0.3f && UImanagerScript.walking_crouching==false)
        {
            //play crouch walk
            playerAnim.SetBool("Crouching",true);
            playerAnim.SetBool("Idle",false);
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),rotationSpeed);
            //while crouching,moves slower
            transform.position+=transform.forward*Time.deltaTime*maximumSpeed*crouchFactor;
        }
        else if(inputMagnitude<0.3f && UImanagerScript.walking_crouching==false)
        {
            //stay on Crouch idle
            playerAnim.SetBool("Crouching",false);
            playerAnim.SetBool("Idle",true);
        }
        
        
    }
}
