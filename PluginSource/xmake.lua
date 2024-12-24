add_rules("mode.debug", "mode.release")

set_targetdir("$(buildir)/out") 
set_languages("c++17", "c99")

-- cimgui
target("cimgui")
    set_kind("static")
    add_files("cimgui/*.cpp","cimgui/imgui/*.cpp")

-- cimplot
target("cimplot")
    add_deps("cimgui")
    
    set_kind("shared")
    add_files("cimplot/*.cpp","cimplot/implot/*.cpp")
    add_links("cimgui")
    
    add_includedirs("cimgui","cimgui/imgui") 

-- UnityImGuiRenderer
target("UnityImGuiRenderer")
    add_deps("cimgui","cimplot")

    set_kind("shared")
    add_files("source/*.cpp","source/gl3w/*.c")
    add_links("cimgui", "cimplot", "opengl32", "source/lib/d3dcompiler")
    add_defines("CIMGUI_DEFINE_ENUMS_AND_STRUCTS=")

    add_includedirs("cimgui","cimgui/imgui","cimplot","cimplot/implot")