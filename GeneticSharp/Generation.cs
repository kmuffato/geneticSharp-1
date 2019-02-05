using System.Linq;
using GeneticSharp.Extensions;

namespace GeneticSharp
{
    public class Generation<T> where T : class, IEvolutionaryIndividual, new()
    {
        public int Number { get; }
        public Population<T> Population { get; }

        public Generation(int number, Population<T> population)
        {
            Number = number;
            Population = population;
        }


        internal static Generation<T> GenerateRandomly(EvolutionOptions options)
        {
            var builder = options.GenerateBuilder<T>();
            var individuals = Enumerable.Range(0, options.PopulationSize).Select(_ => builder.Build()).ToList();

            return new Generation<T>(1, new Population<T>(individuals));
        }
    }
}