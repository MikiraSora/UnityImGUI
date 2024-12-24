using System;
using DpPatches.JudgementDisplayer;
using ImGuiNET;
using ImPlotNET;
using UnityEngine;

public class ImGuiController
{
    private ImGuiInput _input = new ImGuiInput();
    private bool _frameBegun;

    public ImGuiController()
    {
        var imguiCtx = ImGui.CreateContext();
        ImPlot.CreateContext();
        ImPlot.SetImGuiContext(imguiCtx);

        ImGui.GetIO().Fonts.AddFontDefault();
        RecreateFontDeviceTexture(true);

        SetPerFrameImGuiData(1.0f / 60.0f, Screen.width, Screen.height, new(1.0f, 1.0f));
    }

    ~ImGuiController()
    {
        ImGui.DestroyContext();
    }

    public void RecreateFontDeviceTexture(bool sendToGPU)
    {
        ImGuiIOPtr io = ImGui.GetIO();
        IntPtr pixels;
        int width, height, bytesPerPixel;
        io.Fonts.GetTexDataAsRGBA32(out pixels, out width, out height, out bytesPerPixel);

        if (sendToGPU)
        {
            IntPtr fontTexID = ImGuiPluginHook.GenerateImGuiFontTexture(pixels, width, height, bytesPerPixel);
            io.Fonts.SetTexID(fontTexID);
        }

        io.Fonts.ClearTexData();
    }

    public void SetPerFrameImGuiData(float deltaSeconds, int _windowWidth, int _windowHeight, ImGuiNET.FXCompatible.System.Numerics.Vector2 _scaleFactor)
    {
        ImGuiIOPtr io = ImGui.GetIO();
        io.DisplaySize = new(
            _windowWidth / _scaleFactor.X,
            _windowHeight / _scaleFactor.Y);
        io.DisplayFramebufferScale = _scaleFactor;
        io.DeltaTime = deltaSeconds; // DeltaTime is in seconds.
    }
    public void Render()
    {
        if (_frameBegun)
        {
            _frameBegun = false;

            ImGui.Render();
        }
    }

    public void Update()
    {
        Debug.Assert(ImGui.GetCurrentContext() != IntPtr.Zero);

        SetPerFrameImGuiData(Time.deltaTime, Screen.width, Screen.height, new(1.0f, 1.0f));
        _input.Update();

        _frameBegun = true;
        ImGui.NewFrame();
    }
}
