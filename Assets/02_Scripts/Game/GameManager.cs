using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using static UnityEditor.Experimental.GraphView.GraphView;
#endif

public class GameManager : MonoBehaviour
{

    public eCHARACTER eCHARACTER;
    public eROUND eROUND;

    public List<GameObject> characters = new List<GameObject>();

    public List<GameObject> turnNumberIndex = new List<GameObject>();

    public Slider turnTimerSlider;


    public bool isTrunStart;
    public bool isTrun;
    public bool isAITrun;
    public bool isPlayerTrun;
    public bool isNext = false;
    public bool isStop = false;

    public int turnCount;
    public float currentTurnTime = 0f;
    public float maxTurnTime = 30f;
    //int roundNumber;

    // Start is called before the first frame update
    void Awake()
    {
        currentTurnTime = maxTurnTime;
        turnTimerSlider.maxValue = 1f;
        turnTimerSlider.value = 1f;

        Singleton.GameManager = this;

        isTrunStart = false;
        isTrun = true ;
        isAITrun = false;
        isPlayerTrun = false;

        eCHARACTER = eCHARACTER.eCHARACTER_NONE;
        eROUND = eROUND.eROUND_NONE;

        int _randCharIndex = UnityEngine.Random.Range(0, Singleton.RoomManager.roomMemberCount -1);

        while(turnNumberIndex.Count <= Singleton.RoomManager.roomMemberCount -1)
        {
            turnNumberIndex.Add(characters[_randCharIndex]);

            if (_randCharIndex == Singleton.RoomManager.roomMemberCount - 1)
            {
                _randCharIndex = 0;

                continue;
            }
            _randCharIndex++;
        }


    }

    // Update is called once per frame
    void LateUpdate()
    {

        //UpdateSet
        if (!Singleton.CardUp.isUp && !Singleton.ButtonManager.isReasoning && !isStop)
        {
            UpdateLogic();
        }
        else
        {
            return;
        }


    }

    public void UpdateLogic()
    {



        //Game
        int _trunindex = 0;
        //turnCount = 0;

        while (Singleton.RoomManager.isStart == true && _trunindex < Singleton.RoomManager.roomMemberCount)
        {
            Singleton.AIMembers = turnNumberIndex[_trunindex].GetComponent<AIMembers>();
            Singleton.Player = turnNumberIndex[_trunindex].GetComponent<Player>();

            if (Singleton.AIMembers != null)
            {
                Singleton.AIMembers.turnNumber = _trunindex;
            }
            else if (Singleton.Player != null)
            {
                Singleton.Player.turnNumber = _trunindex;
            }
            if (_trunindex >= Singleton.RoomManager.roomMemberCount - 1)
            {
                _trunindex = 0;

                break;
            }

            _trunindex++;
        }

        if (Singleton.AI.isAISelectComplete)
        {
            if (isTrunStart)
            {
                GameTurn();
                isTrunStart = false;

            }
            if (isTrun)
            {
                AIMembers _aimem = turnNumberIndex[turnCount].GetComponent<AIMembers>();
                Player _player = turnNumberIndex[turnCount].GetComponent<Player>();

                Debug.Log($" 턴넘버 체크시작{turnCount}");

                currentTurnTime -= Time.deltaTime;

                float normalizedValue = currentTurnTime / maxTurnTime;
                turnTimerSlider.value = normalizedValue;


                if (currentTurnTime <= 0)
                {
                    Debug.Log("시간 초과! 다음 턴으로 이동");

                    EndTurn(_aimem, _player);


                }
                else if (isNext)
                {
                    EndTurn(_aimem, _player);

                }

            }


            //isTrun = false;

            //turnCount++;

            //isTrunStart = false;
        }



        //while (roundNumber != 20)
        //{

        //    roundNumber++;

        //    //Singleton.AIMembers.myTrun = true;
        //    //Singleton.Player.myTrun = false;

        //    //if (!Singleton.AIMembers.myAnswer)
        //    //{

        //    //    
        //    //}

        //    //if (Singleton.RandomQuestion.questionCount == 0)
        //    //{
        //    //    break;
        //    //}
        //}
    }
    public void GameTurn()
    {
        AIMembers _aimem = turnNumberIndex[turnCount].GetComponent<AIMembers>();
        Player _player = turnNumberIndex[turnCount].GetComponent<Player>();

        if (_player == null && _aimem != null)//
        {
            _aimem = turnNumberIndex[turnCount].GetComponent<AIMembers>();

            //Singleton.AIMembers = turnNumberIndex[turnCount].GetComponent<AIMembers>();
            //if (_aimem == null)
            //{
            //}

            isAITrun = true;


            if (isAITrun)
            {

                _aimem.myTrun = true;
                //_aimem.myWait = false;
                //_aimem.myAnswer = false;

                _aimem.eAISTATE = eAISTATE.eAISTATE_QUESTION;



                Debug.Log($"{turnCount} : {_aimem.eCHARACTER}  AI 턴 시작");

            }

            //if (!Singleton.AIMembers.myTrun)
            //{
            //    isTrunStart = false;

            //    turnCount++;


            //}
        }

        if (_aimem == null && _player != null)
        {
            _player = turnNumberIndex[turnCount].GetComponent<Player>();


            if (_player == null)
            {

                GameObject _nullPlayer = GameObject.FindWithTag("Player");
                _player = _nullPlayer.GetComponent<Player>();
            }

            if (_player.turnNumber == turnCount)
            {

                isPlayerTrun = true;

                //_player.myTrun = true;
                ////_player.myWait = false;
                //_player.myAnswer = false;
                Debug.Log($"{turnCount} Player 턴 시작");

                _player.ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_QUESTION;


            }

 
            //if (!Singleton.Player.myTrun)
            //{
            //    isTrunStart = false;

            //    turnCount++;


            //}
        }

    }

