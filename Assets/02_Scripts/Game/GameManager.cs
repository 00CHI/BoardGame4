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

    public List<GameObject> turnNumber = new List<GameObject>();

    int rooundNumber;

    // Start is called before the first frame update
    void Awake()
    {
        Singleton.GameManager = this;
        eCHARACTER = eCHARACTER.eCHARACTER_NONE;
        eROUND = eROUND.eROUND_NONE;

        int _randCharIndex = Random.Range(0, Singleton.RoomManager.roomMemberCount + 1);

        while(turnNumber.Count < Singleton.RoomManager.roomMemberCount + 1)
        {
            turnNumber.Add(characters[_randCharIndex]);

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

        //while(Singleton.RandomQuestion.questionCount == 0)
        //{
        //    rooundNumber = 0;
        //    rooundNumber++;
        //}
    }

    void GameTurn()
    {
    }
}
