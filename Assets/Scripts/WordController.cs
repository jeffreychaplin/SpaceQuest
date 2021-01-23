using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordController : Singleton<WordController> {

	public List<Word> words;

	public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;
    public bool isAcceptingKeys;

    private bool isCorrectAnswer;

    [SerializeField]
    private Question activeQuestion;

    [SerializeField]
    private TextMeshProUGUI questionText;

    private WordTimer wordTimer;

    public Question ActiveQuestion {
        get { return activeQuestion;  }
    }

    public bool IsAcceptingKeys {
        get { return isAcceptingKeys; }
        set {
            if (value != isAcceptingKeys && value) {
                SoundController.Instance.PlayAudioClipFX("QuestionReady");
            }
            isAcceptingKeys = value;
        }
    }
       
    public void Start() {
        isAcceptingKeys = false;
        questionText.fontSize = 24;

        wordTimer = gameObject.GetComponent<WordTimer>();
        Debug.Log("START WordManager");
        WordGenerator.LoadQuestions();

        activeQuestion = WordGenerator.GetRandomQuestion();
        questionText.text = "";
        isCorrectAnswer = false;
        GameController.Instance.Score = 0;
    }

    private void Update() {
        if (isAcceptingKeys) {
            questionText.color = Color.white;
        } else {
            questionText.color = Color.black;
        }
    }

    public void AddWord (string _word = null)
	{
        Word word = new Word(_word, wordSpawner.SpawnWord());

		words.Add(word);
	}

    public void ShowQuestion() {
        questionText.text = activeQuestion.question;
        //SoundController.Instance.PlayAudioClipFX("DangerZoneTeleport2");
    }

	public void TypeLetter (char letter)
	{
        if (isAcceptingKeys) {
            if (hasActiveWord) {
                if (activeWord.GetNextLetter() == letter) {
                    activeWord.TypeLetter();
                }
            }
            else {
                foreach (Word word in words) {
                    if (word.GetNextLetter() == letter) {
                        activeWord = word;
                        hasActiveWord = true;

                        word.TypeLetter();
                        break;
                    }
                }
            }

            if (hasActiveWord && activeWord.WordTyped()) {

                if (!isCorrectAnswer && activeWord.word.ToUpper() == ActiveQuestion.answers[0].ToUpper()) {
                    isCorrectAnswer = true;
                    SoundController.Instance.PlayAudioClipFX("QuestionCorrect");
                    GameController.Instance.Score += words.Count * 10;
                    GameController.Instance.ScoreText.text = GameController.Instance.Score.ToString();
                    NextQuestion();
                }
                else {
                    isCorrectAnswer = false;
                    RemoveActiveWord();
                }
            }
        }
	}

    public void RemoveWord(string _word) {
        foreach (Word word in words) {
            if (word.word == _word) {
                words.Remove(word);
                word.RemoveDisplay();
                hasActiveWord = false;
                activeWord = null;
                isCorrectAnswer = false;

                break;
            }
        }
        if (words.Count == 0) {
            NextQuestion();
        }
    }

    public void RemoveActiveWord() {
        hasActiveWord = false;
        words.Remove(activeWord);
        if (words.Count == 0) {
            NextQuestion();
        }
    }

    public void NextQuestion() {
        hasActiveWord = false;
        isCorrectAnswer = false;
        foreach (Word word in words) {
            word.RemoveDisplay();
        }
        words.Clear();
        activeQuestion = WordGenerator.GetRandomQuestion();
        if (activeQuestion.question != null) {
            wordTimer.PossibleAnswers = activeQuestion.answers;
            ShowQuestion();
        } else {
            questionText.fontSize = 48;
            questionText.text = "GAME OVER";
            Debug.Log(questionText.text);
            GameController.Instance.GamePause(true);
        }

    }
}
