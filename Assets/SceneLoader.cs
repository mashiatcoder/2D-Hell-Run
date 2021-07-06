using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {

	public GameObject GameOver;
	public GameObject player;
	public string ThisLevel;
	public Slider slider;
	public static bool getlives = false;
	public Color white;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart(){

		SceneManager.LoadScene(ThisLevel);
	}

	public void VideoAdDone(){

		GameOver.SetActive(false);
		player.SetActive(true);
		SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
		if(sr != null){

				sr.color = white;
		}
		getlives = true;
		if(slider != null){
			slider.value=slider.maxValue;
			

		}
	}



}
