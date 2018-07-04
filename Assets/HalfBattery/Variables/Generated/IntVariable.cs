using UnityEngine;
using System;


namespace HalfBattery.Variables
{
	[CreateAssetMenu(menuName = "HalfBattery/Variables/Int")]
    public class IntVariable: ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string description = "";
#endif

        [SerializeField]
        private int value;

        public int Value
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

        public static implicit operator int(IntVariable variable)
        {
            return variable.Value;
        }
    }

    [Serializable]
    public class IntReference
    {
        public bool useConstant = true;
        public int constantValue;

        public IntVariable variable;

        public IntReference() { }

        public IntReference(int value)
        {
            useConstant = true;
            constantValue = value;
        }

        public int Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}