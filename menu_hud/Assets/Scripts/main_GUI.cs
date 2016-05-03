using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class main_GUI : MonoBehaviour {
    #if UNITY_WEBPLAYER
    public static string webplayerQuitURL = "http://google.com";
    #endif

    public Transform Main_Panel;
    //public Transform Options_Panel;
    public Transform Quit_Confirmation;

    public helper_gui helper_GUI;


    void OnEnable(){
        helper_GUI = gameObject.AddComponent<helper_gui>();
    }

	void Start () {
        Main_Panel.gameObject.SetActive(true);
        Quit_Confirmation.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(helper_gui.GetInstance().isOptionsActive());

        if (Input.GetKeyDown(KeyCode.Escape)){
            //Debug.Log("escape");
            if (Quit_Confirmation.gameObject.activeSelf == true){
                confirm_no();
            } else if (helper_GUI.isOptionsActive()){
                helper_GUI.OptionsCancel();
            } else if (Main_Panel.gameObject.activeSelf == true){
                quitconfirmation();  
            }
        }
	}

    void setmainPanel(bool set){
        if (set)
            Main_Panel.gameObject.SetActive(true);
        else if (set == false)
            Main_Panel.gameObject.SetActive(false);
    }

    public void mainPanel(){
       // helper_gui.GetInstance(). .setOptions();
        setmainPanel(true);
    }

    public void OptionsMenu(){
        
        helper_GUI.isOptionsActive();
        setmainPanel(false);
    }

    public void quitPanel(){
        Main_Panel.gameObject.SetActive(false);
        Quit_Confirmation.gameObject.SetActive(true);

    }


    /// <summary>
    /// Quit Button actions
    /// </summary>
    public void quitconfirmation(){
        quitPanel();
        }

    public void confirm_yes(){
        QuitGame();
    }

    public void confirm_no(){
        mainPanel();
    }

    void QuitGame(){
        //script came from Bunny83's reply at 
        //http://answers.unity3d.com/questions/161858/startstop-playmode-from-editor-script.html
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
        #else
        Application.Quit();
        #endif
    }   
}
       