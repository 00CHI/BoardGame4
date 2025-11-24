using DG.Tweening;
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
//    switch (eSTUDENT)
//{
//    case eSTUDENT.eSTUDENT_Ari_Choi:
//        Singleton.AI.aiStudents.Add((eSTUDENT));

//        break;
//    case eSTUDENT.eSTUDENT_bada_Seo:
//        break;
//    case eSTUDENT.eSTUDENT_Bora_Nam:
//        break;
//    case eSTUDENT.eSTUDENT_doha_Bae:
//        break;
//    case eSTUDENT.eSTUDENT_Donghoon_Moon:
//        break;
//    case eSTUDENT.eSTUDENT_galam_Heo:
//        break;
//    case eSTUDENT.eSTUDENT_hali_Gu:
//        break;
//    case eSTUDENT.eSTUDENT_hanbyeol_Bu:
//        break;
//    case eSTUDENT.eSTUDENT_Jiho_Lee:
//        break;
//    case eSTUDENT.eSTUDENT_mingug_Jo:
//        break;
//    case eSTUDENT.eSTUDENT_Minjae_Kim:
//        break;
//    case eSTUDENT.eSTUDENT_Mirae_Yoon:
//        break;
//    case eSTUDENT.eSTUDENT_schoolmaste:
//        break;
//}