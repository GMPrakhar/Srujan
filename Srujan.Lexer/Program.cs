using Srujan;
using static System.Net.Mime.MediaTypeNames;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
string fileName;
bool justCompile;
if (args.Length == 0)
{
    fileName = "D:\\Repos\\Srujan\\Srujan.Lexer\\Samples\\जारी.सृ";
    justCompile = false;
}
else
{
    fileName = args[0];
    justCompile = args[1] == "compile";
}

string text = "";
//read the file
using (StreamReader sr = new StreamReader(fileName))
{
    text = sr.ReadToEnd();
}

new CompileAndRun().CompileAndRunCode(text, justCompile);