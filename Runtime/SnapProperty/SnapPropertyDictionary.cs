using System;
using System.Collections.Generic;

namespace TanitakaTech.VisualStateSnap.SnapProperty
{
    [Serializable]
    public class SnapPropertyDictionary
    {
        private Dictionary<(ISnapTargetReference, Type), ISnapProperty> _snapPropertyDictionary = new ();
        
        public bool TryGetValue(ISnapTargetReference snapTargetReference, Type snapPropertyType, out ISnapProperty snapProperty)
        {
            _snapPropertyDictionary.TryGetValue((snapTargetReference, snapPropertyType), out snapProperty);
            return snapProperty != null;
        }

        public void Add(ISnapTargetReference snapTargetReference, Type snapPropertyType, ISnapProperty snapProperty)
        {
            _snapPropertyDictionary.Add((snapTargetReference, snapPropertyType), snapProperty);
        }
    }
}