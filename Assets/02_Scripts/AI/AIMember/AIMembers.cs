using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIMembers : AI
{


    public eAIMEMBER eAIMEMBER;
    public eCHARACTER eCHARACTER;

    public eSTUDENT eSTUDENT;
    public eTIME eTIME;
    public eCRIME eCRIME;

    public string answer;
    public Text answerText;


    // Start is called before the first frame update
    void Awake()
    {
        Singleton.AIMembers = this;

        eCHARACTER = eCHARACTER.eCHARACTER_AI;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AIMemberSelect()
    {
        
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
            case eTIME.eTIME_After://1 /15:30
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
            case eTIME.eTIME_Break://2 /13:50
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
            case eTIME.eTIME_CleaningTime://3 /16:30
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
            case eTIME.eTIME_DropOff://4 /17:00
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
            case eTIME.eTIME_GoToSchool://5 /8:30
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
            case eTIME.eTIME_Lunch://6 /12:00
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

//switch (eAIMEMBER)
//{
//    case eAIMEMBER.eAIMEMBER_ONE:
//        break;
//    case eAIMEMBER.eAIMEMBER_TWO:
//        break;
//    case eAIMEMBER.eAIMEMBER_THREE:
//        break;
//    case eAIMEMBER.eAIMEMBER_FOUR:
//        break;
//    case eAIMEMBER.eAIMEMBER_FIVE:
//        break;
//    case eAIMEMBER.eAIMEMBER_SIX:
//        break;
//    case eAIMEMBER.eAIMEMBER_SEVEN:
//        break;
//    case eAIMEMBER.eAIMEMBER_EIGHT:
//        break;
//}

//for (int i = 0;)
//    if (aiObjects[0].gameObject == gameObject)
//    {

//        eAIMEMBER = eAIMEMBER.eAIMEMBER_ONE;
//    }
//    else if (aiObjects[1].gameObject == gameObject)
//    {
//        eAIMEMBER = eAIMEMBER.eAIMEMBER_TWO;

//    }
//    else if (aiObjects[2].gameObject == gameObject)
//    {
//        eAIMEMBER = eAIMEMBER.eAIMEMBER_THREE;

//    }
//    else if (aiObjects[3].gameObject == gameObject)
//    {
//        eAIMEMBER = eAIMEMBER.eAIMEMBER_FOUR;

//    }
//    else if (aiObjects[4] == this.gameObject)
//    {
//        eAIMEMBER = eAIMEMBER.eAIMEMBER_FIVE;

//    }
//    else if (aiObjects[5] == this.gameObject)
//    {
//        eAIMEMBER = eAIMEMBER.eAIMEMBER_SIX;

//    }
//    else if (aiObjects[6] == this.gameObject)
//    {
//        eAIMEMBER = eAIMEMBER.eAIMEMBER_SEVEN;

//    }
//    else if (aiObjects[7] == this.gameObject)
//    {
//        eAIMEMBER = eAIMEMBER.eAIMEMBER_EIGHT;
//    }