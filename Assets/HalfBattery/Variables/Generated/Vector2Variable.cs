using UnityEngine;
using System;


namespace HalfBattery.Variables
{
	[CreateAssetMenu(menuName = "HalfBattery/Variables/Vector2")]
    public class Vector2Variable: ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string description = "";
#endif

        [SerializeField]
        private Vector2 value;

        public Vector2 Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public static implicit operator Vector2(Vector2Variable variable)
        {
            return variable.Value;
        }
    }

    [Serializable]
    public class Vector2Reference
    {
        public bool useConstant = true;
        public Vector2 constantValue;

        public Vector2Variable variable;

        public Vector2Reference() { }

        public Vector2Reference(Vector2 value)
        {
            useConstant = true;
            constantValue = value;
        }

        public Vector2 Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator Vector2(Vector2Reference reference)
        {
            return reference.Value;
        }
    }
}