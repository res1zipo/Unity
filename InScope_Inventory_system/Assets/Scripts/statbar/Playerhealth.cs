using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour 
{

    [SerializeField] Stat health;
//    [SerializeField] Stat energy;
//    [SerializeField] Stat shield;


	// Use this for initialization
	void Awake () 
    {
        health.Initialize();
//        energy.Initialize();
//        shield.Initialize();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))    //health going down
            health.CurrentVal -= 10;
        if (Input.GetKeyDown(KeyCode.RightBracket))    //health going up
            health.CurrentVal += 10;
//        if (Input.GetKeyDown(KeyCode.A))    //defence going down
//            energy.CurrentVal -= 10;
//        if (Input.GetKeyDown(KeyCode.D))    //defense going down
//            energy.CurrentVal += 10;
//        if (Input.GetKeyDown(KeyCode.Z))    //mana going down
//            shield.CurrentVal -= 10;
//        if (Input.GetKeyDown(KeyCode.C))    //mana going down
//            shield.CurrentVal += 10;
	}
}
