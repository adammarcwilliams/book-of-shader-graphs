using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quartic In Out")]
public class QuarticInOutNode : CodeFunctionNode
{

    public QuarticInOutNode()
    {
        name = "Quartic In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuarticInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuarticInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 0.5)
	{
		Out = 8.0 * T * T * T * T;
	}
	else
	{
		float f = (T - 1.0);
		Out = -8.0 * f * f * f * f + 1.0;
	}
}
";
    }
}
