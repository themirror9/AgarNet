using UnityEngine;
using System;


namespace HalfBattery.Variables
{
	[CreateAssetMenu(menuName = "HalfBattery/Variables/Float")]
    public class FloatVariable: ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string description = "";
#endif

        [SerializeField]
        private float value;

        public float Value
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

        public static implicit operator float(FloatVariable variable)
        {
            return variable.Value;
        }
    }

    [Serializable]
    public class FloatReference
    {
        public bool useConstant = true;
        public float constantValue;

        public FloatVariable variable;

        public FloatReference() { }

        public FloatReference(float value)
        {
            useConstant = true;
            constantValue = value;
        }

        public float Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}