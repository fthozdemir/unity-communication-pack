using System;
using UnityEngine;

namespace TuioUnity.Common
{
    public abstract class TuioObjectBehaviour : TuioBehaviour
    {
        public abstract Vector2 ObjectPosition { get; protected set; }
        public abstract float Angle { get; protected set; }
    }
}