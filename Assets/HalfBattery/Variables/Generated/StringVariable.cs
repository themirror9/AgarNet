using UnityEngine;
using System;


namespace HalfBattery.Variables
{
	[CreateAssetMenu(menuName = "HalfBattery/Variables/String")]
    public class StringVariable: ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string description = "";
#endif

        [SerializeField]
        private string value;

        public string Value
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

        public static implicit operator string(StringVariable variable)
        {
            return variable.Value;
        }
    }

    [Serializable]
    public class StringReference
    {
        public bool useConstant = true;
        public string constantValue;

        public StringVariable variable;

        public StringReference() { }

        public StringReference(string value)
        {
            useConstant = true;
            constantValue = value;
        }

        public string Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}