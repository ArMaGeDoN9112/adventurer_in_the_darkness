using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextPressed : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _yToChange;
    private GameObject _text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // _text.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        _text.transform.position = new Vector3(_text.transform.position.x, _text.transform.position.y - _yToChange, _text.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // _text.transform.localScale = new Vector3(1f, 1f, 1f);
        _text.transform.position = new Vector3(_text.transform.position.x, _text.transform.position.y + _yToChange, _text.transform.position.z);
    }

    private void Awake()
    {
        _text = transform.GetChild(0).gameObject;
    }
}
