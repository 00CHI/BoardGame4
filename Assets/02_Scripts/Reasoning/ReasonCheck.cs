using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class ReasonCheck : MonoBehaviour
{
    public ReasonCheck reasonCheck;
    Button myButton;

    public eBUTTONTYBE eBUTTONTYBE;
    public eSTUDENT eSTUDENT;
    public eTIME eTIME01;
    public eTIME eTIME02;
    public eCRIME eCRIME;



    // Start is called before the first frame update
    void Awake()
    {
        reasonCheck = GetComponent<ReasonCheck>();
        myButton = GetComponent<Button>();

    }

    public void OnClickReasoning(ref bool _ISSTUDENT, ref bool _ISTIME, ref bool _ISCRIME)
    {
        if (Singleton.Reasoning.eSTUDENT == reasonCheck.eSTUDENT)
        {
            _ISSTUDENT = true;
        }
        else if (Singleton.Reasoning.eTIME == reasonCheck.eTIME01 || Singleton.Reasoning.eTIME == reasonCheck.eTIME02)
        {
            _ISTIME = true;
        }
        else if (Singleton.Reasoning.eCRIME == reasonCheck.eCRIME)
        {
            _ISCRIME = true;
        }
    }
}
