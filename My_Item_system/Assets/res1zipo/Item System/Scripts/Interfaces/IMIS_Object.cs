using UnityEngine;
using System.Collections;

public interface IMIS_Object {

    //name
    //discription
    //icon
    //value
    //burden
    //qualitylevel
    //questItem Flag

    string MISName { get; set; }
    string MISDiecription { get; set; }
    Sprite MISIcon { get; set; }
    int MISValue { get; set; }
    int MISburden { get; set; }
    MIS_Quality MISQuality { get; set; }
    bool MISQuestitem { get; set; }



}
