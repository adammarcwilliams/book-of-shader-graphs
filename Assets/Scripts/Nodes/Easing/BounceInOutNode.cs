using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Bounce In Out")]
public class BounceInOutNode : CodeFunctionNode
{

    public BounceInOutNode()
    {
        name = "Bounce In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("BounceInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string BounceInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 0.5)
	{
		Out = 0.5 * bounceIn(T * 2.0);
	}
	else
	{
		Out = 0.5 * bounceOut(T * 2.0 - 1.0) + 0.5;
    }
}
";
    }

    public override void GenerateNodeFunction(FunctionRegistry registry, GraphContext graphContext, GenerationMode generationMode)
    {
        registry.ProvideFunction("bounceOut", s => s.Append(@"
inline float bounceOut(float p)
{
    if(p < 4.0/11.0)
	{
		return (121.0 * p * p)/16.0;
	}
	else if(p < 8.0/11.0)
	{
		return (363.0/40.0 * p * p) - (99.0/10.0 * p) + 17.0/5.0;
	}
	else if(p < 9.0/10.0)
	{
		return (4356.0/361.0 * p * p) - (35442.0/1805.0 * p) + 16061.0/1805.0;
	}
	else
	{
		return (54.0/5.0 * p * p) - (513.0/25.0 * p) + 268.0/25.0;
    }
}"));
        registry.ProvideFunction("bounceIn", s => s.Append(@"
inline float bounceIn(float p)
{
    return 1.0 - bounceOut(1.0 - p);
}"));

        base.GenerateNodeFunction(registry, graphContext, generationMode);
    }
}
