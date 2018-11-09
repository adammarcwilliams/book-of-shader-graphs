using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quintic In")]
public class QuinticInNode : CodeFunctionNode
{

    public QuinticInNode()
    {
        name = "Quintic In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuinticIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuinticIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = pow(T, 5.0);
}
";
    }
}
