using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

	public GameObject wordPrefab;
	public Transform wordCanvas;

    private float X = 0;
    private float lastX = 0;

	public WordDisplay SpawnWord ()
	{
        for (int i = 0; i < 10; i++) {
            X = Random.Range(-3, 3);
            if (X != lastX) {
                break;
            }
        }
        Vector3 randomPosition = new Vector3(X * 1.5f, 8f);
        lastX = X;

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponentInChildren<WordDisplay>();

		return wordDisplay;
	}

}
