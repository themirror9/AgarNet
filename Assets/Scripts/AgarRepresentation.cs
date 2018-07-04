using UnityEngine;

public class AgarRepresentation : MonoBehaviour
{
    private Renderer rend;
    private AgarBody agar;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        agar = GetComponent<AgarBody>();

        agar.OnColorChange.AddListener(SetColor);
        agar.OnSizeChange.AddListener(SetSize);
    }

    private void Start()
    {
        SetColor(agar.Color);
        SetSize(agar.Size);
    }

    private void SetColor(Color color)
    {
        rend.material.color = color;
    }

    private void SetSize(float size)
    {
        transform.localScale = new Vector3(size, size, 1);
    }

    private void OnDestroy()
    {
        agar.OnColorChange.RemoveListener(SetColor);
        agar.OnSizeChange.RemoveListener(SetSize);
    }


}
