using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TuioUnity.Utils;
using TuioUnity.Common;
using UnityEngine.UI;
using UnityEngine.Events;


namespace TuioUnity.Tuio11.Tag
{
    [RequireComponent(typeof(Tuio11ObjectBehaviour))]
    public class Tag : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private DebugText _debugTextPrefab;
        [SerializeField] private bool isDebugTextActive;

        public UnityEvent<Tag> OnStartEvents;
        public UnityEvent<Tag> OnUpdateEvents;
        public UnityEvent<Tag> OnRemoveEvents;

        private DebugText _debugText;
        TuioObjectBehaviour _tuioBehaviour;

        public virtual void Start()
        {
            _tuioBehaviour = GetComponent<TuioObjectBehaviour>();
            Random.InitState((int)_tuioBehaviour.Id);
            var color = Random.ColorHSV(0f, 1f, 0.7f, 0.8f, 1f, 1f);
            _image.color = color;
            if (isDebugTextActive)
            {
                _debugText = Instantiate(_debugTextPrefab, transform.parent);
                _debugText.SetTextColor(color);
                _debugText.SetId(_tuioBehaviour.Id);
                _debugText.UpdateText(_tuioBehaviour);
                _tuioBehaviour.OnUpdate += UpdateText;

            }
            _tuioBehaviour.OnUpdate += OnUpdate;
            OnStartEvents?.Invoke(this);
        }

        public void OnDestroy()
        {
            _tuioBehaviour.OnUpdate -= OnUpdate;

            if (isDebugTextActive)
            {
                _tuioBehaviour.OnUpdate -= UpdateText;
                Destroy(_debugText.gameObject);
            }

            OnRemoveEvents?.Invoke(this);

        }

        public void UpdateText()
        {
            if (!isDebugTextActive)
                return;
            _debugText.UpdateText(_tuioBehaviour);
        }

        public void OnUpdate()
        {
            OnUpdateEvents?.Invoke(this);
        }

        public Vector2 getPosition()
        {
            return _tuioBehaviour.ObjectPosition;
        }

        public float getAngle()
        {
            return _tuioBehaviour.Angle;
        }
        public uint getId()
        {
            return _tuioBehaviour.Id;
        }

    }
}