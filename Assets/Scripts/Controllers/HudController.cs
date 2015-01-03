using UnityEngine;
using System.Collections;

public class HudController : BaseBehavior
{
    public GameObject GameOverUi;
    public GameObject GameActiveUi;

    private GameObject _player;

    // Use this for initialization
    void Start()
    {
        if (GameOverUi != null)
            GameOverUi.SetActive(false);
        if (GameActiveUi != null)
            GameActiveUi.SetActive(false);

        _player = GameObject.Find(Constants.PlayerObjectName);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player)
        {
            // player died, show game over screen
            if (GameOverUi != null) GameOverUi.SetActive(true);
            if (GameActiveUi != null) GameActiveUi.SetActive(false);
        }
        else
        {
            if (GameOverUi != null) GameOverUi.SetActive(false);
            if (GameActiveUi != null) GameActiveUi.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Constants.GameplayScene);
    }
}
