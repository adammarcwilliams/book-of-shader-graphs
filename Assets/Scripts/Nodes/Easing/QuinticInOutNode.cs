using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quintic In Out")]
public class QuinticInOutNode : CodeFunctionNode
{

    public QuinticInOutNode()
    {
        name = "Quintic In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuinticInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuinticInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = t < 0.5
        ? +16.0 * pow(T, 5.0)
        : -0.5 * pow(2.0 * T - 2.0, 5.0) + 1.0;
}
";
    }
}
