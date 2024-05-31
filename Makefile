bin_path := Srujan.Lexer\bin\Debug\net8.0\win-x64
fileName ?= पिंगाला.सृ
file ?= Srujan.Lexer\Samples\$(fileName)
build:
	copy $(file) $(bin_path)
	del $(bin_path)\non-unicode.sru
	del $(bin_path)\compiled_ir.ll
	del $(bin_path)\executable_file.exe
	ren "$(bin_path)\$(fileName)" non-unicode.sru
	./$(bin_path)/Srujan.exe $(bin_path)\non-unicode.sru compile
	copy compiled_ir.ll $(bin_path)
	clang -c $(bin_path)/compiled_ir.ll -o $(bin_path)/object_file.o
	gcc $(bin_path)/object_file.o -o $(bin_path)/executable_file.exe
	./$(bin_path)/executable_file.exe