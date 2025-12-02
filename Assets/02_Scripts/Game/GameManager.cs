using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public eCHARACTER eCHARACTER;
    public eROUND eROUND;

    public List<GameObject> characters = new List<GameObject>();

    public List<GameObject> turnNumberIndex = new List<GameObject>();


    public bool isTrunStart;
    public bool isTrun;
    public bool isAITrun;
    public bool isPlayerTrun;

    public int turnCount;
    //int roundNumber;

    // Start is called before the first frame update
    void Awake()
    {
        Singleton.GameManager = this;

        isTrunStart = true;
        isTrun = true;
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
    void Start()
    {


    }

    // Update is called once per frame
    void LateUpdate()
    {
        //roundNumber = 0;

        int _trunindex = 0;
        //turnCount = 0;

        while (Singleton.RoomManager.isStart == true && _trunindex < Singleton.RoomManager.roomMemberCount )
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
            if(_trunindex >= Singleton.RoomManager.roomMemberCount -1 )
            {
                _trunindex = 0;

                break;
            }

            _trunindex++;
        }

        if (Singleton.AI.isAISelectComplete )
        {

            if(isTrun)
            {
                Debug.Log($" 턴넘버 체크시작{turnCount}");

                GameTurn();

                Singleton.AI.isAISelectComplete = false;

                isTrun = false;

                //turnCount++;

                //isTrunStart = false;
            }


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

                isAITrun = false;



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



