using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using Unity.VisualScripting;
#endif
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ProfileButton : MonoBehaviour
{
    public AIMembers aiMembers;
    public Player player;
    public ProfileButton profileButton;
    public ReasoningAnim studentAnim;


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
        if (aiMembers.eSTUDENT == eSTUDENT.eSTUDENT_schoolmaster)
        {
            proButton.image.sprite = Resources.Load<Sprite>("03_Source/07_UI/profile/Schoolmaste_Profile");
            aiMembers.isReason = true;
            aiMembers.isReasonComplete = true;
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
            Image _renderer = proButton.GetComponent<Image>();
            Darken(_renderer, 0.5f);

            studentAnim.AppearCards();
            Singleton.Reasoning.OnReasoning(aiMembers);
            reasoningCanvas.SetActive(true);
            proButton.interactable = false;
        }

    }

    public void Darken(Image _IMAGE, float _DARKEN)
    {
        Color c = _IMAGE.color;
        c *= _DARKEN; 
        _IMAGE.color = c;
    }

}
