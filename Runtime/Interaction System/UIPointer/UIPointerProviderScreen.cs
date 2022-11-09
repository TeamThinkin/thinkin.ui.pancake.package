using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPointerProviderScreen : MonoBehaviour, IUIPointerProvider
{
    [SerializeField] private Camera MainCamera;

    public event Action PrimaryButtonStart;
    public event Action PrimaryButtonEnd;
    public event Action SecondaryButtonStart;
    public event Action SecondaryButtonEnd;

    public Ray GetRay()
    {
        return MainCamera.ScreenPointToRay(Input.mousePosition);
    }

    private void drawRay(Ray ray, Color color)
    {
        Debug.DrawRay(ray.origin, ray.direction, color);
    }

    private void Awake()
    {
        GetComponent<IUIPointer>().SetProvider(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) PrimaryButtonStart?.Invoke();
        if (Input.GetMouseButtonUp(0)) PrimaryButtonEnd?.Invoke();
        if (Input.GetMouseButtonDown(1)) SecondaryButtonStart?.Invoke();
        if (Input.GetMouseButtonUp(1)) SecondaryButtonEnd?.Invoke();
    }
}
