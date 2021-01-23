using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController> {

    [SerializeField]
    private AudioSource audioSourceFX;

    Dictionary<string, AudioClip> audioClipList = new Dictionary<string, AudioClip>();

    public AudioSource AudioSourceFX {
        get { return audioSourceFX; }
    }

    void Awake() {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Audio") as AudioClip[];
        foreach (AudioClip audioClip in audioClips) {
            audioClipList.Add(audioClip.name, audioClip);
        }
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayAudioClipFX(string name, float volumeScale = 1.0F, int priority = 1) {
        audioSourceFX.priority = priority;
        audioSourceFX.PlayOneShot(audioClipList[name], volumeScale);
    }
}
