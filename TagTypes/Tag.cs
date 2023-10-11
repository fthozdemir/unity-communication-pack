using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TuioUnity.Utils;
using TuioUnity.Common;
using UnityEngine.UI;

public abstract class Tag : MonoBehaviour
{
    [SerializeField] private TuioBehaviour _tuioBehaviour;
    [SerializeField] private Image _image;
    [SerializeField] private DebugText _debugTextPrefab;

    private DebugText _debugText;
  
    public virtual void Start()
    {
        Random.InitState((int)_tuioBehaviour.Id);
        var color = Random.ColorHSV(0f, 1f, 0.7f, 0.8f, 1f, 1f);
        _image.color = color;

        _debugText = Instantiate(_debugTextPrefab, transform.parent);
        _debugText.SetTextColor(color);
        _debugText.SetId(_tuioBehaviour.Id);
        _debugText.UpdateText(_tuioBehaviour);
        _tuioBehaviour.OnUpdate += UpdateText;
        _tuioBehaviour.OnUpdate += () => UpdateValue(_tuioBehaviour); // Use a lambda to pass the parameter.

    }

    public virtual void OnDestroy()
    {
        _tuioBehaviour.OnUpdate -= UpdateText;
        _tuioBehaviour.OnUpdate -= () => UpdateValue(_tuioBehaviour); 
        Destroy(_debugText.gameObject);
    }

    public virtual void UpdateText()
    {
        _debugText.UpdateText(_tuioBehaviour);
    }

    public abstract void UpdateValue(TuioBehaviour tuioBehaviour);

}
