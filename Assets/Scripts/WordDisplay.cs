using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour {

    public TextMeshProUGUI text;
	public float fallSpeed = 1f;
    public float rotateSpeed = 1f;

    private bool doDrop = false;

    public string wordText;

    public void SetWord (string word)
	{
        wordText = word;
        text.text = wordText;
    }

	public void RemoveLetter ()
	{
		text.text = text.text.Remove(0, 1);
		text.color = Color.yellow;
	}

	public void RemoveWord ()
	{
        doDrop = true;
        Destroy(text);
    }

    public void Remove() {
        Destroy(transform.parent.gameObject);
    }

    private void Update()
	{
        if (doDrop) {
            transform.parent.Translate(0f, -fallSpeed * 10 * Time.deltaTime, 0f);
            transform.parent.GetComponentInChildren<Image>().transform.Rotate(0, 0, rotateSpeed * 3 * Random.Range(1f, 3f)); // Time.deltaTime
        }
        else {
            transform.parent.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
            transform.parent.GetComponentInChildren<Image>().transform.Rotate(0, 0, rotateSpeed * Random.Range(1f, 3f)); // Time.deltaTime
        }
    }
}
