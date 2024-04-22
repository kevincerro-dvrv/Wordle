using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterPanel : MonoBehaviour {    

    public TextMeshProUGUI letterField;

    public GameObject whitePanel; 
    public GameObject greenPanel;
    public GameObject greyPanel;
    public GameObject orangePanel;
    
    private bool rotate = false;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(rotate) {
            transform.Rotate(transform.right * Time.deltaTime * 90);
        }
        
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
        whitePanel.SetActive(false);
        greenPanel.SetActive(false);
        greyPanel.SetActive(false);
        orangePanel.SetActive(false);

        switch(status) {
            case LetterStatus.Green: 
               greenPanel.SetActive(true);
               break;
            case LetterStatus.Gray: 
               greyPanel.SetActive(true);
               break;
            case LetterStatus.Orange: 
               orangePanel.SetActive(true);
               break;
        }

        rotate = true;
    }
}

public enum LetterStatus {
    Green,
    Orange,
    Gray
}
