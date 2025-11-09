using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public eCHARACTER eCHARACTER = eCHARACTER.eCHARACTER_NONE;
    public eSTUDENT eSTUDENT = eSTUDENT.eSTUDENT_NONE;
    public eTIME eTIME = eTIME.eTIME_NONE;
    public eCRIME eCRIME = eCRIME.eCRIME_NONE;


    // Start is called before the first frame update
    void Awake()
    {
        Singleton.Player = this;

        eCHARACTER = eCHARACTER.eCHARACTER_PLAYER;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
