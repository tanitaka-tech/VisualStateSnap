using System;
using UnityEngine;

namespace TanitakaTech.VisualStateSnap.SnapProperty.Transform
{
    [Serializable]
    public class TransformPositionSnapProperty : SnapProperty<UnityEngine.Transform, Vector3>
    {
        public override string CustomName => "position";
        
        public TransformPositionSnapProperty(UnityEngine.Transform snapTargetReference) : base(snapTargetReference)
        {
        }

        protected override void ApplySnappedValue()
        {
            if (SnapTargetReference != null)
            {
                SnapTargetReference.position = SnappedValue;
            }
        }

        protected override Vector3 GetCurrentValue()
        {
            return SnapTargetReference!?.position ?? Vector3.zero;
        }
    }
    
    [Serializable]
    public class TransformPositionSnapTargetReference : SnapTargetReference<UnityEngine.Transform, TransformPositionSnapProperty>
    {
        protected override TransformPositionSnapProperty CreateSnapProperty() => new (_snapTargetReference);
    }
}