using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class AlphaWallManager : MonoBehaviour
{
    private GameObject wallHit;
    public GameObject[] listWalls;
    public int fadeRate=20;
    public float maxRayDistance;
    public Material Palette,AlphaWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray=new Ray(transform.position,Vector3.back);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,maxRayDistance))
        {
            if(hit.transform.gameObject.CompareTag("AlphaWall"))
            {
                wallHit=hit.transform.gameObject;
            }
            else{
                wallHit=null;
            }
        }
        else{
            wallHit=null;
        }

        listWalls=GameObject.FindGameObjectsWithTag("AlphaWall");
        foreach(GameObject wall in listWalls)
        {
            if(wall==wallHit)
            {
                //gradually reduce the alpha
                wall.GetComponent<Renderer>().material=AlphaWall;
            }
            else{
                //gradually increase the alpha
                wall.GetComponent<Renderer>().material=Palette;
            }
        }
    }
    
}
