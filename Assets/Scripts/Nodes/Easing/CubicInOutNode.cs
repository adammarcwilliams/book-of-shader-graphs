using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Cubic In Out")]
public class CubicInOutNode : CodeFunctionNode
{

    public CubicInOutNode()
    {
        name = "Cubic In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("CubicInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string CubicInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 0.5)
	{
		Out = 4 * T * T * T;
	}
	else
	{
		float f = ((2 * T) - 2);
		Out = 0.5 * f * f * f + 1;
	}
}
";
    }
}
