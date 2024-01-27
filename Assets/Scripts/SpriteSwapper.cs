using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwapper : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    private int _spriteNum = 0;

    private void Start()
    {
        SpriteChange();
    }

    void SpriteChange()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite != _sprites[_spriteNum])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[_spriteNum];
        }
    }

    public void SpriteNumChange()
    {
        _spriteNum++;
        SpriteChange();
    }
}
