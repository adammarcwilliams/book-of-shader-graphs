using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Sine In Out")]
public class SineInOutNode : CodeFunctionNode
{

    public SineInOutNode()
    {
        name = "Sine In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("SineInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string SineInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = -0.5 * (cos(PI * T) - 1.0);
}
";
    }
}
