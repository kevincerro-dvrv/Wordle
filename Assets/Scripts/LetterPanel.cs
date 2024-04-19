using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterPanel : MonoBehaviour {
    public TextMeshProUGUI letterField;
    public GameObject whitePanel;
    public GameObject greenPanel;
    public GameObject grayPanel;
    public GameObject orangePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetSize() {
        return new Vector2(80, 80);
    }

    public void SetLetter(char letter) {
        letterField.text = letter.ToString();
    }

    public string GetLetter() {
        return letterField.text;
    }

    public void RemoveLetter() {
        letterField.text = "";
    }

    public void SetStatus(LetterStatus status) {
        if (status != LetterStatus.Reset) {
            SetStatus(LetterStatus.Reset);
        }
        
        switch (status) {
            case LetterStatus.Green:
                greenPanel.SetActive(true);
                break;
            case LetterStatus.Orange:
                orangePanel.SetActive(true);
                break;
            case LetterStatus.Gray:
                grayPanel.SetActive(true);
                break;
            case LetterStatus.White:
                whitePanel.SetActive(true);
                break;
            case LetterStatus.Reset:
                greenPanel.SetActive(false);
                orangePanel.SetActive(false);
                grayPanel.SetActive(false);
                whitePanel.SetActive(false);
                break;
        }
    }
}

public enum LetterStatus {
    Green,
    Orange,
    Gray,
    White,
    Reset,
}
