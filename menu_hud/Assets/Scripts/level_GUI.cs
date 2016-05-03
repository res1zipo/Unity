using UnityEngine;
using System.Collections;

public class level_GUI : MonoBehaviour {
    [SerializeField] Transform Main_Panel;
    //[SerializeField] Transform Quit_Confirmation;

    // Use this for initialization
    void Start () {
        Main_Panel.gameObject.SetActive(true);
        //Quit_Confirmation.gameObject.SetActive(false);
    }


}
