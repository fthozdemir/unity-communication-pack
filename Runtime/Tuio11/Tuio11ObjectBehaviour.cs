using System;
using TuioNet.Tuio11;
using TuioUnity.Common;
using UnityEngine;

namespace TuioUnity.Tuio11
{
    public class Tuio11ObjectBehaviour : TuioObjectBehaviour
    {
        public Tuio11Object TuioObject { get; private set; }

        private Transform _transform;

        public override uint SessionId { get; protected set; }
        public override event Action OnUpdate;
        public override Vector2 ObjectPosition { get; protected set; }
        public override float Angle { get; protected set; }


        public void Initialize(Tuio11Object tuio11Object)
        {
            _transform = transform;
            TuioObject = tuio11Object;
            SessionId = TuioObject.SessionId;
            Id = TuioObject.SymbolId;
            TuioObject.OnUpdate += UpdateObject;
            TuioObject.OnRemove += RemoveObject;
            UpdateObject();
        }

        private void OnDestroy()
        {
            TuioObject.OnUpdate -= UpdateObject;
            TuioObject.OnRemove -= RemoveObject;
        }

        private void UpdateObject()
        {

            ObjectPosition = new Vector2(TuioObject.Position.X, TuioObject.Position.Y);
            Angle = -Mathf.Rad2Deg * TuioObject.Angle;

            _transform.position = Tuio11Manager.Instance.GetScreenPosition(ObjectPosition);
            _transform.rotation = Quaternion.Euler(0, 0, Angle);
            OnUpdate?.Invoke();

        }

        private void RemoveObject()
        {
            Destroy(gameObject);
        }

    }
}