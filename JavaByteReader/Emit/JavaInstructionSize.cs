namespace JavaByteReader.Emit;

public enum JavaInstructionSize : byte {
    None,
    Byte,
    Short,
    Int,
    Long,
    ConstantByte,
    ConstantShort,
    ConstantInt,
    ConstantLong,
    ConstantFloat,
    ConstantDouble,
    ConstantString,
    Constant4Byte,
    Constant8Byte,
}