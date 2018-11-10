using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quadractic Out")]
public class QuadracticOutNode : CodeFunctionNode
{

    public QuadracticOutNode()
    {
        name = "Quadractic Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuadracticOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuadracticOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = -(T * (T - 2.0));
}
";
    }
}
