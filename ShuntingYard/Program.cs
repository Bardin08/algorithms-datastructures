using ShuntingYard;

const string inputString = "2 ^ 2 ^ 2";

Console.WriteLine("Shunting Yard Demo");
Console.WriteLine(inputString);

var tokenizer = new TokenizationProcessor();
var parser = new ShuntingYardProcessor();
var evaluator = new EvaluationProcessor();

var allTokens = tokenizer.Tokenize(inputString);
Console.WriteLine("Step 1(Tokenization) result: {0}", string.Join(" ", allTokens));

var rpnInput = parser.Parse(allTokens);
Console.WriteLine("Step 2(Shunting) result: {0}", string.Join(" ", rpnInput));
 
var result = evaluator.Evaluate(rpnInput);
Console.WriteLine("Step 3(Evaluation) result: {0}", result);
