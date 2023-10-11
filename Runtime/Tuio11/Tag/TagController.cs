using TuioNet.Common;
using TuioNet.Tuio11;
using UnityEngine;
using System.Collections.Generic;

namespace TuioUnity.Tuio11.Tag
{
    public class TagController : MonoBehaviour, ITuio11Listener
    {
        [SerializeField] List<Tuio11ObjectBehaviour> tagPrefabList;

        void Start()
        {
            Tuio11Manager.Instance.AddTuio11Listener(this);
        }

        public void AddTuioObject(Tuio11Object tuio11Object)
        {
            Debug.Log(tuio11Object.SymbolId + "added");
            foreach (Tuio11ObjectBehaviour tagElement in tagPrefabList)
            {
                if (tuio11Object.SymbolId == tagElement.Id)
                {
                    var tagBehaviour = Instantiate(tagElement, transform);
                    tagBehaviour.Initialize(tuio11Object);
                }
            }

        }

        public void UpdateTuioObject(Tuio11Object tuio11Object)
        {
        }

        public void RemoveTuioObject(Tuio11Object tuio11Object)
        {
        }

        public void AddTuioCursor(Tuio11Cursor tuio11Cursor)
        {
        }

        public void UpdateTuioCursor(Tuio11Cursor tuio11Cursor)
        {
        }

        public void RemoveTuioCursor(Tuio11Cursor tuio11Cursor)
        {

        }

        public void AddTuioBlob(Tuio11Blob tuio11Blob)
        {
        }

        public void UpdateTuioBlob(Tuio11Blob tuio11Blob)
        {
        }

        public void RemoveTuioBlob(Tuio11Blob tuio11Blob)
        {
        }

        public void Refresh(TuioTime tuioTime)
        {
        }
    }
}