using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] houses = new GameObject[0];

    private int difficultyLevel;
    private float UpdateTimer = 0;
    public int destroyedhouses = 0;
    public int score;
    public Text scoredisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer += Time.deltaTime;
        if (Time.time > 30)
        {
            difficultyLevel = 3;
        }
        else if (Time.time >10)
        {
            difficultyLevel = 2;
        }
        else{ difficultyLevel = 1; }
        
        //At a fixed update interval, Pick a random house and try to set it on fire, success chance increases with difficulty

        if (UpdateTimer > 3)
        {
           for (int i = 0; i < houses.Length; i++)
            {
                if (Random.value < 0.15 * difficultyLevel)
                {
                    houses[i].SendMessage("setOnFire");
                }
            }
            UpdateTimer = 0;
            score++;
        }

        for (int i = 0; i < houses.Length; i++)
        {
            if (houses[i].GetComponent<HouseStateController>().isDestroyed)
                destroyedhouses++;
        }

        if (destroyedhouses == houses.Length)
        { SceneManager.LoadScene("game over"); 
        }
        else
        {
            destroyedhouses = 0;
        }

        scoredisplay.text = score.ToString();
    }
}
