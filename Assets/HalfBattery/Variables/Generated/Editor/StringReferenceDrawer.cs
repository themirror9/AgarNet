using UnityEditor;
using UnityEngine;


namespace HalfBattery.Variables
{
    [CustomPropertyDrawer(typeof(StringReference))] 
    public class StringReferenceDrawer: VariableReferenceDrawer<StringReference> {}
}