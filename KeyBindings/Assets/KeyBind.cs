//created from youtube inScope Studios video series 
//https://www.youtube.com/playlist?list=PLX-uZVK_0K_5X84_toCOlmXrYT5RGJEMO 
//
//TODO add restore defults
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour
{

    Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, down, left, right, jump;

    string key_up = "Up";
    string key_down = "Down";
    string key_left = "Left";
    string key_right = "Right";
    string key_jump = "Jump";

    string key_up_defult = "W";
    string key_down_defult = "S";
    string key_left_defult = "A";
    string key_right_defult = "D";
    string key_jump_defult = "Space";


    GameObject currentKey;

    Color32 normal = new Color32(255, 0, 0, 255);
    Color32 selected = new Color32(83, 255, 0, 255);



    // Use this for initialization
    void Start()
    {

        updatefields();

    }

    // Update is called once per frame 
    void Update()
    {

        if (Input.GetKeyDown(keys[key_up]))
        {
            Debug.Log("UP");
        }
        if (Input.GetKeyDown(keys[key_down]))
        {
            Debug.Log("Down");
        }
        if (Input.GetKeyDown(keys[key_left]))
        {
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys[key_right]))
        {
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(keys[key_jump]))
        {
            Debug.Log("Jump");
        }

    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }

        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;


    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());

        }
        PlayerPrefs.Save();
    }

    void updatefields()
    {
        keys.Add(key_up, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key_up, key_up_defult)));
        keys.Add(key_down, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key_down, key_down_defult)));
        keys.Add(key_left, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key_left, key_left_defult)));
        keys.Add(key_right, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key_right, key_right_defult)));
        keys.Add(key_jump, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key_jump, key_jump_defult)));


        up.text = keys[key_up].ToString();
        down.text = keys[key_down].ToString();
        left.text = keys[key_left].ToString();
        right.text = keys[key_right].ToString();
        jump.text = keys[key_jump].ToString();
    }

}
