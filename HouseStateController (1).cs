using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseStateController : MonoBehaviour
{
    public bool isOnFire = false;
    public bool isBroken = false;
    public bool isDestroyed = false;

    public Mesh rubble;

    private Material[] mats;
    private float hitpoints = 5;


    // Start is called before the first frame update
    void Start()
    {
        mats = GetComponent<MeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnFire)
        {
            hitpoints -= Time.deltaTime;
            if (hitpoints < 0)
            {
                burnDown();
            }
        }
    }

    public void setOnFire()
    {
        if (!isDestroyed)
        {
            isOnFire = true;
            isBroken = true;

            for (int i = 0; i < mats.Length - 1; i++)
            {
                mats[i].SetColor("_Color", Color.red);
            }
        }
    }

    public void repair()
    {
        Debug.Log("Repairing House!");
        if (isOnFire) 
        { 
            isOnFire = false;
            for (int i = 0; i < mats.Length - 1; i++)
            {
                mats[i].SetColor("_Color", Color.grey);
            }
        }
        else if (isBroken) 
        { 
            isBroken = false;
            for (int i = 0; i < mats.Length - 1; i++)
            {
                mats[i].SetColor("_Color", Color.clear);
            }
            hitpoints = 5;
        }
    }

    public void burnDown()
    {
        if(isOnFire && !isDestroyed)
        {
            GetComponent<MeshFilter>().mesh = rubble;
            for (int i = 0; i < mats.Length - 1; i++)
            {
                mats[i].SetColor("_Color", Color.black);
            }
            isDestroyed = true;
            isOnFire = false;
        }
    }
}
