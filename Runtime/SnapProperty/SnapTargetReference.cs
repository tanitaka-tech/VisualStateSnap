using System;
using UnityEngine;

namespace TanitakaTech.VisualStateSnap.SnapProperty
{
    [Serializable]
    public abstract class SnapTargetReference<T, T2> : ISnapTargetReference where T2 : class, ISnapProperty
    {
        [SerializeField] protected T _snapTargetReference;

        ISnapProperty ISnapTargetReference.GetSnapProperty(SnapPropertyDictionary snapPropertyDictionary)
        {
            var type = typeof(T2);
            if (snapPropertyDictionary.TryGetValue(this, type, out var snapProperty))
            {
                return snapProperty;
            }
            snapProperty = CreateSnapProperty();
            snapPropertyDictionary.Add(this, type, snapProperty);
            snapProperty.SnapCurrentValue();
            return snapProperty;
        }
        protected abstract T2 CreateSnapProperty();
    }
}