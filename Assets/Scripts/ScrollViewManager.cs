using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollViewManager : MonoBehaviour
{
    public Scrollbar _Scrollbar;

    Coroutine _Coroutine;

    [SerializeField] float ScrollSpeed = 1.0f;

    public void ScrollLeft()
    {
        if (_Coroutine != null)
        {
            StopCoroutine(_Coroutine);
        }
        _Coroutine = StartCoroutine(TimeForScrollLeft());
    }

    IEnumerator TimeForScrollLeft(float SpeedRate = 1f)
    {
        while (_Scrollbar.value > 0)
        {
            _Scrollbar.value -= Time.deltaTime * ScrollSpeed * SpeedRate;
            yield return null;
        }
    }

    public void ScrollRight()
    {
        if (_Coroutine != null)
        {
            StopCoroutine(_Coroutine);
        }
        _Coroutine = StartCoroutine(TimeForScrollRight());

    }

    IEnumerator TimeForScrollRight(float SpeedRate = 1f)
    {
        while (_Scrollbar.value < 1)
        {
            _Scrollbar.value += Time.deltaTime * ScrollSpeed * SpeedRate;
            yield return null;
        }
    }

    public void StopScroll()
    {
        if (_Coroutine != null)
        {
            StopCoroutine(_Coroutine);
        }
    }
}
