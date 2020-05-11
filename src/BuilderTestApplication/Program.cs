using BuilderGetter;
using System;
using System.Threading.Tasks;

namespace BuilderTestApplication
{
    class Program
    {
        static SelectionBuilderFactory BuilderFactory;
        static async Task Main(string[] args)
        {
            var selectionBuilder = BuilderFactory.GetBuilder(123, 32154);
            var baseSel = await selectionBuilder.GetBaseSelection();
            var toyakaSelections = await selectionBuilder.ActiveOnly()
                                                         .AsToyakaBuilder()
                                                         .BaseOnly()
                                                         .GetToyakaSelectionAsync();

            var subimaruSelections = await selectionBuilder.AsSubimaruBuilder()
                                                           .GetSubimaruSelectionAsync();

            var subimaruUxSelections = await selectionBuilder.AsSubimaruUxBuilder()
                                                             .GetSubimaruUxAsync();

            Console.WriteLine("Hello World!");
        }
    }
}
