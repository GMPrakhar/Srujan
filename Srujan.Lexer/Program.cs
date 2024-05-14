using Srujan;
using static System.Net.Mime.MediaTypeNames;

string fileName;
if (args.Length == 0)
{
    fileName = "C:\\Users\\plondhe\\Repos\\Srujan\\Srujan.Lexer\\Samples\\गुणा-भाग.सृ";
}
else
{
    fileName = args[0];
}

string text = "";
//read the file
using (StreamReader sr = new StreamReader(fileName))
{
    text = sr.ReadToEnd();
}

new CompileAndRun().CompileAndRunCode(text);