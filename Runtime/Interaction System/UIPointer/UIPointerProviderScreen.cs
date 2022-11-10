using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pancake screen provider class for the UI Pointer
/// </summary>
public class UIPointerProviderScreen : MonoBehaviour, IUIPointerProvider
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject Reticle;

    public event Action PrimaryButtonStart;
    public event Action PrimaryButtonEnd;
    public event Action SecondaryButtonStart;
    public event Action SecondaryButtonEnd;

    private Ray ray = new Ray();

    public Ray GetRay()
    {
        if (FirstPersonLook.Instance.IsCursorLocked)
        {
            ray.origin = MainCamera.transform.position;
            ray.direction = MainCamera.transform.forward;
            return ray;
        }
        else return MainCamera.ScreenPointToRay(Input.mousePosition);
    }

    private void Awake()
    {
        GetComponent<IUIPointer>().SetProvider(this);
    }

    private void Update()
    {
        GetRay().Draw(Color.red);
        if (Input.GetMouseButtonDown(0)) PrimaryButtonStart?.Invoke();
        if (Input.GetMouseButtonUp(0)) PrimaryButtonEnd?.Invoke();
        if (Input.GetMouseButtonDown(1)) SecondaryButtonStart?.Invoke();
        if (Input.GetMouseButtonUp(1)) SecondaryButtonEnd?.Invoke();

        Reticle.SetActive(FirstPersonLook.Instance.IsCursorLocked);
    }
}
