using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseStateController : MonoBehaviour
{
    public bool isOnFire = false;
    public bool isBroken = false;
    public bool isDestroyed = false;

    private Material mat; 


    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed)
        {
            mat.SetColor("_Color", Color.black);
        }
        else if (isOnFire)
        {
            mat.SetColor("_Color", Color.red);
        }
        else if (isBroken)
        {
            mat.SetColor("_Color", Color.grey);
        }
        else { mat.SetColor("_Color", Color.white); }
    }

    public void setOnFire()
    {
        if (!isDestroyed)
        {
            isOnFire = true;
            isBroken = true;
        }
    }

    public void repair()
    {
        Debug.Log("Repairing House!");
        if (isOnFire) 
        { 
            isOnFire = false;
        }
        else if (isBroken) 
        { 
            isBroken = false;
        }
    }

    public void burnDown()
    {
        if(isOnFire && !isDestroyed)
        {
            isDestroyed = true;
        }
    }
}
