using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quartic In")]
public class QuarticInNode : CodeFunctionNode
{

    public QuarticInNode()
    {
        name = "Quartic In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuarticIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuarticIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = T * T * T * T;
}
";
    }
}
