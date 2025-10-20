//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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

    public Image _cardRenderer;


    //Ease ease = Ease.InOutSine;

    // Start is called before the first frame update
    void Start()
    {
        studentButton = SelectButton(studentCanvas, studentButtons);
  
        SetCard(studentCanvas);


        studentButton.onClick.AddListener(SelectStudentCard);
        timeButton.onClick.AddListener(SelectTimeCard);
        crimeButton.onClick.AddListener(SelectCrimeCard);
    }



    //Student => Time => Crime    
    void SelectStudentCard()
    {
        CatdRotate("01_studentID","Ari_Choi", "studentID_back");
        timeButton = SelectButton(timeCanvas, timeButtons);

        SetFalseCard(timeCanvas, studentCanvas, crimeCanvas);
        cards.Clear();
        SetCard(timeCanvas);

    }
    void SelectTimeCard()
    {
        SetFalseCard(crimeCanvas, studentCanvas, timeCanvas);
        crimeButton = SelectButton(crimeCanvas, crimeButtons);

        cards.Clear();
        SetCard(crimeCanvas);
    }
    void SelectCrimeCard()
    {
        gameObject.SetActive(false);
    }


    void SetFalseCard(GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3)
    {
        _CANVAS1.SetActive(true);
        _CANVAS2.SetActive(false);
        _CANVAS3.SetActive(false);
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

        _cardRenderer = _selectedButton.GetComponent<Image>();


        return _selectedButton;
    }


    protected void CatdRotate(string _FILENAME, string _FCARDNAME, string _BCARDNAME)
    {

        _cardRenderer.sprite = Resources.Load<Sprite>($"03_Source/{_FILENAME}/{_FCARDNAME}");
        // _cardRenderer.sprite = Resources.Load<Sprite>($"03_Source/04_back/{_BCARDNAME}");

        //var _sequence = DOTween.Sequence();
        //_sequence.Append(this.transform.DORotate(this.transform.eulerAngles
        //    + new Vector3(0, 90, 0), 0.4f)).SetEase(ease);

        //_sequence.AppendCallback(() =>
        //{ _frontRenderer.sprite = (this.transform.eulerAngles.y < 180) ? _frontRenderer.sprite : _backRenderer.sprite; });

        //_sequence.Append(this.transform.DORotate(this.transform.eulerAngles
        //   + new Vector3(0, 180, 0), 0.4f)).SetEase(ease);
    }
}