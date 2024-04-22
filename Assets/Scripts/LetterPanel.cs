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
    private int rotationPhase = 0;
    private LetterStatus effectiveStatus;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {        
        if(rotate) {
            transform.Rotate(transform.right * Time.deltaTime * 90);

            if (rotationPhase == 0 && transform.rotation.eulerAngles.x >= 89) {
                rotationPhase = 1;
                Vector3 newEulerAngles  = transform.eulerAngles;
                newEulerAngles.x = 270;
                transform.eulerAngles = newEulerAngles;
                SetEffectiveStatus();
            } else if (rotationPhase == 1 && transform.rotation.eulerAngles.x >= 359) {
                rotationPhase = 2;
                rotate = false;
            }
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
        whitePanel.SetActive(true);
        greenPanel.SetActive(false);
        greyPanel.SetActive(false);
        orangePanel.SetActive(false);

        effectiveStatus = status;

        rotate = true;
    }

    public void SetEffectiveStatus()
    {
        whitePanel.SetActive(false);
        switch(effectiveStatus) {
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
    }
}

public enum LetterStatus {
    Green,
    Orange,
    Gray
}
