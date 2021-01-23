using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {

	public string word;
	private int typeIndex;

	WordDisplay display;

	public Word (string _word, WordDisplay _display)
	{
		word = _word;
		typeIndex = 0;

		display = _display;
		display.SetWord(word);
	}

	public char GetNextLetter ()
	{
        // remove next letter if it is a space.
        if (word[typeIndex] == ' ') {
            TypeLetter();
        }
		return word[typeIndex].ToString().ToLower()[0];
	}

	public void TypeLetter ()
	{
		typeIndex++;
		display.RemoveLetter();
	}

	public bool WordTyped ()
	{
		bool wordTyped = (typeIndex >= word.Length);
		if (wordTyped)
		{
			display.RemoveWord();
		}
		return wordTyped;
	}

    public void RemoveDisplay() {
        display.Remove();
    }

}
