using UnityEngine;

public class GameController : MonoBehaviour, GameCallbacks
{
    public GameOverScreen GameOverScreen;
    public PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        PlayerController.setGameCallbacks(this);
        //GameObject.FindWithTag("DamageText").text
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        GameOverScreen.Setup(20);
    }

    public void OnGameOver()
    {
        GameOver();
    }
}
