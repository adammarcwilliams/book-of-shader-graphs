using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Sine Out")]
public class SineOutNode : CodeFunctionNode {

    public SineOutNode()
    {
        name = "Sine Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("SineOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string SineOut(
        [Slot(0, Binding.None)] DynamicDimensionVector A,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = sin(A * 1.57079632f);
}
";
    }
}
