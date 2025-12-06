using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reasoning : MonoBehaviour
{
    public AIMembers aiMembers;
    public eSTUDENT eSTUDENT;
    public eTIME eTIME;
    public eCRIME eCRIME;

    // Start is called before the first frame update
    void Awake()
    {
        Singleton.Reasoning = this;

        eSTUDENT = eSTUDENT.eSTUDENT_NONE;
        eTIME = eTIME.eTIME_NONE;
        eCRIME = eCRIME.eCRIME_NONE;

    }
    private void Update()
    {

    }

    public void OnReasoning(AIMembers _AIMEM)
    {
        eSTUDENT = _AIMEM.eSTUDENT;
        eTIME = _AIMEM.eTIME;
        eCRIME = _AIMEM.eCRIME;

        aiMembers = _AIMEM;
    }

    public void OnReasonTrue()
    {
        aiMembers.isReason = true;
        aiMembers.isReasonComplete = true;

    }
    public void OnReasonFalse()
    {
        aiMembers.isReason = false;
        aiMembers.isReasonComplete = true;
    }



}
