using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public static FirstPersonLook Instance { get; private set; }

    [SerializeField] private Transform character;
    [SerializeField] private float sensitivity = 2;

    public bool IsCursorLocked
    {
        get { return Cursor.lockState == CursorLockMode.Locked; }
        set
        {
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Instance = this;
    }

    private void toggleCursor()
    {
        IsCursorLocked = !IsCursorLocked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) toggleCursor();
        if (Input.GetMouseButtonUp(1)) toggleCursor();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensitivity;
            
            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation *= Quaternion.AngleAxis(-mouseDelta.y, Vector3.right);
            character.localRotation *= Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        }
    }
}
