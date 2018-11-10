using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quadractic In Out")]
public class QuadracticInOutNode : CodeFunctionNode
{

    public QuadracticInOutNode()
    {
        name = "Quadractic In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuadracticInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuadracticInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 0.5)
	{
		Out = 2 * T * T;
	}
	else
	{
		Out = (-2 * T * T) + (4 * T) - 1;
	}
}
";
    }
}
