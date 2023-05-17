using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Install;

string? codigoFuente = null;
if(args.Length>0) codigoFuente = args[0];

TextReader lector = Console.In;
if (codigoFuente!= null)
{
    lector = File.OpenText(codigoFuente);
}

string? expresion = lector.ReadLine();
int linea = 1;

ExprParser miparser = new ExprParser(null);
miparser.BuildParseTree = true;

while (expresion != null)
{
    AntlrInputStream entrada = new AntlrInputStream(expresion + "\n");
    ExprLexer milexer = new ExprLexer(entrada);
    milexer.Line = linea;
    milexer.Column = 0;
    CommonTokenStream tokens = new CommonTokenStream(milexer);
    miparser.TokenStream= tokens;
    miparser.prog();
    expresion= lector.ReadLine();
    linea++;
}
if(codigoFuente!= null)
{
    lector.Close();
}
