using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterPanel : MonoBehaviour {
    public TextMeshProUGUI letterField;
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
}
