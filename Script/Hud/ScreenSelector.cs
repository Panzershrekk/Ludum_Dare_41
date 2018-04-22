using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ScreenSelector : MonoBehaviour, IPointerClickHandler {

	public string sceneToLoad;

	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerClick(PointerEventData eventData)
	{
		SceneManager.LoadScene (sceneToLoad);
	}
}
