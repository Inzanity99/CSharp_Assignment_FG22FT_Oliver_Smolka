using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class TurnManager : MonoBehaviour
{
    public GameObject[] players;
    private int turn;
    public Text timerText;
    private float playTimer;
    public TextMeshProUGUI gameOverText;

    public ShurikenProjectile[] weapons;

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
            weapons[turn].enabled = true;
            
            

            // Inactive player
            players[(turn + 1) % 2].GetComponent<ThirdPersonMovement>().canMove = false;
            weapons[(turn + 1) % 2].enabled = false;
            weapons[(turn + 1) % 2].hasFired = false;
            

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
            
            gameOverText.text = "Player 2 won!";
            Invoke("LoadMenu", 2f);
        }
        else if (players[1] == null)
        {
            
            gameOverText.text = "Player 1 won!";
            Invoke("LoadMenu", 2f);
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
