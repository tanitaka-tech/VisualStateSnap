using System;
using UnityEngine;
using TanitakaTech.VisualStateSnap.SnapProperty.ReadOnlyAttribute;

namespace TanitakaTech.VisualStateSnap.SnapProperty
{
    [Serializable]
    public abstract class SnapProperty<T, T2> : ISnapProperty
    {
        [SerializeField, ReadOnlyAttribute.ReadOnly] private string _name;
        [SerializeField, ReadOnlyAttribute.ReadOnly] private T _snapTargetReference;
        [SerializeField] private T2 _snappedValue;
        
        public T2 SnappedValue => _snappedValue;
        protected T SnapTargetReference => _snapTargetReference;
        public virtual string CustomName => GetType().Name;

        protected SnapProperty(T snapTargetReference)
        {
            _snapTargetReference = snapTargetReference;

            string gameObjectName = "";
            if (snapTargetReference is UnityEngine.Object gameObject)
            {
                gameObjectName = gameObject.name + '.';
            }

            _name = $"{gameObjectName}{snapTargetReference.GetType().Name} -> {CustomName}";
        }
        
        void ISnapProperty.SnapCurrentValue() => UpdateSnapValue();
        protected virtual void UpdateSnapValue()
        {
            _snappedValue = GetCurrentValue();
        }

        void ISnapProperty.ApplySnappedValue() => ApplySnappedValue();
        protected abstract void ApplySnappedValue();
        protected abstract T2 GetCurrentValue();
    }
    
    public abstract class SnapProperty<T> : SnapProperty<T, T>
    {
        protected SnapProperty(T snapTargetReference) : base(snapTargetReference)
        {
        }
    }
}