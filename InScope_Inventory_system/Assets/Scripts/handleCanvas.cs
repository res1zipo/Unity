using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class handleCanvas : MonoBehaviour {

    CanvasScaler scaler;
    [SerializeField] bool scaleScreenSizeoff;

	// Use this for initialization
	void Start () {
        
        if (!scaleScreenSizeoff)
        {
            scaler = GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        }

	}
}
