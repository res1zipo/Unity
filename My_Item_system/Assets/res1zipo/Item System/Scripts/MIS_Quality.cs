using UnityEngine;
using System.Collections;

public class MIS_Quality : IMIS_Quality {
    [SerializeField] string _name;
    [SerializeField] Sprite _icon;


    MIS_Quality()
    {
        _name = "Common";
        _icon = new Sprite();
    }

    public string MISQName 
    { 
        get{ return _name; } 
        set{ _name = value ;}
    }
    public Sprite MISQIcon 
    { 
        get{ return _icon; } 
        set{ _icon = value; } 
    }
}
