using Interpreter;

var interpreterContext = new InterpreterContext();
var interpreterClient = new InterpreterClient(interpreterContext);

var binaryStr = "28 in Binary";
var heaxadecimalStr = "28 in Hexadecimal";

Console.WriteLine(interpreterClient.Interpret(binaryStr));
Console.WriteLine(interpreterClient.Interpret(heaxadecimalStr));

/* Summery
 * the Interpreter Pattern is useful when you need to parse and evaluate a language or expressions in a structured way,
 * and it helps separate the language's grammar from the evaluation logic.
 */