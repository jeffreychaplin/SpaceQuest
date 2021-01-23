using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;

public class IncorrectAnswer : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        WordDisplay wordDisplay = other.transform.parent.gameObject.GetComponentInChildren<WordDisplay>();
        WordController.Instance.RemoveWord(wordDisplay.wordText);
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        GameController.Instance.Score -= 10;
        Destroy(other.transform.parent.gameObject);
        SoundController.Instance.PlayAudioClipFX("AsteroidCrash");
    }
}
