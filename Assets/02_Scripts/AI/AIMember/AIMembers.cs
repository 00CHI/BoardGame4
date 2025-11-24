using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using DG.Tweening;


public class AIMembers : MonoBehaviour
{


    public eAIMEMBER eAIMEMBER = eAIMEMBER.eAIMEMBER_NONE;
    public eCHARACTER eCHARACTER;

    public eSTUDENT eSTUDENT;
    public eTIME eTIME;
    public eCRIME eCRIME;

    public string answer;
    public Text answerText;


    // Start is called before the first frame update
    void Awake()
    {
        //reset
        eCHARACTER = eCHARACTER.eCHARACTER_AI;
        eAIMEMBER = eAIMEMBER.eAIMEMBER_NONE;
        eSTUDENT = eSTUDENT.eSTUDENT_NONE;
        eTIME = eTIME.eTIME_NONE;
        eCRIME = eCRIME.eCRIME_NONE;

        if (Singleton.AI == null)
        {
            Singleton.AI = GetComponentInParent<AI>();
        }




        AIMemberSetting();
    }

    void Update()
    {
        if(Singleton.Player.eSTUDENT != eSTUDENT.eSTUDENT_NONE && Singleton.Player.eTIME != eTIME.eTIME_NONE && Singleton.Player.eCRIME != eCRIME.eCRIME_NONE)
        {
            SelectedAI();
        }
    }
    void AIMemberSetting()
    {
        //Singleton.AI.
        for (int i = 0; i <= Singleton.RoomManager.roomMemberCount - 2; i++)
        {

            if (eAIMEMBER == eAIMEMBER.eAIMEMBER_NONE)
            {
                var member = Singleton.AI.aiMembersList[i].GetComponent<AIMembers>();
                member.eAIMEMBER = (eAIMEMBER)i + 1;
            }
        }

    }
    public void SelectedAI()
    {
        foreach (eSTUDENT eSTUDENT in System.Enum.GetValues(typeof(eSTUDENT)))
        {
            if (eSTUDENT == Singleton.Player.eSTUDENT)
            {
                Singleton.AI.aiStudents.Add(eSTUDENT);

                break;
            }
        }
        foreach (eTIME eTIME in System.Enum.GetValues(typeof(eTIME)))
        {
            if (eTIME == Singleton.Player.eTIME)
            {
                Singleton.AI.aiTimes.Add(eTIME);

                break;
            }
        }
        foreach (eCRIME eCRIME in System.Enum.GetValues(typeof(eCRIME)))
        {
            if (eCRIME == Singleton.Player.eCRIME)
            {
                Singleton.AI.aiCrimes.Add(eCRIME);

                break;
            }
        }

        int _membernum = 0;
        int _totalmember = Singleton.RoomManager.roomMemberCount + 1;

        while (eAIMEMBER != (eAIMEMBER) _totalmember -1)
        {
            switch (eAIMEMBER)
            {
                case eAIMEMBER.eAIMEMBER_ONE:
                    AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_TWO:
                    AllAISelect();
                    break;
                case eAIMEMBER.eAIMEMBER_THREE:
                    AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_FOUR:
                    AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_FIVE:
                    AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_SIX:
                    AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_SEVEN:
                    AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_EIGHT:
                    AllAISelect();

                    break;
            }

            _membernum++;

            if (_membernum == _totalmember)
            {
                break;
            }

        }
    }

