using UnityEditor;
using UnityEngine;


namespace HalfBattery.Variables
{
    [CustomPropertyDrawer(typeof(Vector3Reference))] 
    public class Vector3ReferenceDrawer: VariableReferenceDrawer<Vector3Reference> {}
}