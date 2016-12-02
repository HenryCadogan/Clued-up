﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Room2Controller : MonoBehaviour {
	public GameObject backgroundPane;
	public GameObject overlayPanel;

	private void setOverlay(){
		//turns on overlay panel, fades it out
		overlayPanel.SetActive (true);
		overlayPanel.GetComponent<Image>().CrossFadeAlpha(0f,3f,false);
	}

	private void setClues(){
		//instanciates new clue prefab with location & rotation, scales for perspective calls its initialisation method
		GameObject bodyClue = Instantiate (Resources.Load ("Clue"), new Vector3(1.5f,-5.99f,-1.2f), Quaternion.Euler(90,0,0)) as GameObject;
		bodyClue.GetComponent<Transform> ().localScale = new Vector3 (1f, 4.5f, 1f);
		bodyClue.GetComponent<BoxCollider> ().size = new Vector3 (4.5f, 1.75f, 0f);	//manually set box collider as object is on floor & fixed position
		bodyClue.GetComponent<Clue>().initialise("chalkOutline", "Chalk Outline", "A chalk outline of the deceased.");
	}

	void Start () {
		setOverlay ();
		GameObject detective = GameObject.Find ("Detective");
		detective.GetComponent<PlayerController> ().walkIn();

		//Make vective slightly lower in screen
		Vector3 pos = detective.transform.position;
		pos.y = -6.5f;
		detective.transform.position = pos;

		//setClues ();
		//GameObject.Find("Detective").GetComponent<PlayerController> ().walkInFrom (true);
	}
}