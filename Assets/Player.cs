using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    public float JumpForce = 10f;
    public Rigidbody2D MyRigidbody;
    public SpriteRenderer SpriteRenderer;

    private Color _currentColor;
    private Color[] _colors;
    private Color _blue, _yellow, _pink, _purple;

    private Dictionary<string, Color> colorNames;

    void Start()
    {
        ColorUtility.TryParseHtmlString("#35E2F2", out _blue);
        ColorUtility.TryParseHtmlString("#F6DF0E", out _yellow);
        ColorUtility.TryParseHtmlString("#35E2F2", out _pink);
        ColorUtility.TryParseHtmlString("#FF0080", out _purple);

        colorNames = new Dictionary<string, Color>()
        {
            { "Blue", _blue},
            { "Yellow", _yellow},
            { "Pink", _pink},
            { "Purple", _purple},
        };

        _colors = new[] {_blue, _yellow, _pink, _purple};
        SetRandomColor();
    }

    void Update()
    {
        if (Input.GetButton("Jump") || Input.GetMouseButtonDown(0))
        {
            MyRigidbody.velocity = Vector2.up * JumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (String.Equals(collisionObject.tag, "ColorChanger"))
        {
            SetRandomColor();
            Destroy(collisionObject);
            return;
        }

        if (colorNames[collisionObject.tag] == _currentColor)
        {
            Debug.Log("HIT");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void SetRandomColor()
    {
        var index = Random.Range(0, _colors.Length);

        if(_currentColor == _colors[index])
            SetRandomColor();

        _currentColor = _colors[index];
        SpriteRenderer.color = _currentColor;
    }
}
