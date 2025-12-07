using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonManager : MonoBehaviour
{
    public Player player;
    public GameObject blackBG;
    public GameObject studentObject;
    public GameObject timeObject;
    public GameObject crimeObject;
    public GameObject gameEndCanvas;
    public GameObject cardCheckCanvas;
    public GameObject reasoningCanvas;
    public GameObject howCanvas;
    public GameObject exitCanvas;

    public Canvas blackCanvas;
    public Canvas questionCanvas;



    public bool isStudentOkay = false;
    public bool isTimeOkay = false;
    public bool isCrimeOkay = false;

    public bool isReasonEnd = false;

    public bool isReasoning = false;
    public bool isHowToPlay= false;

    private void Awake()
    {
        Singleton.ButtonManager = this;
    }
    private void Update()
    {
    }
    public void OnClick_ReasoningStart()
    {
        Singleton.AudioManager.PlayButtonSFX();
        Singleton.AudioManager.ReasningBGM();


        blackBG.SetActive(true);
        blackCanvas.sortingOrder = 3;
        questionCanvas.sortingOrder = 2;
        player.ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_REASONING;
        isReasoning = true;
    }
    public void OnClickReasoningEnd(Button _CHECKBUTTON)
    {
        ReasonCheck _reasonCheck = _CHECKBUTTON.GetComponent<ReasonCheck>();
        _reasonCheck.OnClickReasoning(ref isStudentOkay, ref isTimeOkay, ref isCrimeOkay);

        switch (_reasonCheck.eBUTTONTYBE)
        {
            case eBUTTONTYBE.eBUTTONTYBE_STUDENT:
                studentObject.SetActive(false);

                DOVirtual.DelayedCall(0.5f, () =>
                {
                    timeObject.SetActive(true);

                });
                break;
            case eBUTTONTYBE.eBUTTONTYBE_TIME:
                timeObject.SetActive(false);
                studentObject.SetActive(false);

                DOVirtual.DelayedCall(0.5f, () =>
                {
                    crimeObject.SetActive(true);

                });

                break;
            case eBUTTONTYBE.eBUTTONTYBE_CRIME:
                crimeObject.SetActive(false);
                timeObject.SetActive(false);

                reasoningCanvas.SetActive(false);
                isReasonEnd = true;
                if(isReasonEnd)
                {
                    if (isStudentOkay && isTimeOkay && isCrimeOkay)
                    {
                        Singleton.Reasoning.OnReasonTrue();
                    }
                    else
                    {
                        Singleton.Reasoning.OnReasonFalse();
                    }
                }


                DOVirtual.DelayedCall(0.5f, () =>
                {
                    studentObject.SetActive(true);

                    Singleton.ButtonManager.isStudentOkay = false;
                    Singleton.ButtonManager.isTimeOkay = false;
                    Singleton.ButtonManager.isCrimeOkay = false;
                    isReasonEnd = false;

                });



                break;
        }
    }

    public void OnClickCardCheckTrue()
    {

            cardCheckCanvas.SetActive(true);
        

    }
    public void OnClickCardCheckFalse()
    {

            cardCheckCanvas.SetActive(false);
    
    }


    public void OnClick_HowToPlayOpen()
    {
        isHowToPlay = true;
        Singleton.GameManager.isStop = true;

        Singleton.AudioManager.PlayButtonSFX();
        howCanvas.SetActive(true);
    }
    public void OnClick_HowToPlayClose()
    {
        Singleton.AudioManager.PlayButtonSFX();
        howCanvas.SetActive(false);
        Singleton.GameManager.isStop = false;

        isHowToPlay = false;

    }

    public void OnClick_ExitOpen()
    {
        Singleton.AudioManager.PlayButtonSFX();
        exitCanvas.SetActive(true);
    }
    public void OnClick_ExitClose()
    {
        Singleton.AudioManager.PlayButtonSFX();
        exitCanvas.SetActive(false);
    }

    public void OnClick_ExitGame()
    {
        Singleton.AudioManager.PlayButtonSFX();

        DOVirtual.DelayedCall(0.5f, () =>
        {
            Singleton.SceneManager.LoadSceneLobby();
        });
    }
    //public void OnClick_RestartGame()
    //{
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("01_Main");
    //}
    //public void OnClick_ExitGame()
    //{
    //    Application.Quit();
    //}
}
