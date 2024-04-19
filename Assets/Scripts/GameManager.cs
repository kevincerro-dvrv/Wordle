using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Button buttonSend;
    public GameObject notValidWordPanel;

    public WordPanel wordPanel;

    private string wordToGuess;
    
    void Awake() {    
        instance = this;
    }

    void Start() {
        wordToGuess = WordCollection.GetGuessWord();
    }

    // Update is called once per frame
    void Update() {
        if(Input.anyKeyDown) {
            //Debug.Log("[GameManager] Update " +  Input.inputString);
            if(Input.inputString.Length > 0) {
                if(char.IsLetter(Input.inputString[0])) {
                    wordPanel.AddLetter(Input.inputString.ToUpper()[0]);
                }
            } 
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                wordPanel.RemoveLetter();
            } 
        }       
    }

    public void IsWordComplete(bool isComplete) {
        buttonSend.interactable = isComplete;
    }

    public void ButtonSendOnClick() {
        if(WordCollection.TestValidWord(wordPanel.GetWord())) {
            wordPanel.SetStatus(TestWord(wordPanel.GetWord(), wordToGuess));
        } else {
            notValidWordPanel.SetActive(true);
        }
    }

    private int[] TestWord(string candidateWord, string wordToGuess) {
        int[] status = new int[WordPanel.NUMBER_OF_LETTERS];

        return status;
    }
}
