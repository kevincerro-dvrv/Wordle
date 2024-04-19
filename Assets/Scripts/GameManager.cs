using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WordPanel wordPanel;

    public static GameManager instance;

    public bool canSubmit = false;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            wordPanel.RemoveLetter();

            return;
        }

        if (Input.GetKeyDown(KeyCode.Return) && canSubmit) {
            if (WordCollection.TestValidWord(wordPanel.GetWord())) {
                Debug.Log("Acertaste");
            }

            return;
        }

        if (Input.anyKeyDown && Input.inputString.Length > 0) {
            char letter = Input.inputString.ToUpper()[0];
            if (char.IsLetter(letter)) {
                wordPanel.AddLetter(Input.inputString.ToUpper()[0]);
            }
        }
    }
}
