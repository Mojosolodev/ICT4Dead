using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image crouchImage;
    public Image walkImage;
    public bool walking_crouching;
    // Start is called before the first frame update
    void Start()
    {
        walking_crouching=true;
    }

    // Update is called once per frame
    void Update()
    {
        walk_Crouch_Images();
    }
    private void walk_Crouch_Images()
    {
        if(walking_crouching==true)
        {
            walkImage.enabled=true;
            crouchImage.enabled=false;
        }else if(walking_crouching==false)
        {
            walkImage.enabled=false;
            crouchImage.enabled=true;
        }
    }
    public void switch_Walk_Crouch()
    {
        //when button pressed,change bool value to change image displayed
        if(walking_crouching==true)
        {
            walking_crouching=false;
        }else if(walking_crouching==false)
        {
            walking_crouching=true;
        }
    }
}
