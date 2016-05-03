using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Invintory : MonoBehaviour {

    RectTransform invenRect;
    float invenWidth, invenHight;
    private List<GameObject> allSlots;

    public int slots;
    public int rows;
    public float slotPaddingLeft, slotPaddingTop;
    public float slotSize;
    public GameObject slotPrefab;

	// Use this for initialization
	void Start () {
        CreateLayout();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateLayout()
    {
        // slots ============ 10
        // row   ============ 2
        // slotSize ========= 25
        // slotPadding top/lift == 2
        // invenWidth = (slots/rows)*(slotSize+slotPaddingLeft)+slotPaddingLeft
        // invenWidth = (10/2)*(25+2)+2 = 137
        //
        // invenHight = rows*(slotSize+ slotPaddingTop)+slotPaddingTop
        // invenHight = 2*(25+2)+2 = 56
        allSlots = new List<GameObject>();

        invenWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
        invenHight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        invenRect = GetComponent<RectTransform>();
        invenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, invenWidth);
        invenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invenHight);

        int columns = slots / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);

                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";

                newSlot.transform.SetParent(this.transform.parent);

                slotRect.localPosition = invenRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                allSlots.Add(newSlot);

            }
        }

    }

}
