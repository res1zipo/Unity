using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class slot : MonoBehaviour {


    Stack<Item> item;
    public Text stackTxt;
    public Sprite slotEmpty;
    public Sprite slotHighlighted;

	// Use this for initialization
	void Start () {
        item = new Stack<Item>();
        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform txtRect = GetComponent<RectTransform>();

        int txtscaleFacter = (int)(slotRect.sizeDelta.x * 0.60);

        stackTxt.resizeTextMaxSize = txtscaleFacter;
        stackTxt.resizeTextMinSize = txtscaleFacter;

        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.x);
        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.y);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
