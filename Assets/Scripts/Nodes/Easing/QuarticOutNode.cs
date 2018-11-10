using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quartic Out")]
public class QuarticOutNode : CodeFunctionNode
{

    public QuarticOutNode()
    {
        name = "Quartic Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuarticOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuarticOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    float f = (T - 1.0);
	Out = f * f * f * (1.0 - T) + 1;
}
";
    }
}
