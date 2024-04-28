using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Brush : MonoBehaviour
{
    public InputActionProperty buttonPressAction;
    public Material drawMaterial;

    private bool isDrawing;
    private LineRenderer curDrawing;

    private const float drawThreshold = 0.01f;
    private const float drawWidth = 0.01f;

    void Start()
    {
        isDrawing = false;
    }

    void Update()
    {
        if (!isDrawing && buttonPressAction.action.ReadValue<float>() > 0 ||
            isDrawing && buttonPressAction.action.ReadValue<float>() == 0)
        {
            isDrawing = !isDrawing;
        }

        if (isDrawing)
        {
            Draw();
        } else if (curDrawing != null)
        {
            curDrawing = null;
        }
    }

    void Draw()
    {
        if (curDrawing == null)
        {
            curDrawing = new GameObject().AddComponent<LineRenderer>();
            curDrawing.material = drawMaterial;
            curDrawing.startColor = drawMaterial.color;
            curDrawing.endColor = drawMaterial.color;
            curDrawing.startWidth = drawWidth;
            curDrawing.endWidth = drawWidth;
            curDrawing.positionCount = 1;
            curDrawing.SetPosition(0, transform.position);
        } else
        {
            Vector3 curPosition = curDrawing.GetPosition(curDrawing.positionCount - 1);
            if (Vector3.Distance(curPosition, transform.position) > drawThreshold)
            {
                curDrawing.positionCount++;
                curDrawing.SetPosition(curDrawing.positionCount - 1, transform.position);
            }
        }
    }
}
