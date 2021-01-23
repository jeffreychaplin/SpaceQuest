using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : Singleton<GameController> {

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score;

    [SerializeField]
    private Image levelImage;

    [SerializeField]
    private Sprite[] levelIcons;

    private int levelIndex;

    [SerializeField]
    private TextMeshProUGUI levelText;

    public TextMeshProUGUI ScoreText
    {
        get { return scoreText; }
    }

    public int Score
    {
        get { return score; }
        set {
            score = Mathf.Max(0, value);
            if (score <= 50) {
                levelIndex = 0;
                levelText.text = "Earth";
            } else if (score <= 204) {
                levelIndex = 1;
                levelText.text = "Rocket";
            } else if (score <= 408) {
                levelIndex = 2;
                levelText.text = "Sun";
            } else if (score <= 612) {
                levelIndex = 3;
                levelText.text = "Comet";
            } else if (score <= 816) {
                levelIndex = 4;
                levelText.text = "Galaxy";
            } else if (score == 1020) {
                levelIndex = 5;
                levelText.text = "Alien";
            }

            ScoreText.text = score.ToString();
            if (levelIndex < levelIcons.Length) {
                levelImage.sprite = levelIcons[levelIndex];
            }
        }
    }

    private void Awake() {
        SoundController.Instance.AudioSourceFX.enabled = false;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GamePause();
    }

    private void LateUpdate() {
        SoundController.Instance.AudioSourceFX.enabled = true;
    }

    public void ApplicationQuit() {
        Application.Quit();
    }

    public void GamePause(bool forcePause = false) {
        if (Input.GetKeyDown(KeyCode.Escape) || forcePause) {
            Time.timeScale = Time.timeScale == 1.0f ? 0 : 1.0f;
            //menuGamePaused.SetActive(Time.timeScale == 0);
        }
    }

    public void GameRestart() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
