using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quadractic In")]
public class QuadracticInNode : CodeFunctionNode
{

    public QuadracticInNode()
    {
        name = "Quadractic In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuadracticIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuadracticIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = T * T;
}
";
    }
}
