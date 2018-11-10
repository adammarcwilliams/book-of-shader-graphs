using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Back Out")]
public class BackOutNode : CodeFunctionNode
{

    public BackOutNode()
    {
        name = "Back Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("BackOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string BackOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    float f = (1.0 - T);
	Out = 1.0 - (f * f * f - f * sin(f * PI));
}
";
    }
}
