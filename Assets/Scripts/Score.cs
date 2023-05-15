using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Score : MonoBehaviour
{
    private float score = 0f;

    public TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = score + Time.deltaTime;
             _text.text = score.ToString("0");
    }
}
