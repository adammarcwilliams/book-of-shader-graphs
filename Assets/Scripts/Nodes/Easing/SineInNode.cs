using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Sine In")]
public class SineInNode : CodeFunctionNode
{

    public SineInNode()
    {
        name = "Sine In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("SineIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string SineIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = sin((T - 1.0) * HALF_PI) + 1.0;
}
";
    }
}
