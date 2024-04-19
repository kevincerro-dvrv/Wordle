using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterPanel : MonoBehaviour
{
    public TextMeshProUGUI letterField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetSize()
    {
        return new Vector2(80f, 80f);
    }

    public string GetLetter()
    {
        return letterField.text;
    }

    public void SetLetter(char letter)
    {
        letterField.SetText(letter.ToString());
    }

    public void RemoveLetter()
    {
        letterField.SetText("");
    }
}
