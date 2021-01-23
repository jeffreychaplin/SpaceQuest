using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {

	public WordController wordController;

	public float wordDelay = 3f;
    public int maxWords;

    private float nextWordTime = 0f;
    private int index;

    private string[] possibleAnswers;
    public string[] PossibleAnswers {
        get { return possibleAnswers; }
        set {
            index = 0;
            possibleAnswers = KnuthShuffle<string>(value);
            Debug.Log("ANSWER= " + WordController.Instance.ActiveQuestion.answers[0]);
        }
    }

    public void Start() {
        PossibleAnswers = wordController.ActiveQuestion.answers;
 
        index = 0;
        wordController.ShowQuestion();
    }

    private void Update()
	{
        wordController.IsAcceptingKeys = (index == PossibleAnswers.Length);
        if (Time.time >= nextWordTime && index < PossibleAnswers.Length) { // && wordManager.words.Count < maxWords
            wordController.AddWord(PossibleAnswers[index++]);
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }

    public static T[] KnuthShuffle<T>(T[] _array) {
        T[] array = _array.Clone() as T[];
        System.Random random = new System.Random();
        for (int i = 0; i < array.Length; i++) {
            int j = random.Next(i, array.Length); // Don't select from the entire array on subsequent loops
            T temp = array[i]; array[i] = array[j]; array[j] = temp;
        }
        return array;
    }

}
