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
        Debug.Log("Word to guess: " + wordToGuess);
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

    private LetterStatus[] TestWord(string candidateWord, string wordToGuess) {
        LetterStatus[] status = new LetterStatus[WordPanel.NUMBER_OF_LETTERS];

        status[0] = TestCharacter(0, candidateWord[0], wordToGuess);
        status[1] = TestCharacter(1, candidateWord[1], wordToGuess);
        status[2] = TestCharacter(2, candidateWord[2], wordToGuess);
        status[3] = TestCharacter(3, candidateWord[3], wordToGuess);
        status[4] = TestCharacter(4, candidateWord[4], wordToGuess);

        return status;
    }

    private LetterStatus TestCharacter(int index, char character, string wordToGuess) {
        if (wordToGuess[index] == character) {
            return LetterStatus.Green;
        }

        if (wordToGuess.Contains(character)) {
            return LetterStatus.Orange;
        }

        return LetterStatus.Gray;
    }
}