    public void NextTurnButton()
    {
        Singleton.AudioManager.PlayButtonSFX();

        isNext = true;
    }

    void EndTurn(AIMembers _AIMEMBER,Player _PLAYER)
    {
        turnCount++;

        if (turnCount >= Singleton.RoomManager.roomMemberCount)
        {
            turnCount = 0;

        }

        if(_AIMEMBER != null)
        {
            _AIMEMBER.eAISTATE = eAISTATE.eAISTATE_WAIT;

        }
        if (_PLAYER != null)
        {
            _PLAYER.ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_WAIT;

        }
        for (int i = 0; i < Singleton.RoomManager.roomMemberCount - 1; i++)
        {
            AIMembers _aimems = Singleton.AI.aiObjects[i].GetComponent<AIMembers>();

            _aimems.eAISTATE = eAISTATE.eAISTATE_WAIT;
        }


        isAITrun = false;
        isPlayerTrun = false;


        currentTurnTime = maxTurnTime;

        isTrun = true;
        isNext = false;


        DOVirtual.DelayedCall(0.3f, () =>  GameTurn());

    }

}


//Debug.Log($" 턴넘버 체크시작");

//Singleton.AIMembers = turnNumberIndex[turnCount].GetComponent<AIMembers>();
//Singleton.Player = turnNumberIndex[turnCount].GetComponent<Player>();


//if (Singleton.AIMembers == null)
//{
//    Singleton.Player = turnNumberIndex[turnCount].GetComponent<Player>();

//    if (Singleton.Player.turnNumber == turnCount)
//    {

//        Debug.Log($"{turnCount} AI 턴 시작");
//        Singleton.Player.myTrun = true;

//    }

//    if (!Singleton.Player.myTrun)
//    {
//        isTrunStart = false;

//        turnCount++;


//    }
//}
//else if (Singleton.Player == null)
//{
//    Singleton.AIMembers = turnNumberIndex[turnCount].GetComponent<AIMembers>();

//    if (Singleton.AIMembers.turnNumber == turnCount)
//    {
//        isTrunStart = true;

//        Debug.Log($"{turnCount} Player 턴 시작");

//        Singleton.AIMembers.myTrun = true;

//    }

//    if (!Singleton.AIMembers.myTrun)
//    {
//        isTrunStart = false;

//        turnCount++;

//    }

//}



