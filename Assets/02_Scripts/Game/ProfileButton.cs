using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ProfileButton : MonoBehaviour
{
    public AIMembers aiMembers;
    public Player player;
    Button profileButton;

    // Start is called before the first frame update
    void Awake()
    {
        profileButton = GetComponent<Button>();

        profileButton.onClick.AddListener(OnButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnButtonClick()
    {



        aiMembers.eAISTATE = eAISTATE.eAISTATE_ANSWER;
        aiMembers.myAnswer = true;
        aiMembers.answerPanel.SetActive(true);
        player.ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_WAIT;


    }
}
