using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    public float rotationSpeed=0.15f;
    public GameObject playerCharacter;
    private Animator playerAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnim=playerCharacter.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move.x!=0f || move.y!=0f)
        {
            movePlayer();
        }
        else{
            playerAnim.SetBool("Walking",false);
            playerAnim.SetBool("Idle",true);
        }
        
    }

    public void onMove(InputAction.CallbackContext context)
    {
        move=context.ReadValue<Vector2>();
    }

    public void movePlayer()
    {
        playerAnim.SetBool("Walking",true);
        playerAnim.SetBool("Idle",false);
        Vector3 movement=new Vector3(move.x,0f,move.y);
        transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),rotationSpeed);
        transform.Translate(movement*speed*Time.deltaTime,Space.World);
    }
}
