using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonManager : MonoBehaviour
{
    public Player player;
    public GameObject blackBG;
    public GameObject studentCanvas;
    public GameObject timeCanvas;
    public GameObject crimeCanvas;

    public Canvas blackCanvas;
    public Canvas questionCanvas;



    public bool isStudentOkay = false;
    public bool isTimeOkay = false;
    public bool isCrimeOkay = false;

    private void Awake()
    {
    }

    public void OnClick_ReasoningStart()
    {
        blackBG.SetActive(true);
        blackCanvas.sortingOrder = 3;
        questionCanvas.sortingOrder = 2;
        player.ePLAYERSTATE = ePLAYERSTATE.ePLAYERSTATE_REASONING;
    }
    public void OnClickReasoningEnd(Button _CHECKBUTTON)
    {
        ReasonCheck _reasonCheck = _CHECKBUTTON.GetComponent<ReasonCheck>();
        _reasonCheck.OnClickReasoning(ref isStudentOkay, ref isTimeOkay, ref isCrimeOkay);

        switch(_reasonCheck.eBUTTONTYBE)
        {
            case eBUTTONTYBE.eBUTTONTYBE_STUDENT:
                studentCanvas.SetActive(false);

                DOVirtual.DelayedCall(0.5f, () =>
                {
                    timeCanvas.SetActive(true);

                });
                break;
            case eBUTTONTYBE.eBUTTONTYBE_TIME:
                timeCanvas.SetActive(false);

                DOVirtual.DelayedCall(0.5f, () =>
                {
                    crimeCanvas.SetActive(true);

                });

                break;
            case eBUTTONTYBE.eBUTTONTYBE_CRIME:
                crimeCanvas.SetActive(false);

                //if ()
                //{

                //}
                //if ()
                //{

                //}
                break;
        }
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
