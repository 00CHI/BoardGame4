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

    public bool isTrunStart = false;
    //int roundNumber;

    // Start is called before the first frame update
    void Awake()
    {
        Singleton.GameManager = this;
        eCHARACTER = eCHARACTER.eCHARACTER_NONE;
        eROUND = eROUND.eROUND_NONE;

        int _randCharIndex = UnityEngine.Random.Range(0, Singleton.RoomManager.roomMemberCount + 1);

        while(turnNumberIndex.Count < Singleton.RoomManager.roomMemberCount + 1)
        {
            turnNumberIndex.Add(characters[_randCharIndex]);

            if (_randCharIndex == Singleton.RoomManager.roomMemberCount)
            {
                _randCharIndex = 0;

                continue;
            }
            _randCharIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //roundNumber = 0;

        int _trunindex = 0;

        while (Singleton.RoomManager.isStart == true)
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


            if(_trunindex >= Singleton.RoomManager.roomMemberCount)
            {
                _trunindex = 0;
                break;
            }

            _trunindex++;
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
        isTrunStart = true;

        int _trunindex = 0;
        int _turnCount = 0;

        if (isTrunStart)
        {
            Debug.Log($" 턴넘버 체크시작");

            while (true)
            {
                Singleton.AIMembers = turnNumberIndex[_trunindex].GetComponent<AIMembers>();
                if (Singleton.AIMembers == null)
                {
                    Singleton.Player = turnNumberIndex[_trunindex].GetComponent<Player>();
                }
                if (Singleton.Player == null)
                {
                    Singleton.AIMembers = turnNumberIndex[_trunindex].GetComponent<AIMembers>();
                }
                if (Singleton.AIMembers != null)
                {
                    if (Singleton.AIMembers.turnNumber == _turnCount)
                    {

                        Singleton.AIMembers.myTrun = true;

                        Debug.Log($"{_turnCount} AI 턴 시작");

                        //isTrunStart = true;
                    }
                }
                else if (Singleton.Player != null)
                {
                    if (Singleton.Player.turnNumber == _turnCount)
                    {

                        Singleton.Player.myTrun = true;

                        Debug.Log($"{_turnCount} Player 턴 시작");
                        //isTrunStart = true;
                    }
                }

                if (!Singleton.AIMembers.myTrun)
                {
                    isTrunStart = false;
                    continue;
                }

                _trunindex++;
                _turnCount++;

                if (Singleton.AIMembers.turnNumber >= Singleton.RoomManager.roomMemberCount || Singleton.Player.turnNumber >= Singleton.RoomManager.roomMemberCount)
                {

                }
            }


            //switch (Singleton.AIMembers.turnNumber)
            //{
            //    case 0:
            //        Singleton.AIMembers.myTrun = true;
            //        Singleton.Player.myTrun = false;

            //        break;
            //    case 1:
            //        Singleton.Player.myTrun = true;
            //        Singleton.AIMembers.myTrun = false;

            //        break;
            //}




            _trunindex++;

            Singleton.SelectCard.isSelectedComplete = false;
        }
    }
}
