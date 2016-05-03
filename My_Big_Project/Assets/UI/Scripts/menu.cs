using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Use this for initialization
    public void Play () {
        SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
    public void Quit () {
        #if UNITY_EDITOR
        {
        UnityEditor.EditorApplication.isPlaying = false;
        }
        #else 
        {
        Application.Quit();
        }
        #endif
	}
}
