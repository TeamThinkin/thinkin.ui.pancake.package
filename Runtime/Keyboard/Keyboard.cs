using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour, IKeyboard
{
    private struct KeyMap
    {
        public KeyCode Code;
        public char Character;
        public char? UpperCharacter;
    }

    public event Action<char> OnCharacterKeyPressed;
    public event Action<KeyCode> OnCommandKeyPressed;

    #region -- Key Map --
    private KeyCode[] commandKeys = new[]
    {
        KeyCode.Backspace,
        KeyCode.Delete,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.Insert,
        KeyCode.Home,
        KeyCode.End,
        KeyCode.PageUp,
        KeyCode.PageDown,
        KeyCode.Return,
        KeyCode.KeypadEnter
    };

    private KeyMap[] keyMap = new[]
    {
        new KeyMap() { Code = KeyCode.A, Character = 'a' },
        new KeyMap() { Code = KeyCode.B, Character = 'b' },
        new KeyMap() { Code = KeyCode.C, Character = 'c' },
        new KeyMap() { Code = KeyCode.D, Character = 'd' },
        new KeyMap() { Code = KeyCode.E, Character = 'e' },
        new KeyMap() { Code = KeyCode.F, Character = 'f' },
        new KeyMap() { Code = KeyCode.G, Character = 'g' },
        new KeyMap() { Code = KeyCode.H, Character = 'h' },
        new KeyMap() { Code = KeyCode.I, Character = 'i' },
        new KeyMap() { Code = KeyCode.J, Character = 'j' },
        new KeyMap() { Code = KeyCode.K, Character = 'k' },
        new KeyMap() { Code = KeyCode.L, Character = 'l' },
        new KeyMap() { Code = KeyCode.M, Character = 'm' },
        new KeyMap() { Code = KeyCode.N, Character = 'n' },
        new KeyMap() { Code = KeyCode.O, Character = 'o' },
        new KeyMap() { Code = KeyCode.P, Character = 'p' },
        new KeyMap() { Code = KeyCode.Q, Character = 'q' },
        new KeyMap() { Code = KeyCode.R, Character = 'r' },
        new KeyMap() { Code = KeyCode.S, Character = 's' },
        new KeyMap() { Code = KeyCode.T, Character = 't' },
        new KeyMap() { Code = KeyCode.U, Character = 'u' },
        new KeyMap() { Code = KeyCode.V, Character = 'v' },
        new KeyMap() { Code = KeyCode.W, Character = 'w' },
        new KeyMap() { Code = KeyCode.X, Character = 'x' },
        new KeyMap() { Code = KeyCode.Y, Character = 'y' },
        new KeyMap() { Code = KeyCode.Z, Character = 'z' },
        new KeyMap() { Code = KeyCode.Space, Character = ' ' },
        new KeyMap() { Code = KeyCode.BackQuote, Character = '`', UpperCharacter = '~' },
        new KeyMap() { Code = KeyCode.Alpha1, Character = '1', UpperCharacter = '!' },
        new KeyMap() { Code = KeyCode.Alpha2, Character = '2', UpperCharacter = '@' },
        new KeyMap() { Code = KeyCode.Alpha3, Character = '3', UpperCharacter = '#' },
        new KeyMap() { Code = KeyCode.Alpha4, Character = '4', UpperCharacter = '$' },
        new KeyMap() { Code = KeyCode.Alpha5, Character = '5', UpperCharacter = '%' },
        new KeyMap() { Code = KeyCode.Alpha6, Character = '6', UpperCharacter = '^' },
        new KeyMap() { Code = KeyCode.Alpha7, Character = '7', UpperCharacter = '&' },
        new KeyMap() { Code = KeyCode.Alpha8, Character = '8', UpperCharacter = '*' },
        new KeyMap() { Code = KeyCode.Alpha9, Character = '9', UpperCharacter = '(' },
        new KeyMap() { Code = KeyCode.Alpha0, Character = '0', UpperCharacter = ')' },
        new KeyMap() { Code = KeyCode.Minus, Character = '-', UpperCharacter = '_' },
        new KeyMap() { Code = KeyCode.Equals, Character = '=', UpperCharacter = '+' },
        new KeyMap() { Code = KeyCode.LeftBracket, Character = '[', UpperCharacter = '{' },
        new KeyMap() { Code = KeyCode.RightBracket, Character = ']', UpperCharacter = '}' },
        new KeyMap() { Code = KeyCode.Backslash, Character = '\\', UpperCharacter = '|' },
        new KeyMap() { Code = KeyCode.Semicolon, Character = ';', UpperCharacter = ':' },
        new KeyMap() { Code = KeyCode.Quote, Character = '\'', UpperCharacter = '"' },
        new KeyMap() { Code = KeyCode.Comma, Character = ',', UpperCharacter = '<' },
        new KeyMap() { Code = KeyCode.Period, Character = '.', UpperCharacter = '>' },
        new KeyMap() { Code = KeyCode.Slash, Character = '/', UpperCharacter = '?' },
        new KeyMap() { Code = KeyCode.Keypad0, Character = '0' },
        new KeyMap() { Code = KeyCode.Keypad1, Character = '1' },
        new KeyMap() { Code = KeyCode.Keypad2, Character = '2' },
        new KeyMap() { Code = KeyCode.Keypad3, Character = '3' },
        new KeyMap() { Code = KeyCode.Keypad4, Character = '4' },
        new KeyMap() { Code = KeyCode.Keypad5, Character = '5' },
        new KeyMap() { Code = KeyCode.Keypad6, Character = '6' },
        new KeyMap() { Code = KeyCode.Keypad7, Character = '7' },
        new KeyMap() { Code = KeyCode.Keypad8, Character = '8' },
        new KeyMap() { Code = KeyCode.Keypad9, Character = '9' },
        new KeyMap() { Code = KeyCode.KeypadPeriod, Character = '.' },
        new KeyMap() { Code = KeyCode.KeypadDivide, Character = '/' },
        new KeyMap() { Code = KeyCode.KeypadMultiply, Character = '*' },
        new KeyMap() { Code = KeyCode.KeypadMinus, Character = '-' },
        new KeyMap() { Code = KeyCode.KeypadPlus, Character = '+' },
    };
    #endregion

    public void Close()
    {
    }

    public void SetInput(IFocusItem Item)
    {
        FocusManager.SetFocus(Item);
    }

    private void Update()
    {
        foreach(var item in keyMap)
        {
            if(Input.GetKeyDown(item.Code))
            {
                if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    OnCharacterKeyPressed?.Invoke(item.UpperCharacter.HasValue ? item.UpperCharacter.Value : char.ToUpper(item.Character));
                else
                    OnCharacterKeyPressed?.Invoke(item.Character);
            }
        }

        foreach(var code in commandKeys)
        {
            if (Input.GetKeyDown(code)) OnCommandKeyPressed?.Invoke(code);
        }
    }
}
