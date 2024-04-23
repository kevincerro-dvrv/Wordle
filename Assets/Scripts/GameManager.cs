using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Button buttonSend;
    public GameObject notValidWordPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    public WordPanel wordPanel;
    public Transform wordPanelContainer;
    public GameObject wordPanelPrefab;
    private int tryNumber;

    private string wordToGuess;
    
    void Awake() {    
        instance = this;
    }

    void Start() {
        wordToGuess = WordCollection.GetGuessWord();
        tryNumber = 0;
    }

    // Update is called once per frame
    void Update() {
        if(wordPanel == null) {
            return;
        }

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
            LetterStatus[] status = TestWord(wordPanel.GetWord(), wordToGuess);
            wordPanel.SetStatus(status);
            buttonSend.interactable = false;
            if(IsVictory(status)) {
                //Mostrar Panel de victoria
                winPanel.SetActive(true);
            } else {
                if(tryNumber < 5) {
                   StartCoroutine(InstantiateNewPanel());
                } else {
                    //Mostrar panel de derrota
                    losePanel.SetActive(true);
                }
            }
        } else {
            notValidWordPanel.SetActive(true);
        }
    }

    private LetterStatus[] TestWord(string candidateWord, string wordToGuess) {
        LetterStatus[] status = new LetterStatus[WordPanel.NUMBER_OF_LETTERS];

        char[] wordToGuessChars = wordToGuess.ToUpper().ToCharArray();
        char[] candidateWordChars = candidateWord.ToUpper().ToCharArray();

        for(int i=0; i<WordPanel.NUMBER_OF_LETTERS; i++) {
            if(candidateWordChars[i] == wordToGuessChars[i]) {
                status[i] = LetterStatus.Green;
                wordToGuessChars[i] = '*';
                candidateWordChars[i] = '*';
            } else {
                status[i] = LetterStatus.Gray;
            }
        }

        for(int i=0; i<WordPanel.NUMBER_OF_LETTERS; i++) {
            if(candidateWordChars[i] != '*') {
                for(int j=0; j<WordPanel.NUMBER_OF_LETTERS; j++) {
                    if(candidateWordChars[i] == wordToGuessChars[j]) {
                        status[i] = LetterStatus.Orange;
                        wordToGuessChars[j] = '*';
                        candidateWordChars[i] = '*';
                        break;
                    }
                }
            }
        }

        return status;
    }

    private bool IsVictory(LetterStatus[] status) {
        for(int i=0; i<status.Length; i++) {
            if(status[i] != LetterStatus.Green) {
                return false;
            }
        }
        return true;
    }

    private IEnumerator InstantiateNewPanel() {
        wordPanel = null;
        tryNumber++;
        
        yield return new WaitForSeconds(2f);

        wordPanel = Instantiate(wordPanelPrefab, wordPanelContainer).GetComponent<WordPanel>();
        RectTransform rt = wordPanel.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0f, tryNumber * -100f);
    }
}
