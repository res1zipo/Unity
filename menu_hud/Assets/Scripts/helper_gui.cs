using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

    
public class helper_gui : MonoBehaviour {
    public Transform Options_Panel;
    static helper_gui instance;


    public static helper_gui GetInstance(){
        return instance;
    }

    void OnAwake(){
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void Start () {

      Options_Panel.gameObject.SetActive(false);
    }




    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public bool isOptionsActive(){
        if (Options_Panel.gameObject.activeSelf == true)
            return true;
        else{ return false; }
    }
    public void setOptions(){
        if (isOptionsActive())
            Options_Panel.gameObject.SetActive(false);
        else if (isOptionsActive() == false)
            Options_Panel.gameObject.SetActive(true);
    }

    public void Optionsmenu(){
        setOptions();
    }

    public void OptionsApply(){
        //TODO Save the settings here
        setOptions();
    }

    public void OptionsCancel(){
        //TODO revert to settings
        setOptions();
    }
}
