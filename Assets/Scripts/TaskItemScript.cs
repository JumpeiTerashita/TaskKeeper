using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TaskItemScript : MonoBehaviour
{
    [SerializeField]
    public Text timerText = null;

    [SerializeField]
    public Text taskText = null;

    [SerializeField]
    public int createdDate;

    [SerializeField]
    public int totalSecond = 0;

    [SerializeField]
    public string taskName;

    [SerializeField]
    private bool isRunning = false;

    private int hour;
    private int minute;
    private float second;

    public void Setup(TaskItemStruct _item)
    {
        createdDate = _item.createdDate;
        totalSecond = _item.totalSecond;
        taskName = _item.taskName;
        isRunning = _item.isRunning;
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            second += Time.deltaTime;

            if (second >= 60.0f)
            {
                second -= 60.0f;
                minute += 1;

                if (minute >= 60)
                {
                    minute -= 60;
                    hour += 1;
                }


            }

            UpdateDispStr();
        }

       
    }

    public void Init()
    {
        taskText.text = taskName;

        int tmp = totalSecond;
        hour = tmp / 3600;
        tmp = tmp % 3600;
        minute = tmp / 60;
        second = tmp % 60;

        UpdateDispStr();

    }

    private void UpdateDispStr()
    {
        string hourStr = hour.ToString("00");
        string minuteStr = minute.ToString("00");
        string secondStr = (Mathf.Floor(second)).ToString("00");


        timerText.text = hourStr + ":" + minuteStr + ":" + secondStr;
    }

    public void ToggleTimer()
    {
        isRunning = !isRunning;
    }

    public bool isTimerRunning()
    {
        return isRunning;
    }

    public void ResetTimer()
    {
        hour = 0;
        minute = 0;
        second = 0;

        UpdateDispStr();
    }
}
