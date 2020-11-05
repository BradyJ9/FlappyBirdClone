using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public static MainMenuController instance;

	[SerializeField]
	private GameObject[] birds;

	private bool isGreenBirdUnlocked;
	private bool isRedBirdUnlocked;

	// Use this for initialization
	void Awake () {
		MakeInstance ();
	}

	void Start() {
		CheckIfBirdsAreUnlocked ();
		birds [GameController.instance.GetSelectedBird ()].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayGame() {
		SceneFader.instance.FadeIn ("GamePlay");
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void CheckIfBirdsAreUnlocked() {
		if (GameController.instance.IsRedBirdUnlocked () == 1) {
			isRedBirdUnlocked = true;
		} else {
			isRedBirdUnlocked = false;
		}

		if (GameController.instance.IsGreenBirdUnlocked () == 1) {
			isGreenBirdUnlocked = true;
		} else {
			isGreenBirdUnlocked = false;
		}
	}

	public void ChangeBird() {

		if (GameController.instance.GetSelectedBird () == 0) {

			if (isGreenBirdUnlocked) {
				birds [0].SetActive (false);
				GameController.instance.SetSelectedBird (1);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			}

		} else if (GameController.instance.GetSelectedBird () == 1) {

			if (isRedBirdUnlocked) {
				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (2);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true); 
			} else {
				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (0);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true); 
			}
				
		} else if (GameController.instance.GetSelectedBird () == 2) {
			birds [2].SetActive (false);
			GameController.instance.SetSelectedBird (0);
			birds [GameController.instance.GetSelectedBird ()].SetActive (true);
		}


	}
}
