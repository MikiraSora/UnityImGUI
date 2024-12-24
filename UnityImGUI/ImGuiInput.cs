using ImGuiNET;
using UnityEngine;

class ImGuiInput
{
    public void Update()
    {
        ImGuiIOPtr io = ImGui.GetIO();
        UpdateMouse(io);
        UpdateKeyboard(io);
    }

    public void UpdateMouse(ImGuiIOPtr io)
    {
        io.AddMousePosEvent(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        io.AddMouseButtonEvent(0, Input.GetMouseButton(0));
        io.AddMouseButtonEvent(1, Input.GetMouseButton(1));
        io.AddMouseButtonEvent(2, Input.GetMouseButton(2));
        io.AddMouseWheelEvent(Input.mouseScrollDelta.x, Input.mouseScrollDelta.y);
    }

    public void UpdateKeyboard(ImGuiIOPtr io)
    {
        io.AddInputCharactersUTF8(Input.inputString);

        io.KeyCtrl = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        io.KeyAlt = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
        io.KeyShift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        io.KeySuper = Input.GetKey(KeyCode.LeftWindows) || Input.GetKey(KeyCode.RightWindows)
                    || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
    }
}
