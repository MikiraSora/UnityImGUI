using UnityEngine;
using ImGuiNET;
using ImPlotNET;

public class ImGuiDemoWindow : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = true;
    }

    public void Update()
    {
        var b = true;
        ImGui.ShowDemoWindow(ref b);
        ImPlot.ShowDemoWindow(ref b);

        if (ImGui.Begin("Hello, unity5.x and dear Imgui", ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoTitleBar))
        {
            ImGui.Text($"This is text: {Random.Range(0, 10000)}");
            ImGui.End();
        }
    }
}
