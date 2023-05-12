using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class Gift : MonoBehaviour
{
    public float duration;

    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer image;
    private RectTransform _rectTransform;
    private int index = 0;
    private float timer = 0;

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        
        if ((timer += Time.deltaTime) >= (duration / sprites.Length))
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
        }
    }
}


