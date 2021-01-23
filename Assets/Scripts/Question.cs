using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// loaded from JSON file.

[System.Serializable]
public struct Question {

    public string question;
    public string[] answers;

}

[System.Serializable]
public class QuestionCollection {
    public List<Question> questions;
}