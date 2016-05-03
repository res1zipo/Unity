using UnityEngine;
using System.Collections;
using System.

public class Player : MonoBehaviour 
{

    [SerializeField] Stat health;
    [SerializeField] Stat energy;
    [SerializeField] Stat shield;


	// Use this for initialization
	void Awake () 
    {
        health.Initialize();
        energy.Initialize();
        shield.Initialize();
	}
 
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Q))    //health going down
            health.CurrentVal -= 10;
        if (Input.GetKeyDown(KeyCode.E))    //health going up
            health.CurrentVal += 10;
        if (Input.GetKeyDown(KeyCode.A))    //defence going down
            energy.CurrentVal -= 10;
        if (Input.GetKeyDown(KeyCode.D))    //defense going down
            energy.CurrentVal += 10;
        if (Input.GetKeyDown(KeyCode.Z))    //Energy going down
            shield.CurrentVal -= 10;
        if (Input.GetKeyDown(KeyCode.C))    //Energy going down
            shield.CurrentVal += 10;
	}
}
