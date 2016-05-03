using UnityEngine;
using System.Collections;

public interface IMIS_Quality{
    // poor common uncommon rare  legendary
    string MISQName { get; set; }
    Sprite MISQIcon { get; set; }
}
