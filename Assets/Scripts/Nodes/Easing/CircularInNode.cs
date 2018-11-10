using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Circular In")]
public class CircularInNode : CodeFunctionNode
{

    public CircularInNode()
    {
        name = "Circular In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("CircularIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string CircularIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = 1.0 - sqrt(1.0 - (T * T));
}
";
    }
}
