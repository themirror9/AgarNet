using UnityEngine;
using System;


namespace HalfBattery.Variables
{
	[CreateAssetMenu(menuName = "HalfBattery/Variables/Quaternion")]
    public class QuaternionVariable: ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string description = "";
#endif

        [SerializeField]
        private Quaternion value;

        public Quaternion Value
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

        public static implicit operator Quaternion(QuaternionVariable variable)
        {
            return variable.Value;
        }
    }

    [Serializable]
    public class QuaternionReference
    {
        public bool useConstant = true;
        public Quaternion constantValue;

        public QuaternionVariable variable;

        public QuaternionReference() { }

        public QuaternionReference(Quaternion value)
        {
            useConstant = true;
            constantValue = value;
        }

        public Quaternion Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator Quaternion(QuaternionReference reference)
        {
            return reference.Value;
        }
    }
}