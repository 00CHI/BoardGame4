//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

class SelectCard : SpreadCard
{
    [SerializeField]
    GameObject studentCanvas;
    [SerializeField]
    GameObject timeCanvas;
    [SerializeField]
    GameObject crimeCanvas;

    Button studentButton;
    Button timeButton;
    Button crimeButton;

    Button[] studentButtons;
    Button[] timeButtons;
    Button[] crimeButtons;

    // Start is called before the first frame update
    void Start()
    {
        SelectAllButtons();
        SetCard(studentCanvas);


        studentButton.onClick.AddListener(SelectStudentCard);
        timeButton.onClick.AddListener(SelectTimeCard);
        crimeButton.onClick.AddListener(SelectCrimeCard);

    }

    //Student => Time => Crime
    void SelectStudentCard()
    {
        SetFalseCard(timeCanvas, studentCanvas, crimeCanvas);
        SetCard(timeCanvas);
        
    }
    void SelectTimeCard()
    {
        SetFalseCard(crimeCanvas, studentCanvas, timeCanvas);
        SetCard(crimeCanvas);

    }
    void SelectCrimeCard()
    {
        gameObject.SetActive(false);
    }

    void SelectAllButtons()
    {
        studentButton = SelectButton(studentCanvas, studentButtons);
        timeButton = SelectButton(timeCanvas, timeButtons);
        crimeButton = SelectButton(crimeCanvas, crimeButtons);

    }

    Button SelectButton(GameObject _PARENTCANVAS, Button[] _ALLBUTTONS)
    {
        _ALLBUTTONS = _PARENTCANVAS.GetComponentsInChildren<Button>();

        if (_ALLBUTTONS == null || _ALLBUTTONS.Length == 0)
        {
            Debug.LogWarning($"{_PARENTCANVAS.name} 안에 Button이 없습니다!");
            return null;
        }

        int _buttonIndex = UnityEngine.Random.Range(0, _ALLBUTTONS.Length);
        Button _selectedButton = _ALLBUTTONS[_buttonIndex];

        for (int i = 0; i < _ALLBUTTONS.Length; i++)
        {
            if (i == _buttonIndex)
            {
                _ALLBUTTONS[i].interactable = true; // 클릭 가능
            }
            else
            {
                _ALLBUTTONS[i].interactable = false;
            }
        }

        return _selectedButton;
    }

    void SetFalseCard(GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3)
    {
        _CANVAS1.SetActive(true);
        _CANVAS2.SetActive(false);
        _CANVAS3.SetActive(false);
    }
}