using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Cubic In")]
public class CubicInNode : CodeFunctionNode
{

    public CubicInNode()
    {
        name = "Cubic In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("CubicIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string CubicIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = T * T * T;
}
";
    }
}
