using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour 
{

	float fillAmount;

    [SerializeField] float lerpspeed;
    [SerializeField] Image content;
    [SerializeField] Text valueText;
    [SerializeField] Color fullColor;
    [SerializeField] Color lowColor;
    [SerializeField] bool lerpColors;



	public float MaxValue {get;	set;}


	public float Value 
    {
		set 
		{
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}

    void Start()
    {
        if(lerpColors)
        content.color = fullColor;
    }

	void Update () { HandleBar (); }

	void HandleBar()
	{
		if (fillAmount != content.fillAmount)
		    content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpspeed);

        if(lerpColors)
        content.color = Color.Lerp(lowColor, fullColor, fillAmount);
	}

	float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {   return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin; }
}
