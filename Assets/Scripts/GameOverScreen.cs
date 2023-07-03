using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";
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
