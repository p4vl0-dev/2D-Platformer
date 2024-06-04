using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayGif : MonoBehaviour, IComparer<Sprite>
{
    [SerializeField] private  Sprite[] _gifFrames;
    [SerializeField] private float _framesPerSecond;
    [SerializeField] private SpriteAtlas _spriteAtlas;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        GetSpritesFromAtlas(_spriteAtlas);
    }
    
    void Update()
    {
        PlayGifAnimation();
    }

    private void PlayGifAnimation()
    {
        if(_gifFrames == null) throw new System.Exception("Array of sprites is empty");
        
        float index = Time.time * _framesPerSecond;
        index %= _gifFrames.Length;
        
        image.sprite = _gifFrames[(int)index];
    }

    private void GetSpritesFromAtlas(SpriteAtlas _spriteAtlas)
    {
        if(_spriteAtlas == null) return;

        _gifFrames = new Sprite[_spriteAtlas.spriteCount];

        _spriteAtlas.GetSprites(_gifFrames);

        Array.Sort(_gifFrames, new PlayGif());
    }

    public int Compare(Sprite x, Sprite y)
    {
        return x.name.CompareTo(y.name);
    }
}
