using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public eCHARACTER eCHARACTER = eCHARACTER.eCHARACTER_NONE;
    public ePLAYERSTATE ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_NONE;
    public eSTUDENT eSTUDENT = eSTUDENT.eSTUDENT_NONE;
    public eTIME eTIME = eTIME.eTIME_NONE;
    public eCRIME eCRIME = eCRIME.eCRIME_NONE;

    public int turnNumber = 0;

    public bool myTurn = false;
    public bool myAnswer= false;
    public bool isButtonClicked = false;

    public string answer;
    public GameObject answerPanel;
    public GameObject blackBG;
    public GameObject reasoningButton;
    public Button[] aiButtons;
    public Text answerText;




    // Start is called before the first frame update
    void Awake()
    {
        Singleton.Player = this;

        eCHARACTER = eCHARACTER.eCHARACTER_PLAYER;

        blackBG.SetActive(false);
        reasoningButton.SetActive(false);


        aiButtons[0].interactable = false;
        aiButtons[1].interactable = false;
        aiButtons[2].interactable = false;
        aiButtons[3].interactable = false;
        aiButtons[4].interactable = false;
        aiButtons[5].interactable = false;
        aiButtons[6].interactable = false;
        aiButtons[7].interactable = false;
    }

    // Update is called once per frame
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
        switch (ePLAYERSTATE)
        {
            case ePLAYERSTATE.ePLAYERSTATE_NONE:
                ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_WAIT;

                break;
            case ePLAYERSTATE.ePLAYERSTATE_WAIT:

                PlayerWait();

                break;
            case ePLAYERSTATE.ePLAYERSTATE_QUESTION:
                PlayerQuestion();

                break;
            case ePLAYERSTATE.ePLAYERSTATE_ANSWER:

                PlayerAnswer();
                break;
            case ePLAYERSTATE.ePLAYERSTATE_REASONING:
                break;
        }
    }
    void PlayerWait()
    {
        answerPanel.SetActive(false);
        blackBG.SetActive(false);
        reasoningButton.SetActive(false);
        Singleton.RandomQuestion.questionButton.interactable = false;
        isButtonClicked = false;
    }
    void PlayerAnswer()
    {
        if (myAnswer)
        {
            answerPanel.SetActive(true);
            PlayerAnswer(Singleton.RandomQuestion.index);

            Debug.Log($"플레이어 답변 : {answer}");
            myAnswer = false;

        }



        DOVirtual.DelayedCall(2f, () =>
        {
            myAnswer = false;
            ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_WAIT;
        });



    }
    void PlayerQuestion()
    {
        myTurn = true;

        if (!isButtonClicked)
        {
            Singleton.RandomQuestion.questionButton.interactable = true;
            isButtonClicked = true;

        }

        for (int i = 0; i < aiButtons.Length; i++)
        {
            ProfileButton _profileButton = aiButtons[i].GetComponent<ProfileButton>();
            AIMembers _aiMembers = _profileButton.aiMembers;

            if (_aiMembers.eSTUDENT == eSTUDENT.eSTUDENT_schoolmaster)
            {
                aiButtons[i].interactable = false;
            }
            else
            {
                aiButtons[i].interactable = true;
            }

        }

        blackBG.SetActive(true);
        reasoningButton.SetActive(true);



       


    }
    void PlayerReasoning()
    {

    }

    public void PlayerAnswer(int index)
    {
        switch (eSTUDENT)
        {
            case eSTUDENT.eSTUDENT_Ari_Choi://1 :최아리

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


        DOVirtual.DelayedCall(1.5f, () => PlayerWait());//0.5초 대기 후 답변 완료 콜백
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