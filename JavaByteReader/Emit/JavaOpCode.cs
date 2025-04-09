﻿namespace JavaByteReader.Emit;

public sealed class JavaOpCode {
    public readonly string Name;
    public readonly JavaCode Code;
    public readonly JavaInstructionSize InstructionSize;
    public readonly JavaStackPop StackPop;
    public readonly JavaStackPush StackPush;

    internal JavaOpCode(int flag) {
        Code = (JavaCode) (flag & 0xFF);
        JavaOpCodes.OpCodes[(int)Code] = this;
        Name = Code.ToString();
        if(Name.EndsWith("_")) Name = Name.Substring(0, Name.Length - 1);
        InstructionSize = (JavaInstructionSize) (flag >> 8 & 0xFF);
        StackPop = (JavaStackPop) (flag >> 16 & 0xFF);
        StackPush = (JavaStackPush) (flag >> 24 & 0xFF);
    }
}