using UnityEditor;
using UnityEngine;


namespace HalfBattery.Variables
{
    [CustomPropertyDrawer(typeof(Vector2Reference))] 
    public class Vector2ReferenceDrawer: VariableReferenceDrawer<Vector2Reference> {}
}