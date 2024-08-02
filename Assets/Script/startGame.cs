using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI intro;
    [SerializeField] private Button playButton;
    [SerializeField] private Button startGameButton;
    public void ShowIntro()
    {
        title.gameObject.SetActive(false);
        intro.gameObject.SetActive(true);
        startGameButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
    }

    public void LoadChapterOne()
    {
        SceneManager.LoadScene(1);
    }
}
