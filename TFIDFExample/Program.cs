using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFIDFExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Some example documents.
            string[] documents =
            {
                "My name is James",
                "James is the best in the world",
                "I sure do love James"
            };

            // Apply TF*IDF to the documents and get the resulting vectors.
            var inputs = TFIDF.Transform(documents, 0);
            inputs = TFIDF.Normalize(inputs);

            // Display the output.
            for (int index = 0; index < inputs.Count; index++)
            {
                Console.WriteLine(documents[index]);

                foreach (var value in inputs[index])
                {
                    Console.Write(value.Key + ":" + value.Value + ", ");
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("ranking");

            foreach (var term in TFIDF.GetRanking(inputs).OrderBy(d => d.Value))
            {
                Console.WriteLine(term.Key + " - " + term.Value);
            }

            Console.WriteLine("\n");
        }
    }
}
