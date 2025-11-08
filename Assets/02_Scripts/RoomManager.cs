using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    int roomMemberCount = 4;

    string teacherToggle = "YES";

    Text roomMemberText;
    Text teacherToggleText;

    Button memberPlusButton;
    Button memberMinusButton;

    Button teacherYesButton;
    Button teacherNoButton;

    // Start is called before the first frame update
    void Awake()
    {
        roomMemberText = GameObject.Find("Person_Text").GetComponent<Text>();
        teacherToggleText = GameObject.Find("ToggleTeacher_Text").GetComponent<Text>();

        memberPlusButton = GameObject.Find("PresonPlus_Button").GetComponent<Button>();
        memberMinusButton = GameObject.Find("PresonMinus_Button").GetComponent<Button>();

        teacherYesButton = GameObject.Find("TeacherLeft_Button").GetComponent<Button>();
        teacherNoButton = GameObject.Find("TeacherRight_Button").GetComponent<Button>();


        roomMemberText.text = $"{roomMemberCount}Έν";

        memberPlusButton.onClick.AddListener(OnMemeberPlusClick);
        memberMinusButton.onClick.AddListener(OnMemeberMinusClick);

        teacherYesButton.onClick.AddListener(OnTeacherToggleClick);
        teacherNoButton.onClick.AddListener(OnTeacherToggleClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMemeberPlusClick()
    {

        if (roomMemberCount >= 10)
        {
            roomMemberCount = 3;
        }


        roomMemberCount += 1;
        roomMemberText.text = $"{roomMemberCount}Έν";

    }


    void OnMemeberMinusClick()
    {


        if (roomMemberCount <= 4)
        {
            roomMemberCount = 11;
        }

        roomMemberCount -= 1;
        roomMemberText.text = $"{roomMemberCount}Έν";

    }

    void OnTeacherToggleClick()
    {
        if (teacherToggle == "YES")
        {
            teacherToggle = "NO";
        }
        else
        {
            teacherToggle = "YES";
        }

        teacherToggleText.text = teacherToggle;
    }

}
