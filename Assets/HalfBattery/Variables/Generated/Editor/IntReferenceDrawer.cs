using UnityEditor;
using UnityEngine;


namespace HalfBattery.Variables
{
    [CustomPropertyDrawer(typeof(IntReference))] 
    public class IntReferenceDrawer: VariableReferenceDrawer<IntReference> {}
}