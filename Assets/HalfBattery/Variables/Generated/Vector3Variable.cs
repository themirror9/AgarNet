using UnityEngine;
using System;


namespace HalfBattery.Variables
{
	[CreateAssetMenu(menuName = "HalfBattery/Variables/Vector3")]
    public class Vector3Variable: ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string description = "";
#endif

        [SerializeField]
        private Vector3 value;

        public Vector3 Value
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

        public static implicit operator Vector3(Vector3Variable variable)
        {
            return variable.Value;
        }
    }

    [Serializable]
    public class Vector3Reference
    {
        public bool useConstant = true;
        public Vector3 constantValue;

        public Vector3Variable variable;

        public Vector3Reference() { }

        public Vector3Reference(Vector3 value)
        {
            useConstant = true;
            constantValue = value;
        }

        public Vector3 Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}