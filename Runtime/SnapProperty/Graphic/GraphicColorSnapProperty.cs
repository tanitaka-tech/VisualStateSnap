using System;
using UnityEngine;

namespace TanitakaTech.VisualStateSnap.SnapProperty.Graphic
{
    [Serializable]
    public class GraphicColorSnapProperty : SnapProperty<UnityEngine.UI.Graphic, Color>
    {
        public override string CustomName => "color";
        
        public GraphicColorSnapProperty(UnityEngine.UI.Graphic snapTargetReference) : base(snapTargetReference)
        {
        }

        protected override void ApplySnappedValue()
        {
            if (SnapTargetReference != null)
            {
                SnapTargetReference.color = SnappedValue;
            }
        }

        protected override Color GetCurrentValue()
        {
            return SnapTargetReference!?.color ?? Color.white;
        }
    }
    
    [Serializable]
    public class GraphicColorSnapTargetReference : SnapTargetReference<UnityEngine.UI.Graphic, GraphicColorSnapProperty>
    {
        protected override GraphicColorSnapProperty CreateSnapProperty() => new (_snapTargetReference);
    }
}