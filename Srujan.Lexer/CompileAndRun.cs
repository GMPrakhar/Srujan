using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using LLVMSharp.Interop;
using Srujan.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using LLVMSharp;
using LLVMSharp.Interop;
using Srujan.Lexer;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;
using Antlr4.Runtime.Misc;

namespace Srujan
{
    public class CompileAndRun
    {
        public void CompileAndRunCode(string text, bool justCompile, TextWriter? outputWriter = null)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                if(outputWriter != null)
                {
                    Console.SetOut(outputWriter);
                }

                // Console.WriteLine(text);
                LLVM.InitializeX86TargetInfo();
                LLVM.InitializeX86Target();
                LLVM.InitializeX86TargetMC();
                LLVM.InitializeX86AsmPrinter();
                AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
                सृजनLexer speakLexer = new सृजनLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
                सृजनParser speakParser = new सृजनParser(commonTokenStream);
                IParseTree tree = speakParser.program();
                LLVMModuleRef module;
                LLVMTargetMachineRef targetMachine;
                unsafe
                {


                    // Create LLVM module
                    module = LLVM.ModuleCreateWithName("AMod".ToSBytePointer());

                    // Create listener and traverse parse tree
                    CompilerListener listener = new CompilerListener(module);
                    new सृजनParseTreeWalker(listener.builder, listener).Walk(listener, tree);

                    // Dump LLVM IR for debugging
                    module.AddModuleFlag("-opaque-pointers", LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorOverride, 0);
                    var data = LLVM.PrintModuleToString(module);
                    var s = new string(data);

                    using (var fs = new FileStream("compiled_ir.ll", FileMode.OpenOrCreate))
                    {
                        fs.Write(Encoding.UTF8.GetBytes(s), 0, s.Length);
                    }

                    if(justCompile)
                    {
                        return;
                    }

                    // Compile LLVM IR into machine code
                    // Option 1: Use LLVM's JIT compiler
                    var engine = module.CreateExecutionEngine();
                    LLVM.InitializeAllTargets();
                    LLVMTargetRef target = LLVM.GetFirstTarget();

                    targetMachine = target.CreateTargetMachine("x86_64-pc-linux-gnu", "", "", LLVMCodeGenOptLevel.LLVMCodeGenLevelDefault, LLVMRelocMode.LLVMRelocPIC, LLVMCodeModel.LLVMCodeModelDefault);

                    LLVMMemoryBufferRef buffer;
                    LLVMObjectFileRef objectFile;


                    // Option 2: Use LLVM's static compiler (llc) to generate object file
                    LLVMObjectFileRef obj = LLVM.CreateObjectFile(module.WriteBitcodeToMemoryBuffer());

                    // and then link with a C/C++ compiler to create an executable

                    // Run the executable

                    engine.RunFunction(module.GetNamedFunction("main"), []);

                    // Dispose LLVM module
                    LLVM.DisposeModule(module);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
