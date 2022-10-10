using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour
{
    public GameObject[] players;
    private int turn;
    public Text timerText;
    private float playTimer;

    public float turnTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increase timer
        playTimer += Time.deltaTime;
        timerText.text = "Time left: " + (turnTime - Mathf.RoundToInt(playTimer));


        if (players[turn] != null && players[(turn + 1) % 2] != null)
        {
            // Active player
            players[turn].GetComponent<ThirdPersonMovement>().canMove = true;
            
            

            // Inactive player
            players[(turn + 1) % 2].GetComponent<ThirdPersonMovement>().canMove = false;
            
            

            // Changes turn after 10s
            if(playTimer > turnTime)
            {
                turn = ((turn + 1) % 2);
                playTimer = 0;
            }
        }
       


        // Win check
        if (players[0] == null)
        {
            
            print("player 2 won!");
        }
        else if (players[1] == null)
        {
            
            print("player 1 won!");
        }
    }
}
