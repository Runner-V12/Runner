using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiflip : MonoBehaviour
{
    private SpriteRenderer _spriteR;
    private GameObject _Player;
    private Shader _shader;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _spriteR = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (_Player.transform.localScale.x < 0 && transform.parent.parent == _Player.transform)
        {
            _spriteR.flipX = true;
        }
        else {
            _spriteR.flipX = false;
        }
    }
}
