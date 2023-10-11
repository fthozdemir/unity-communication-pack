using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TuioUnity.Utils;
using TuioUnity.Common;
using UnityEngine.UI;

public class WaterTag : Tag
{

    public override void Start()
    {
        base.Start();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void UpdateText()
    {
        base.UpdateText();
    }

    public override void UpdateValue(TuioBehaviour tuioBehaviour)
    {
        Debug.Log("WaterTag OnUpdated");
    }
}
