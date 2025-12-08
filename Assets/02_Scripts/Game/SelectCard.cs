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

public class SelectCard : SpreadCard
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
    Button selectedButton;


    public Button[] studentButtons;
    public Button[] timeButtons;
    public Button[] crimeButtons;


    public Image cardRenderer;

    public Image studentCard;
    public Image timeCard;
    public Image crimeCard;

    public Image endStudentCard;
    public Image endTimeCard;
    public Image endCrimeCard;

    string studentName;
    string timeName;
    string crimeName;

    public int studentNameIndex;
    public int timeNameIndex;
    public int cirmeNameIndex;

    public bool isSelectedComplete;



    [SerializeField]
    RectTransform slectedCard;
    Vector3 selectedCardPos;

    Ease ease = Ease.InOutSine;

    public List<string> studentNames = new List<string>()
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

    public List<string> timeNames = new List<string>()
    {
        "After01",//1
        "Break01",//2
        "CleaningTime01",//3
        "DropOff01",//4
        "GoToSchool01",//5
        "Lunch01",//6
        "After02",//7
        "Break02",//8
        "CleaningTime02",//9
        "DropOff02",//10
        "GoToSchool02",//11
        "Lunch02",//12
    };

    public List<string> crimeNames = new List<string>()
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
    void Awake()
    {
        Singleton.SelectCard = this;
        selectedCardPos = slectedCard.anchoredPosition;

        SetCard(studentCanvas);

        SelectButton(studentCanvas, ref studentButtons, (idx) => SelectStudentCard(idx));
    }


    //Student => Time => Crime    
    void SelectStudentCard(int index)
    {
        selectedButton = studentButtons[index];
        studentButton = studentButtons[index];

        if (!Singleton.RoomManager.isSchoolMaster)
        {
            studentNameIndex = UnityEngine.Random.Range(0, studentNames.Count -1);//{_studentName}
            studentName = studentNames[studentNameIndex];

        }
        else if (Singleton.RoomManager.isSchoolMaster)
        {
            studentNameIndex = UnityEngine.Random.Range(0, studentNames.Count);//{_studentName}
            studentName = studentNames[studentNameIndex];

        }

        if (Singleton.Player == null)
        {
            GameObject _player = GameObject.FindWithTag("Player");
            Singleton.Player = _player.GetComponent<Player>();
        }
        Singleton.Player.eSTUDENT = (eSTUDENT)studentNameIndex + 1;


        CardRotate(selectedButton.transform, "01_studentID", $"{studentName}", "studentID_back", timeCanvas, studentCanvas, crimeCanvas);//, timeCanvas, studentCanvas, crimeCanvas, studentButton

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

        timeNameIndex = UnityEngine.Random.Range(0, timeNames.Count);//{_studentName}
        timeName = timeNames[timeNameIndex];

        if (Singleton.Player == null)
        {
            GameObject _player = GameObject.FindWithTag("Player");
            Singleton.Player = _player.GetComponent<Player>();
        }
        Singleton.Player.eTIME = (eTIME)timeNameIndex + 1;


        CardRotate(selectedButton.transform, "02_time", $"{timeName}", "time_back", crimeCanvas, studentCanvas, timeCanvas);//, crimeCanvas, studentCanvas, timeCanvas, timeButton

        SelectButton(crimeCanvas, ref crimeButtons, (idx) => SelectCrimeCard(idx));

    }
    void SelectCrimeCard(int index)
    {

        selectedButton = crimeButtons[index];
        crimeButton = crimeButtons[index];

        cirmeNameIndex = UnityEngine.Random.Range(0, crimeNames.Count);//{_studentName}
        crimeName = crimeNames[cirmeNameIndex];

        if (Singleton.Player == null)
        {
            GameObject _player = GameObject.FindWithTag("Player");
            Singleton.Player = _player.GetComponent<Player>();
        }
        Singleton.Player.eCRIME = (eCRIME)cirmeNameIndex + 1;



        CardRotate(selectedButton.transform, "03_crime", $"{crimeName}", "crime_back", crimeCanvas, studentCanvas, timeCanvas);//, crimeCanvas, studentCanvas, timeCanvas, crimeButton


        DOVirtual.DelayedCall(2.5f, () => SetActiveFalse());
        DOVirtual.DelayedCall(2.5f, () => SetGameCard(studentCard, "01_studentID", $"{studentName}"));
        DOVirtual.DelayedCall(2.5f, () => SetGameCard(timeCard, "02_time", $"{timeName}"));
        DOVirtual.DelayedCall(2.5f, () => SetGameCard(crimeCard, "03_crime", $"{crimeName}"));
        DOVirtual.DelayedCall(2.5f, () => SetGameCard(endStudentCard, "01_studentID", $"{studentName}"));
        DOVirtual.DelayedCall(2.5f, () => SetGameCard(endTimeCard, "02_time", $"{timeName}"));
        DOVirtual.DelayedCall(2.5f, () => SetGameCard(endCrimeCard, "03_crime", $"{crimeName}"));
        DOVirtual.DelayedCall(2.5f, () =>
        {
            isSelectedComplete = true;
            Singleton.AudioManager.buttonSFXStop();

        });


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

            CardChange(_CANVAS1, _CANVAS2, _CANVAS3);

        }

        void CardChange(GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3)
        {
            DOVirtual.DelayedCall(1f, () => ReturnAllCards());
            DOVirtual.DelayedCall(3f, () => SetFalseCard(_CANVAS1, _CANVAS2, _CANVAS3));
        }

        void SetGameCard(Image _CARDIMAGE,  string _FILENAME, string _CARDNAME)
        {
            _CARDIMAGE.sprite = Resources.Load<Sprite>($"03_Source/{_FILENAME}/{_CARDNAME}");
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