using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Camera _mainCam;

    private VisualElement[] _cards = new VisualElement[5];

    private void Awake()
    {
        _mainCam = Camera.main;
        _uiDocument = GetComponent<UIDocument>();

        var root = _uiDocument.rootVisualElement;

        for (int i = 0; i < _cards.Length; ++i)
        {
            _cards[i] = root.Q($"card{i + 1}");
        }

        for (int i = 0; i < _cards.Length; ++i)
        {
            _cards[i].RegisterCallback<MouseEnterEvent>(OnMouseEnterCard);
        }
        
        for (int i = 0; i < _cards.Length; ++i)
        {
            _cards[i].RegisterCallback<MouseOutEvent>(OnMouseOutCard);
        }
    }

    private void OnMouseEnterCard(MouseEnterEvent evt)
    {
        var card = (VisualElement)evt.currentTarget;
        card.AddToClassList("card-pick");
    }
    
    private void OnMouseOutCard(MouseOutEvent evt)
    {
        var card = (VisualElement)evt.currentTarget;
        card.RemoveFromClassList("card-pick");
    }
    
}
