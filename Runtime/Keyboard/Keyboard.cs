using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour, IKeyboard
{
    //TODO: need to implement this
    public EditableText Text => throw new System.NotImplementedException();

    public IFocusItem CurrentFocusItem => throw new System.NotImplementedException();

    public void Close()
    {
        throw new System.NotImplementedException();
    }

    public void ShowForInput(IFocusItem Item)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
