using HalfBattery.Events;
using UnityEngine;

public class AgarBody : MonoBehaviour
{    
    public FloatEvent OnSizeChange;
    public ColorEvent OnColorChange; 
    
    [SerializeField]
    private float size = 1f;
    [SerializeField]
    private Color color = Color.white;    

    public float Size
    {
        get { return size; }

        set
        {
            if (size != value)
            {
                size = value;
                OnSizeChange.Invoke(size);
            }
        }
    }

    public Color Color
    {
        get { return color; }

        set
        {
            if (color != value)
            {
                color = value;
                OnColorChange.Invoke(color);
            }
        }
    }
    
}
