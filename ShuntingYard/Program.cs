using ShuntingYard;

const string inputString = "3+4+22-111*12-11/23+10";

Console.WriteLine("Shunting Yard Demo");
Console.WriteLine(inputString);

var tokenizer = new TokenizationProcessor();
var parser = new ShuntingYardProcessor();
var evaluator = new EvaluationProcessor();

var allTokens = tokenizer.Tokenize(inputString);
Console.WriteLine(string.Join(" ", allTokens));

var rpnInput = parser.Parse(allTokens);
Console.WriteLine(string.Join(" ", rpnInput));

var result = evaluator.Evaluate(rpnInput);
Console.WriteLine(result);
