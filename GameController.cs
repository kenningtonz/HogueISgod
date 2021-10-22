using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] houses = new GameObject[0];

    private int difficultyLevel;
    private float UpdateTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer += Time.deltaTime;
        if (Time.time > 180)
        {
            difficultyLevel = 3;
        }
        else if (Time.time > 120)
        {
            difficultyLevel = 2;
        }
        else{ difficultyLevel = 1; }
        
        //At a fixed update interval, Pick a random house and try to set it on fire, success chance increases with difficulty

        if (UpdateTimer > 3)
        {
            int i = Random.Range(0, houses.Length - 1);
            if (Random.value < 0.3 * difficultyLevel)
            {
                houses[i].SendMessage("setOnFire");
            }
            else
            {
                Debug.Log("the house didn't catch");
            }
            UpdateTimer = 0;
        }
    }
}
