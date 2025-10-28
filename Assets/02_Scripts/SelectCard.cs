using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
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

    public Button studentButton;
    public Button timeButton;
    public Button crimeButton;
    public Button selectedButton;


    Button[] studentButtons;
    Button[] timeButtons;
    Button[] crimeButtons;


    public Image cardRenderer;

    [SerializeField]
    RectTransform slectedCard;
    Vector3 selectedCardPos;

    Ease ease = Ease.InOutSine;

    List<string> studentNames = new List<string>()
    {
        "Ari_Choi",//1
        "bada_Seo",//2
        "Bora_Nam",//3
        "doha_Bae",//4
        "Donghoon_Moon",//5
        "galam_Heo",//6
        "hali_Gu",//7
        "hanbyeol_Bu",//8
        "Jiho_Lee",//9
        "mingug_Jo",//10
        "Minjae_Kim",//11
        "Mirae_Yoon",//12
        "schoolmaste"//13
    };

    List<string> timeNames = new List<string>()
    {
        "After",//1
        "Break",//2
        "CleaningTime",//3
        "DropOff",//4
        "GoToSchool",//5
        "Lunch",//6
    };

    List<string> crimeNames = new List<string>()
    {
        "Absence",//1
        "Alcohol",//2
        "Cigarette",//3
        "Cleaning",//4
        "Doodle",//5
        "Dues",//6
        "Homework",//7
        "InformalLanguage",//8
        "Restroom",//9
        "Teacher",//10
        "Test",//11
        "Washing",//12
    };

    // Start is called before the first frame update
    void Start()
    {
        selectedCardPos = slectedCard.anchoredPosition;


        SetCard(studentCanvas);

        SelectButton(studentCanvas, ref studentButtons, (idx) => SelectStudentCard(idx));
    }


    //Student => Time => Crime    
    void SelectStudentCard(int index)
    {
        selectedButton = studentButtons[index];
        studentButton = studentButtons[index];

        int _nameIndex = UnityEngine.Random.Range(0, studentNames.Count);//{_studentName}
        string _studentName = studentNames[_nameIndex];

        CardRotate(selectedButton.transform, "01_studentID", $"{_studentName}", "studentID_back", timeCanvas, studentCanvas, crimeCanvas);//, timeCanvas, studentCanvas, crimeCanvas, studentButton


        SelectButton(timeCanvas, ref timeButtons, (idx) => SelectTimeCard(idx));

    }

    void SelectTimeCard(int index)
    {
        selectedButton = timeButtons[index];
        timeButton = timeButtons[index];

        if (timeButton == null)
        {
            Debug.Log("None Timebutton");
        }

        int _nameIndex = UnityEngine.Random.Range(0, timeNames.Count);//{_studentName}
        string _timeName = timeNames[_nameIndex];

        CardRotate(selectedButton.transform, "02_time", $"{_timeName}", "time_back", crimeCanvas, studentCanvas, timeCanvas);//, crimeCanvas, studentCanvas, timeCanvas, timeButton

        SelectButton(crimeCanvas, ref crimeButtons, (idx) => SelectCrimeCard(idx));

    }
    void SelectCrimeCard(int index)
    {

        selectedButton = crimeButtons[index];
        crimeButton = crimeButtons[index];

        int _nameIndex = UnityEngine.Random.Range(0, crimeNames.Count);//{_studentName}
        string _crimeName = crimeNames[_nameIndex];

        if (crimeButton == null)
        {
            Debug.Log("None Crimebutton");
        }

        CardRotate(selectedButton.transform, "03_crime", $"{_crimeName}", "crime_back", crimeCanvas, studentCanvas, timeCanvas);//, crimeCanvas, studentCanvas, timeCanvas, crimeButton


        DOVirtual.DelayedCall(2.5f, () => SetActiveFalse());
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    void SelectButton(GameObject _PARENTCANVAS,ref Button[] _ALLBUTTONS, Action<int> _ONCLICKED)
    {
        _ALLBUTTONS = _PARENTCANVAS.GetComponentsInChildren<Button>();

        if (_ALLBUTTONS == null || _ALLBUTTONS.Length == 0)
        {
            Debug.LogWarning($"{_PARENTCANVAS.name} 안에 Button이 없습니다!");

            return;
        }


        for (int i = 0; i < _ALLBUTTONS.Length; i++)
        {
            int index = i;

            _ALLBUTTONS[i].onClick.AddListener(() => _ONCLICKED(index));
        }

    }

     
        void SetFalseCard(GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3)
        {
            _CANVAS1.SetActive(true);
            _CANVAS2.SetActive(false);
            _CANVAS3.SetActive(false);

            cards.Clear();

            SetCard(_CANVAS1);
        }

        void CardRotate(Transform _BUTTONTR, string _FILENAME, string _FCARDNAME, string _BCARDNAME, GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3)//GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3, Button _BUTTON01, Button[] _BUTTONS
        {



            Sprite _frontCard = Resources.Load<Sprite>($"03_Source/{_FILENAME}/{_FCARDNAME}");
            Sprite _backCard = Resources.Load<Sprite>($"03_Source/04_back/{_BCARDNAME}");

            selectedButton.image.sprite = _backCard;

            var _sequence = DOTween.Sequence();
            _sequence.Append(_BUTTONTR.DORotate(_BUTTONTR.eulerAngles
                + new Vector3(0, 90, 0), 0.5f)).SetEase(ease);

            _sequence.AppendCallback(() =>
            { selectedButton.image.sprite = (_BUTTONTR.eulerAngles.y < 180) ? selectedButton.image.sprite = _frontCard : selectedButton.image.sprite = _backCard; });

            _sequence.Append(_BUTTONTR.DORotate(_BUTTONTR.eulerAngles
               + new Vector3(0, 360, 0), 0.6f)).SetEase(ease);

            CardChage(_CANVAS1, _CANVAS2, _CANVAS3);

        }

        void CardChage(GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3)
        {
            DOVirtual.DelayedCall(1f, () => ReturnAllCards());
            DOVirtual.DelayedCall(3f, () => SetFalseCard(_CANVAS1, _CANVAS2, _CANVAS3));
        }
    
}




//Button SelectButton(GameObject _PARENTCANVAS, Button[] _ALLBUTTONS)
//{
//    _ALLBUTTONS = _PARENTCANVAS.GetComponentsInChildren<Button>();

//    if (_ALLBUTTONS == null || _ALLBUTTONS.Length == 0)
//    {
//        Debug.LogWarning($"{_PARENTCANVAS.name} 안에 Button이 없습니다!");
//        return null;
//    }

//    int _buttonIndex = UnityEngine.Random.Range(0, _ALLBUTTONS.Length);
//    selectedButton = _ALLBUTTONS[_buttonIndex];

//    for (int i = 0; i < _ALLBUTTONS.Length; i++)
//    {
//        if (i == _buttonIndex)
//        {
//            _ALLBUTTONS[i].interactable = true; // 클릭 가능
//        }
//        else
//        {
//            _ALLBUTTONS[i].interactable = false;
//        }
//    }

//    cardRenderer = selectedButton.GetComponent<Image>();



//    return selectedButton;
//}