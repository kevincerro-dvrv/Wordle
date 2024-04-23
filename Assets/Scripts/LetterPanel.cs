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
    


    private const int ROTATION_STATUS_WAITING = 0;
    private const int ROTATION_STATUS_ROTATING_1_HALF = 1;
    private const int ROTATION_STATUS_ROTATING_2_HALF = 2;
    private const int ROTATION_STATUS_COMPLETED = 3; 

    private float t;
    private float rotationTime = 2f;

    private Quaternion startRotation;
    private Quaternion invertedRotation;

    private LetterStatus status;

    private int rotationStatus;
    // Start is called before the first frame update
    void Start() {
        rotationStatus = ROTATION_STATUS_WAITING;
        startRotation = transform.rotation;
        invertedRotation = Quaternion.AngleAxis(180f, transform.right);
    }

    // Update is called once per frame
    void Update() {
        if(rotationStatus == ROTATION_STATUS_ROTATING_1_HALF) {

            transform.rotation = Quaternion.Lerp (startRotation, invertedRotation, t);
            t += Time.deltaTime / rotationTime;
            if(t>= 0.5f) {
                rotationStatus = ROTATION_STATUS_ROTATING_2_HALF;
                transform.rotation = Quaternion.AngleAxis(270f, transform.right);
                Debug.Log("[LetterPanel] Update rotationPhaseChange");
                ApplyStatus();
            } 
   
        }  else if(rotationStatus == ROTATION_STATUS_ROTATING_2_HALF) {
            transform.rotation = Quaternion.Lerp (invertedRotation, startRotation, t);
            t += Time.deltaTime / rotationTime;
            if(t >= 1f) {
                rotationStatus = ROTATION_STATUS_COMPLETED;
                transform.rotation = Quaternion.identity;
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
        this.status = status;
        rotationStatus = ROTATION_STATUS_ROTATING_1_HALF;
        t = 0;
    }

    private void ApplyStatus() {
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
    }
}

public enum LetterStatus {
    Green,
    Orange,
    Gray
}
