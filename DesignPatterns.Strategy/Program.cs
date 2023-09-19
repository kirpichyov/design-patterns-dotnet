// See https://aka.ms/new-console-template for more information

using Bogus;
using DesignPatterns.Strategy;
using DesignPatterns.Strategy.ConcreteStrategies;

var cpuLoad = 0.3f;
var gpuLoad = 0.1f;

var framesToRender = 20;
var pageRenderer = new PageRenderer();

for (var i = 0; i < framesToRender; i++)
{
    if (cpuLoad >= 0.6f)
    {
        if (gpuLoad >= 0.8)
        {
            pageRenderer.SetStrategy(new BalancedStrategy());
        }
        else
        {
            pageRenderer.SetStrategy(new GpuReliesStrategy());
        }
    }
    else
    {
        pageRenderer.SetStrategy(new CpuReliesStrategy());
    }
    
    pageRenderer.Render();
    MutateSystemResources();
}

void MutateSystemResources()
{
    var faker = new Faker();
    cpuLoad = faker.Random.Float(0.1f, 1f);
    gpuLoad = faker.Random.Float(0.1f, 1f);
}