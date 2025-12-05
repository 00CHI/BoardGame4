using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ProfileButton : MonoBehaviour
{
    public AIMembers aiMembers;
    public Player player;
    public ProfileButton profileButton;
    public bool isAnswer;

    public GameObject reasoningCanvas;
    Button proButton;

    // Start is called before the first frame update
    void Awake()
    {
        Singleton.ProfileButton = this;

        profileButton = GetComponent<ProfileButton>();
        proButton = GetComponent<Button>();

        profileButton.isAnswer = true;
        proButton.onClick.AddListener(OnButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
        if (aiMembers.eSTUDENT == eSTUDENT.eSTUDENT_schoolmaste)
        {
            proButton.image.sprite = Resources.Load<Sprite>("03_Source/07_UI/profile/Schoolmaste_Profile");
        }
        if (player.ePLAYERSTATE == ePLAYERSTATE.ePLAYERSTATE_REASONING)
        {
            profileButton.isAnswer = false;
        }

    }
    void OnButtonClick()
    {

        if(profileButton.isAnswer)
        {
            aiMembers.eAISTATE = eAISTATE.eAISTATE_ANSWER;
            aiMembers.myAnswer = true;
            aiMembers.answerPanel.SetActive(true);
            player.ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_WAIT;
            profileButton.isAnswer = false;

        }
        else if (!profileButton.isAnswer)
        {
            Singleton.Reasoning.OnReasoning(aiMembers);
            reasoningCanvas.SetActive(true);
        }




    }
}
