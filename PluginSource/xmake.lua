add_rules("mode.debug", "mode.release")

set_targetdir("$(buildir)/out") 

-- cimgui
target("cimgui")
    set_kind("static")
    add_files("cimgui/*.cpp","cimgui/imgui/*.cpp")
    set_languages("c++17", "c99")

-- UnityImGuiRenderer
target("UnityImGuiRenderer")
    add_deps("cimgui")

    set_kind("shared")
    add_files("source/*.cpp","source/gl3w/*.c")
    add_links("cimgui")
    add_links("opengl32")
    add_links("source/lib/d3dcompiler")

    add_includedirs("cimgui","cimgui/imgui") 
    add_defines("CIMGUI_DEFINE_ENUMS_AND_STRUCTS=")
    set_languages("c++17", "c99")