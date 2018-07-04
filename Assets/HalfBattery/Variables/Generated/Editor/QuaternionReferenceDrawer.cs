using UnityEditor;
using UnityEngine;


namespace HalfBattery.Variables
{
    [CustomPropertyDrawer(typeof(QuaternionReference))] 
    public class QuaternionReferenceDrawer: VariableReferenceDrawer<QuaternionReference> {}
}