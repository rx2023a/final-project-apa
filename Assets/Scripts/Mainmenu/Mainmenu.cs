using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Mainmenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private void OnEnable()
    {
        ShowScore();
    }
    public void QuitGame()
    {
        Debug.Log("You have quit the game\n");
        Application.Quit();
    }
    public void ShowScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            scoreText.text = $"High Score: {PlayerPrefs.GetFloat("HighScore")}";
            return;
        }
        scoreText.text = $"NO High Score Available";

    }


}
