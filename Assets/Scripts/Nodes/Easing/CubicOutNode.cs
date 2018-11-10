using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Cubic Out")]
public class CubicOutNode : CodeFunctionNode
{

    public CubicOutNode()
    {
        name = "Cubic Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("CubicOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string CubicOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = pow(T - 1.0, 3.0) + 1;
}
";
    }
}
