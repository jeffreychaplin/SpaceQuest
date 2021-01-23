using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

    private static List<Question> questionList;
    private static QuestionCollection questionCollection;
    private static string loadedItem;

    public static void LoadQuestions() {
        loadedItem = LoadJsonAsResource("Questions/questions");
        questionCollection = JsonUtility.FromJson<QuestionCollection>(loadedItem);
        questionList = questionCollection.questions;
    }

    public static string LoadJsonAsResource(string path) {
        string jsonFilePath = path.Replace(".json", "");
        TextAsset loadedJsonFile = Resources.Load<TextAsset>(jsonFilePath);
        return loadedJsonFile.text;
    }

    public static Question GetRandomQuestion() {
        Question randomQuestion = new Question();
        if (questionList.Count > 0) {
            int randomIndex = Random.Range(0, questionList.Count);
            randomQuestion = questionList[randomIndex];
            questionList.Remove(randomQuestion);
        }

        return randomQuestion;
    }
}


