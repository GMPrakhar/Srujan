; ModuleID = 'AMod'
source_filename = "AMod"

@stringParam = private unnamed_addr constant [5 x i8] c"%.3f\00", align 1
@stringParam.1 = private unnamed_addr constant [18 x i8] c"Current element: \00", align 1
@stringParam.2 = private unnamed_addr constant [4 x i8] c"%s\0A\00", align 1
@stringParam.3 = private unnamed_addr constant [3 x i8] c"%d\00", align 1
@stringParam.4 = private unnamed_addr constant [5 x i8] c"%.3f\00", align 1
@stringParam.5 = private unnamed_addr constant [3 x i8] c"%d\00", align 1
@stringParam.6 = private unnamed_addr constant [16 x i8] c"The answer is :\00", align 1
@stringParam.7 = private unnamed_addr constant [4 x i8] c"%s\0A\00", align 1
@stringParam.8 = private unnamed_addr constant [5 x i8] c"%.3f\00", align 1

define i32 @main() {
entry:
  %"\E0\A4\8F\E0\A4\95" = alloca double, align 8
  store double 1.003450e+02, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %loadtmp = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %ifcond = fcmp ogt double %loadtmp, 5.000000e+01
  br i1 %ifcond, label %then, label %else

then:                                             ; preds = %entry
  %loadtmp1 = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %printfCall = call i32 (ptr, double, ...) @printf(ptr @stringParam, double %loadtmp1)
  br label %ifcont

else:                                             ; preds = %entry
  br label %ifcont

ifcont:                                           ; preds = %else, %then
  %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE" = alloca [3 x i32], align 4
  %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE2" = getelementptr [3 x i32], ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE", i32 0
  store i32 10, ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE2", align 4
  %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE3" = getelementptr [3 x i32], ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE", i32 1
  store i32 20, ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE3", align 4
  %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE4" = getelementptr [3 x i32], ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE", i32 2
  store i32 30, ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE4", align 4
  %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE5" = getelementptr [3 x i32], ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE", i32 1
  store i32 20, ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE5", align 4
  %"\E0\A4\A6\E0\A4\BF" = alloca i32, align 4
  store i32 0, ptr %"\E0\A4\A6\E0\A4\BF", align 4
  br label %beforeLoop

beforeLoop:                                       ; preds = %loop, %ifcont
  %loadtmp6 = load i32, ptr %"\E0\A4\A6\E0\A4\BF", align 4
  %ifcond7 = icmp slt i32 %loadtmp6, 3
  br i1 %ifcond7, label %loop, label %afterLoop

loop:                                             ; preds = %beforeLoop
  %printfCall8 = call i32 (ptr, ptr, ...) @printf(ptr @stringParam.2, ptr @stringParam.1)
  %loadtmp9 = load i32, ptr %"\E0\A4\A6\E0\A4\BF", align 4
  %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE10" = getelementptr [3 x i32], ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE", i32 %loadtmp9
  %loadtmp11 = load i32, ptr %"\E0\A4\B5\E0\A4\BF\E0\A4\B0\E0\A4\BE10", align 4
  %printfCall12 = call i32 (ptr, i32, ...) @printf(ptr @stringParam.3, i32 %loadtmp11)
  %loadtmp13 = load i32, ptr %"\E0\A4\A6\E0\A4\BF", align 4
  %addtmp = add i32 %loadtmp13, 1
  store i32 %addtmp, ptr %"\E0\A4\A6\E0\A4\BF", align 4
  br label %beforeLoop

afterLoop:                                        ; preds = %beforeLoop
  store double 6.000000e+01, ptr %"\E0\A4\8F\E0\A4\95", align 8
  br label %beforeLoop14

beforeLoop14:                                     ; preds = %ifcont26, %afterLoop
  %loadtmp17 = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %ifcond18 = fcmp ogt double %loadtmp17, 5.000000e+01
  br i1 %ifcond18, label %loop15, label %afterLoop16

loop15:                                           ; preds = %beforeLoop14
  %loadtmp19 = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %printfCall20 = call i32 (ptr, double, ...) @printf(ptr @stringParam.4, double %loadtmp19)
  %loadtmp21 = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %subtmp = fsub double %loadtmp21, 1.000000e+00
  store double %subtmp, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %loadtmp22 = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %ifcond23 = fcmp olt double %loadtmp22, 5.500000e+01
  br i1 %ifcond23, label %then24, label %else25

afterLoop16:                                      ; preds = %beforeLoop14
  %printfCall41 = call i32 (ptr, ptr, ...) @printf(ptr @stringParam.7, ptr @stringParam.6)
  %loadtmp42 = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %printfCall43 = call i32 (ptr, double, ...) @printf(ptr @stringParam.8, double %loadtmp42)
  ret i32 0

then24:                                           ; preds = %loop15
  %"\E0\A4\A6\E0\A5\8B" = alloca i32, align 4
  store i32 30, ptr %"\E0\A4\A6\E0\A5\8B", align 4
  br label %beforeLoop27

else25:                                           ; preds = %loop15
  br label %ifcont26

ifcont26:                                         ; preds = %else25, %afterLoop29
  br label %beforeLoop14

beforeLoop27:                                     ; preds = %ifcont40, %then24
  %loadtmp30 = load i32, ptr %"\E0\A4\A6\E0\A5\8B", align 4
  %ifcond31 = icmp slt i32 %loadtmp30, 50
  br i1 %ifcond31, label %loop28, label %afterLoop29

loop28:                                           ; preds = %beforeLoop27
  %loadtmp32 = load i32, ptr %"\E0\A4\A6\E0\A5\8B", align 4
  %printfCall33 = call i32 (ptr, i32, ...) @printf(ptr @stringParam.5, i32 %loadtmp32)
  %loadtmp34 = load i32, ptr %"\E0\A4\A6\E0\A5\8B", align 4
  %addtmp35 = add i32 %loadtmp34, 1
  store i32 %addtmp35, ptr %"\E0\A4\A6\E0\A5\8B", align 4
  %loadtmp36 = load double, ptr %"\E0\A4\8F\E0\A4\95", align 8
  %ifcond37 = fcmp olt double %loadtmp36, 5.500000e+01
  br i1 %ifcond37, label %then38, label %else39

afterLoop29:                                      ; preds = %then38, %beforeLoop27
  br label %ifcont26

then38:                                           ; preds = %loop28
  br label %afterLoop29

else39:                                           ; preds = %loop28
  br label %ifcont40

ifcont40:                                         ; preds = %else39
  br label %beforeLoop27
}

declare i32 @printf(ptr, double, ...)
