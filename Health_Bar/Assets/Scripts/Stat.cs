﻿using UnityEngine;
using System.Collections;
using System;


[Serializable]
public class Stat 
{
    [SerializeField] BarScript bar;
    [SerializeField] float maxVal;
    [SerializeField] float currentVal;



    public float CurrentVal
    {
        get{ return currentVal; }
        set
        {
            this.currentVal = Mathf.Clamp(value,0,MaxVal);
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get{ return maxVal; }
        set
        {
            this.maxVal = value;
            bar.MaxValue = value;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }

}
