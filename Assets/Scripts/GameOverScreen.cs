using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI PointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        PointsText.text = score.ToString() + "POINTS";
    }

    public void RestartButtonOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButtonOnClick()
    {
        // SceneManager.LoadScene("MainMenu");
    }
}
