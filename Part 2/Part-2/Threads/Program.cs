// Thread thread = new Thread(CountTo100);
// thread.Start();
// Console.WriteLine("Main thread done");
//
// void CountTo100()
// {
//     for (int index = 0; index < 100; index++)
//     {
//         Console.WriteLine(index + 1);
//     }
// }

MultiplicationProblem problem = new MultiplicationProblem { A = 2, B = 3 };
Thread thread = new Thread(Multiply);
thread.Start(problem);

thread.Join();
Console.WriteLine(problem.Result);

void Multiply(object? obj)
{
    if (obj == null) return;

    MultiplicationProblem? multiplicationProblem = obj as MultiplicationProblem;

    multiplicationProblem.Result = multiplicationProblem.A * multiplicationProblem.B;
}

class MultiplicationProblem
{
    public double A { get; set; }
    public double B { get; set; }
    
    public double Result { get; set; }
}

