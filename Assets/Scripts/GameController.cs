using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, GameCallbacks
{
    public GameOverScreen gameOverScreen;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController.setGameCallbacks(this);
        //GameObject.FindWithTag("DamageText").text
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverScreen.Setup(20);
    }

    public void OnGameOver()
    {
        GameOver();
    }
}
