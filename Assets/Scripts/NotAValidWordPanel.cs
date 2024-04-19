using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAValidWordPanel : MonoBehaviour {

    void OnEnable() {
        Invoke("Disable", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Disable() {
        gameObject.SetActive(false);
    }
}
