using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Back In")]
public class BackInNode : CodeFunctionNode
{

    public BackInNode()
    {
        name = "Back In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("BackIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string BackIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = T * T * T - T * sin(T * PI);
}
";
    }
}