    void AllAISelect()
    {
        AIStudentSelect();
        AITimeSelect();
        AICrimeSelect();
    }
    public void AIStudentSelect()
    {
        int _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eSTUDENT)).Length);

        while(eSTUDENT == eSTUDENT.eSTUDENT_NONE)
        {
            if (Singleton.AI.aiStudents.Contains((eSTUDENT)_randomnum))
            {
                _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eSTUDENT)).Length);
            }
            else
            {
                Singleton.AI.aiStudents.Add((eSTUDENT)_randomnum);
                eSTUDENT = (eSTUDENT)_randomnum;
                break;
            }

            if(eSTUDENT != eSTUDENT.eSTUDENT_NONE)
            {
                break;

            }
        }

    }

    public void AITimeSelect()
    {
        int _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eTIME)).Length);

        while (eTIME == eTIME.eTIME_NONE)
        {
            if (Singleton.AI.aiTimes.Contains((eTIME)_randomnum))
            {
                _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eTIME)).Length);
                //continue;
            }
            else
            {
                Singleton.AI.aiTimes.Add((eTIME)_randomnum);
                eTIME = (eTIME)_randomnum;
                //i++;
                break;
            }

            if (eTIME != eTIME.eTIME_NONE)
            {
                break;

            }
        }
    }

    public void AICrimeSelect()
    {
        int _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eCRIME)).Length);

        while (eCRIME == eCRIME.eCRIME_NONE)
        {
            if (Singleton.AI.aiCrimes.Contains((eCRIME)_randomnum))
            {
                _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eCRIME)).Length);
                //continue;
            }
            else
            {
                Singleton.AI.aiCrimes.Add((eCRIME)_randomnum);
                eCRIME = (eCRIME)_randomnum;
                //i++;
                break;
            }

            if (eCRIME != eCRIME.eCRIME_NONE)
            {
                break;

            }
        }
    }

    public void AIAnswer(int index)
    {
        switch (eSTUDENT)
        {
            case eSTUDENT.eSTUDENT_Ari_Choi://1 :최아리

                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if(index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }

                break;
            case eSTUDENT.eSTUDENT_bada_Seo://2 : 서바다

                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_Bora_Nam://3 : 남보라

                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_doha_Bae://4 : 배도하

                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_Donghoon_Moon://5 : 문동훈
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_galam_Heo://6 : 허가람
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_hali_Gu://7 : 구하리
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_hanbyeol_Bu://8 : 부한별
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_Jiho_Lee://9 : 이지호
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_mingug_Jo://10 : 조민국
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_Minjae_Kim://11: 김민재
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eSTUDENT.eSTUDENT_Mirae_Yoon://12: 윤미래
                if (index == 0 || index == 1)//"이름에 ㄱ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 2 || index == 3)//"이름에 ㅇ이 들어갑니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 4 || index == 5)//"이름에 ㅂ이 들어갑니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 6 || index == 7)//"당신은 여성입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 8 || index == 9)//"당신은 남성입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 10 || index == 11)//"당신은 장발입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 12 || index == 13)//"당신은 단발입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 14 || index == 15)//"당신은 숏컷입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 16 || index == 17)//"당신은 1학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 18 || index == 19)//"당신은 2학년입니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 20 || index == 21)//"당신은 3학년입니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
        }

        switch (eTIME)
        {
            case eTIME.eTIME_After01://1 /15:30
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if(index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_Break01://2 /13:50
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_CleaningTime01://3 /16:30
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_DropOff01://4 /17:00
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_GoToSchool01://5 /8:30
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_Lunch01://6 /12:00
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_After02://1 /15:30
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_Break02://2 /13:50
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_CleaningTime02://3 /16:30
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_DropOff02://4 /17:00
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_GoToSchool02://5 /8:30
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eTIME.eTIME_Lunch02://6 /12:00
                if (index == 22 || index == 23 || index == 24)//"당신은 15시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 25 || index == 26 || index == 27)//"당신은 15시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 28 || index == 29 || index == 30)//"당신은 13시 이전에 범행을 저질렀습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 31 || index == 32 || index == 33)//"당신은 16시 이후에 범행을 저질렀습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
        }

        switch (eCRIME)
        {
            case eCRIME.eCRIME_Absence://1 땡땡이 : 네모
                break;
            case eCRIME.eCRIME_Alcohol://2 술마심 : 동그라미
                break;
            case eCRIME.eCRIME_Cigarette://3 담배핌 : 동그라미
                break;
            case eCRIME.eCRIME_Cleaning://4 청소안함 : 세모
                break;
            case eCRIME.eCRIME_Doodle://5 교장쌤낙서 : 별
                break;
            case eCRIME.eCRIME_Dues://6 학생회비 : 동그라미
                break;
            case eCRIME.eCRIME_Homework://7 숙제안함 : 네모
                break;
            case eCRIME.eCRIME_InformalLanguage://8 반말 : 별
                break;
            case eCRIME.eCRIME_Restroom://9 화장실물안내림 : 세모
                break;
            case eCRIME.eCRIME_Teacher://10 선생님고백 : 별
                break;
            case eCRIME.eCRIME_Test://11 시험안침 :네모
                break;
            case eCRIME.eCRIME_Washing://12 안씻음 : 세모
                break;
        }
    }
}

//int _membernum = 0;
//int _totalmember = Singleton.RoomManager.roomMemberCount;

//while (eAIMEMBER != (eAIMEMBER)_totalmember)
//{
//    switch (eAIMEMBER)
//    {
//        case eAIMEMBER.eAIMEMBER_ONE:

//            AIStudentSelect();

//            break;
//        case eAIMEMBER.eAIMEMBER_TWO:
//            AIStudentSelect();

//            break;
//        case eAIMEMBER.eAIMEMBER_THREE:

//            AIStudentSelect();

//            break;
//        case eAIMEMBER.eAIMEMBER_FOUR:
//            AIStudentSelect();

//            break;
//        case eAIMEMBER.eAIMEMBER_FIVE:
//            AIStudentSelect();

//            break;
//        case eAIMEMBER.eAIMEMBER_SIX:
//            AIStudentSelect();

//            break;
//        case eAIMEMBER.eAIMEMBER_SEVEN:
//            AIStudentSelect();


//            break;
//        case eAIMEMBER.eAIMEMBER_EIGHT:
//            AIStudentSelect();

//            break;
//    }

//    _membernum++;

//    if (_membernum == Singleton.RoomManager.roomMemberCount)
//    {
//        break;
//    }
//}




//for (int i = 0; i < System.Enum.GetValues(typeof(eAIMEMBER)).Length;)
//{
//    int _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eSTUDENT)).Length);

//    if (aiStudents.Contains((eSTUDENT)_randomnum))
//    {
//        _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eSTUDENT)).Length);
//        continue;
//    }
//    else
//    {
//        aiStudents.Add((eSTUDENT)_randomnum);
//        eSTUDENT = (eSTUDENT)_randomnum;
//        //i++;
//        break;
//    } 
//}