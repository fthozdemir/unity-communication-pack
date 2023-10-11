using System;
using UnityEngine;

namespace TuioUnity.Common
{
    public abstract class TuioBehaviour : MonoBehaviour
    {
        public abstract uint SessionId { get; protected set; }
        public uint Id; // Serialize the _id field so you can set it in the Unity Editor.
       
        public abstract event Action OnUpdate;
    }
}