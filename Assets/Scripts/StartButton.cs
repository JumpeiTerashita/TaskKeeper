using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    public TaskItemScript baseItem;

    private Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        buttonText = GetComponentInChildren<Text>();

        UpdateButtonText();
    }

    public void OnClick()
    {
        baseItem.ToggleTimer();

        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        bool isTimerRunning = baseItem.isTimerRunning();

        buttonText.text = isTimerRunning ? "Stop" : "Start";
    }

}
