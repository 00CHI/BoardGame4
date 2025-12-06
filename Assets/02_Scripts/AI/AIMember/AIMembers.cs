using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class AIMembers : MonoBehaviour
{
    public eAIMEMBER eAIMEMBER = eAIMEMBER.eAIMEMBER_NONE;
    public eCHARACTER eCHARACTER;

    public eAISTATE eAISTATE = eAISTATE.eAISTATE_NONE;

    public eSTUDENT eSTUDENT;
    public eTIME eTIME;
    public eCRIME eCRIME;

    public string answer;
    public Text answerText;

    public int turnNumber = 0;
    int currentIndex = 0;
    int schoolMasterIndex = 0;
    //public int aiIndex;

    public bool myWait = false;
    public bool myTrun = false;
    public bool myAnswer = false;
    public bool isAISelected = false;
    public bool isReason = false;
    public bool isReasonComplete = false;

    Coroutine answerRoutine;

    public GameObject answerPanel;




    // Start is called before the first frame update
    void Awake()
    {
        //reset
        eAIMEMBER = eAIMEMBER.eAIMEMBER_NONE;
        eSTUDENT = eSTUDENT.eSTUDENT_NONE;
        eTIME = eTIME.eTIME_NONE;
        eCRIME = eCRIME.eCRIME_NONE;
        eAISTATE = eAISTATE.eAISTATE_NONE;


        if (Singleton.AI == null)
        {
            Singleton.AI = GetComponentInParent<AI>();
        }

        AIMemberSetting();
    }

    void Update()
    {


        if (!Singleton.CardUp.isUp)
        {
            UpdateLogic();
        }
        else
        {
            return;
        }



    }

   void LateUpdate()
    {

        if (!Singleton.CardUp.isUp && !Singleton.ButtonManager.isReasoning)
        {
            LateUpdateLogic();
        }
        else
        {
            return;
        }
    }

    public void UpdateLogic()
    {
        //UpdateSet
        if (Singleton.CardUp.isUp)
        {
            enabled = false;
        }
        else if (!Singleton.CardUp.isUp)
        {
            enabled = true;
        }

        //Game
        if (Singleton.SelectCard.isSelectedComplete && !isAISelected)
        {

            SelectedAI();

            Singleton.SelectCard.isSelectedComplete = false;
            isAISelected = true;
            Singleton.GameManager.isTrunStart = true;
        }
    }
    public void LateUpdateLogic()
    {
        //UpdateSet
        if (!Singleton.CardUp.isUp)
        {
            enabled = true;
        }
        else if (Singleton.CardUp.isUp)
        {
            enabled = false;
        }

        //Game
        switch (eAISTATE)
        {
            case eAISTATE.eAISTATE_NONE:

                eAISTATE = eAISTATE.eAISTATE_WAIT;
                break;
            case eAISTATE.eAISTATE_WAIT:
                AIStateWait();

                //if (myWait && !myTrun && !myAnswer)
                //{

                //}
                //if (!myWait && myTrun && !myAnswer)//Singleton.GameManager.isAITrun
                //{
                //    myWait = false;
                //    myAnswer = false;

                //    eAISTATE = eAISTATE.eAISTATE_QUESTION;
                //}
                //else if(!myWait && !myTrun && myAnswer)
                //{
                //    myWait = false;
                //    myAnswer = true;
                //    eAISTATE = eAISTATE.eAISTATE_ANSWER;
                //}


                break;
            case eAISTATE.eAISTATE_QUESTION:

                if (myTrun)
                {
                    AIStateQuestion();

                }

                eAISTATE = eAISTATE.eAISTATE_WAIT;
                myTrun = false;

                break;
            case eAISTATE.eAISTATE_ANSWER:

                if (myAnswer)
                {
                    AIStateAnswer();
                }


                eAISTATE = eAISTATE.eAISTATE_WAIT;

                myAnswer = false;

                DOVirtual.DelayedCall(2f, () =>
                {
                    answerPanel.SetActive(false);
                });


                break;
            case eAISTATE.eAISTATE_REASONING:
                break;
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
    public void AIStateWait()
    {
        eAISTATE = eAISTATE.eAISTATE_WAIT;

        //answerPanel.SetActive(false);

        //myWait = true;
        //myTrun = false;
        //myAnswer = false;
    }
    void AIStateQuestion()
    {
        Singleton.RandomQuestion.OnButtonClick();

        StartCoroutine(AnswerTagrting());
        //myWait = true;
        //myTrun = false;
        //myAnswer = false;

        //Singleton.GameManager.isTrunStart = false;
    }
    void AIStateAnswer()
    {
        //AIMembers _aimem = Singleton.GameManager.turnNumberIndex[aiIndex].GetComponent<AIMembers>();
        Debug.Log($"AI {eCHARACTER}질문 턴 시작");

        AIAnswer(Singleton.RandomQuestion.index);


        //answerPanel.SetActive(false);
    }
    void AIStateReasoning()
    {
    }

    IEnumerator AnswerTagrting()    
    {
        int _aiIndex = UnityEngine.Random.Range(0, Singleton.RoomManager.roomMemberCount);

        while (_aiIndex == turnNumber)
        {
            _aiIndex = UnityEngine.Random.Range(0, Singleton.RoomManager.roomMemberCount);
        }

        Player _player = Singleton.GameManager.turnNumberIndex[_aiIndex].GetComponent<Player>();
        AIMembers _aimem = Singleton.GameManager.turnNumberIndex[_aiIndex].GetComponent<AIMembers>();

        if (_aimem == null)
        {
            if(_player.eSTUDENT == eSTUDENT.eSTUDENT_schoolmaster)
            {
                RestartCoroutine();
                yield break;
            }
            _player.ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_ANSWER;

            _player.myAnswer = true;

            yield break;

        }
        else if (_player == null)
        {

            if (_aimem.eSTUDENT == eSTUDENT.eSTUDENT_schoolmaster)
            {
                RestartCoroutine();
                yield break;
            }
            _aimem.eAISTATE = eAISTATE.eAISTATE_ANSWER;
            _aimem.myAnswer = true;
            _aimem.answerPanel.SetActive(true);
            yield break;

        }

        yield return null;
    }
    void RestartCoroutine()
    {
        answerRoutine = StartCoroutine(AnswerTagrting());
    }

    public void SelectedAI()
    {

        if (Singleton.Player == null)
        {
            GameObject _player = GameObject.FindWithTag("Player");
            Singleton.Player = _player.GetComponent<Player>();
        }


        if (!Singleton.RoomManager.isSchoolMaster)
        {
            Singleton.AI.aiStudents.Add(eSTUDENT.eSTUDENT_schoolmaster);

        }


        foreach (eSTUDENT eSTUDENT in System.Enum.GetValues(typeof(eSTUDENT)))
        {
            if (eSTUDENT == Singleton.Player.eSTUDENT)
            {
                Singleton.AI.aiStudents.Add(eSTUDENT);

                break;
            }

            if (Singleton.AI.aiStudents.Count == Singleton.RoomManager.roomMemberCount)
            {
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

            if (Singleton.AI.aiTimes.Count == Singleton.RoomManager.roomMemberCount)
            {
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

            if (Singleton.AI.aiCrimes.Count == Singleton.RoomManager.roomMemberCount)
            {
                break;
            }
        }

        int _membernum = 0;

        while (!isAISelected && _membernum <= Singleton.RoomManager.roomMemberCount-1) //eAIMEMBER != (eAIMEMBER)_totalmember - 1!isAISelected && 
        {

            if (_membernum == Singleton.RoomManager.roomMemberCount-1)//Singleton.AI.aiStudents.Count > Singleton.RoomManager.roomMemberCount
            {

                Singleton.AI.isAISelectComplete = true;
                isAISelected = true;


                Debug.Log("AI Select Complete");

 


                break;
            }

            AIMembers _aIMembers = Singleton.AI.aiMembersList[_membernum].GetComponent<AIMembers>();


            //eAIMEMBER = (eAIMEMBER)_membernum;


            switch (_aIMembers.eAIMEMBER)
            {
                case eAIMEMBER.eAIMEMBER_ONE:
                    _aIMembers.AllAISelect();
                    break;
                case eAIMEMBER.eAIMEMBER_TWO:
                    _aIMembers.AllAISelect();
                    break;
                case eAIMEMBER.eAIMEMBER_THREE:
                    _aIMembers.AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_FOUR:
                    _aIMembers.AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_FIVE:
                    _aIMembers.AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_SIX:
                    _aIMembers.AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_SEVEN:
                    _aIMembers.AllAISelect();

                    break;
                case eAIMEMBER.eAIMEMBER_EIGHT:
                    _aIMembers.AllAISelect();


                    break;
            }


            _membernum++;

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
        schoolMasterIndex = UnityEngine.Random.Range(0, Singleton.RoomManager.roomMemberCount - 1);

        if (currentIndex == schoolMasterIndex)
        {
            _randomnum = 13; //eSTUDENT_schoolmaster
        }

        while (eSTUDENT == eSTUDENT.eSTUDENT_NONE)//Singleton.AI.aiStudents.Count > Singleton.RoomManager.roomMemberCount
        {

            if (Singleton.AI.aiStudents.Contains((eSTUDENT)_randomnum))
            {
                _randomnum = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(eSTUDENT)).Length);

            }
            else if(!Singleton.AI.aiStudents.Contains((eSTUDENT)13) && Singleton.AI.aiStudents.Count == Singleton.RoomManager.roomMemberCount - 1)
            {
                _randomnum = 13;
                Singleton.AI.aiStudents.Add((eSTUDENT)_randomnum);
                eSTUDENT = (eSTUDENT)_randomnum;
                break;
            }
            else
            {
                Singleton.AI.aiStudents.Add((eSTUDENT)_randomnum);
                eSTUDENT = (eSTUDENT)_randomnum;
                break;
            }     

            if (eSTUDENT != eSTUDENT.eSTUDENT_NONE)
            {
                break;

            }

            currentIndex++;

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
                if (index == 34|| index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }

                break;
            case eCRIME.eCRIME_Alcohol://2 술마심 : 동그라미
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Cigarette://3 담배핌 : 동그라미
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Cleaning://4 청소안함 : 세모
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Doodle://5 교장쌤낙서 : 별
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Dues://6 학생회비 : 동그라미
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Homework://7 숙제안함 : 네모
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_InformalLanguage://8 반말 : 별
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Restroom://9 화장실물안내림 : 세모
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Teacher://10 선생님고백 : 별
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Test://11 시험안침 :네모
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                break;
            case eCRIME.eCRIME_Washing://12 안씻음 : 세모
                if (index == 34 || index == 35 || index == 36)//"당신의 죄는 가볍습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 37 || index == 38 || index == 39)//"당신은 타인에게 피해 끼쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 40 || index == 41)//"당신은 물건을 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 42 || index == 43)//"당신은 학업에 관한 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 44 || index == 45)//"당신의 죄는 청결과 관련이 있습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 46 || index == 47)//"당신은 선생님과 관련된 죄를 지었습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 48)//"당신은 화장실에 교장 선생님 낙서를 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 49)//"당신은 교생 선생님께 고백했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 50)//"당신은 선생님께 반말했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 51)//"당신은 술을 훔쳐 마셨습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 52)//"당신은 담배를 훔쳐 폈습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 53)//"당신은 학생 회비를 훔쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 54)//"당신은 숙제를 안 했습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 55)//"당신은 시험을 안 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 56)//"당신은 땡땡이를 쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 57)//"당신은 청소를 안 하고 도망쳤습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
                else if (index == 58)//"당신은 씻지 않고 지속적으로 등교했습니까?"
                {
                    answer = "네";
                    answerText.text = answer;
                }
                else if (index == 59)//"당신은 화장실 물을 일부러 안 내렸습니까?"
                {
                    answer = "아니요";
                    answerText.text = answer;
                }
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