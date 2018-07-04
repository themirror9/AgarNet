using UnityEditor;
using UnityEngine;


namespace HalfBattery.Variables
{
    [CustomPropertyDrawer(typeof(FloatReference))] 
    public class FloatReferenceDrawer: VariableReferenceDrawer<FloatReference> {}
}