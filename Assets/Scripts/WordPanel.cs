using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanel : MonoBehaviour {
    public GameObject letterPanelPrefab;

    public const int NUMBER_OF_LETTERS = 5;
    private int letterIndex;

    LetterPanel[] letters = new LetterPanel[NUMBER_OF_LETTERS];

    // Start is called before the first frame update
    void Start() {
        SpawnLetterPanels();
        letterIndex = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLetter(char letter) {
        if(letterIndex < NUMBER_OF_LETTERS) {
            letters[letterIndex].SetLetter(letter);
            letterIndex++;
        }
        GameManager.instance.IsWordComplete(letterIndex == NUMBER_OF_LETTERS);
    }

    public void RemoveLetter() {
        if(letterIndex > 0) {
            letters[--letterIndex].RemoveLetter();
        }
        GameManager.instance.IsWordComplete(false);
    }

    private void SpawnLetterPanels() {
        for(int i=0; i<NUMBER_OF_LETTERS; i++) {
            GameObject letterPanelGO = Instantiate(letterPanelPrefab, transform);
            letters[i] = letterPanelGO.GetComponent<LetterPanel>();
            letterPanelGO.name = "LetterPanel" + i;

            RectTransform rectTransform = letterPanelGO.GetComponent<RectTransform>();

            float x = letters[i].GetSize().x * i + 10f*i + 10f;

            rectTransform.anchoredPosition = new Vector2(x, 0f);
        }        
    }

    public string GetWord() {
        string word = "";
        for(int i=0; i<letterIndex; i++) {
            word += letters[i].GetLetter();
        }
        return word;
    }

    public void SetStatus(int[] status) {
        
    }
}
