using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

Console.WriteLine("test");
var results = BenchmarkRunner.Run<Demo>();

 
 

[MemoryDiagnoser]
public class Demo
{
    [Benchmark]
    public string GetFull()
    {
        var dapperQuery = await _productRepository.ExecuteAsync("Select * from Products");


        var efQuery = await _productRepository.GetListAsync();

        return output;
    }
}