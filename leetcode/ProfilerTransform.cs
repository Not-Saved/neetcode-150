using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfilerTransform
{
    // Input from the sample profiler
    public sealed class Sample
    {
        public long Timestamp { get; }
        public IReadOnlyList<string> FunctionStack { get; }

        public Sample(long timestamp, IReadOnlyList<string> functionStack)
        {
            Timestamp = timestamp;
            FunctionStack = functionStack;
        }
    }

    // Output event
    public sealed class ProfilerEvent
    {
        public string Kind { get; } // "start" | "end"
        public long Timestamp { get; }
        public string FunctionName { get; }

        public ProfilerEvent(string kind, long timestamp, string functionName)
        {
            Kind = kind;
            Timestamp = timestamp;
            FunctionName = functionName;
        }

        public override string ToString()
            => $"{Timestamp}: {Kind} {FunctionName}";
    }

    // Class to implement
    public sealed class SampleToEventTransformer
    {
        public IReadOnlyList<ProfilerEvent> Transform(IReadOnlyList<Sample> samples)
        {
            var events = new List<ProfilerEvent>();
            IReadOnlyList<string> prevStack = Array.Empty<string>();

            foreach (var sample in samples)
            {
                var currStack = sample.FunctionStack;
                int lcp = 0; // longest common prefix
                int minLen = Math.Min(prevStack.Count, currStack.Count);

                // find LCP
                while (lcp < minLen && prevStack[lcp] == currStack[lcp])
                    lcp++;

                // emit "end" events for functions that disappeared (reverse order)
                for (int i = prevStack.Count - 1; i >= lcp; i--)
                    events.Add(new ProfilerEvent("end", sample.Timestamp, prevStack[i]));

                // emit "start" events for new functions (forward order)
                for (int i = lcp; i < currStack.Count; i++)
                    events.Add(new ProfilerEvent("start", sample.Timestamp, currStack[i]));

                prevStack = currStack;
            }

            return events;
        }
    }

    // Simple test case (no framework)
    public static class SampleToEventTransformerTests
    {
        public static void Run()
        {
            var samples = new List<Sample>
            {
                new Sample(1, new[] { "A" }),
                new Sample(2, new[] { "A", "B" }),
                new Sample(3, new[] { "A" }),
                new Sample(4, Array.Empty<string>())
            };

            var transformer = new SampleToEventTransformer();
            var events = transformer.Transform(samples);

            // Expected sequence:
            // 1: start A
            // 2: start B
            // 3: end B
            // 4: end A

            var expected = new[]
            {
                "1:start:A",
                "2:start:B",
                "3:end:B",
                "4:end:A"
            };

            var actual = events
                .Select(e => $"{e.Timestamp}:{e.Kind}:{e.FunctionName}")
                .ToArray();

            if (!expected.SequenceEqual(actual))
            {
                throw new Exception(
                    "Test failed!\nExpected:\n" +
                    string.Join("\n", expected) +
                    "\nActual:\n" +
                    string.Join("\n", actual)
                );
            }

            Console.WriteLine("Test passed!");
        }
    }

   
}
