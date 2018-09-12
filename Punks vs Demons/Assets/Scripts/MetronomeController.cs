﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MetronomeController : MonoBehaviour {
	
	[SerializeField]private SongManager songManager;
	[SerializeField]private AudioSource[] metronomeClicks;
	private int audioIndex;

	private float bpm;
	private float spb;
	private double nextClick;

	void Start(){
		audioIndex = 0;
		bpm = songManager.bpm;
		spb = 60.0f / bpm;
		nextClick = AudioSettings.dspTime + spb * songManager.beatsShownEarly + spb;
		Debug.Log (nextClick.ToString ());
	}

	// Update is called once per frame
	void Update () {
		double time = AudioSettings.dspTime;
		if (time + spb > nextClick) {
			//Debug.Log ("click");
			metronomeClicks[audioIndex].PlayScheduled (nextClick);
			audioIndex++;
			if (audioIndex >= metronomeClicks.Length) {
				audioIndex = 0;
			}
			nextClick += spb;
		}
	}		
}