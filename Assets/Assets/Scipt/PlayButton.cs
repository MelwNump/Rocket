using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        // Add a listener to the play button
        playButton.onClick.AddListener(LoadGamePlayScene);
    }

    void LoadGamePlayScene()
    {
        // Load the GamePlay scene
        SceneManager.LoadScene("GamePlay");
    }
}