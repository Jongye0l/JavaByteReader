namespace JavaByteReader.Emit;

public enum JavaStackPush : byte {
    None,
    Byte,
    Short,
    Int,
    Long,
    Float,
    Double,
    Char,
    Object,
    All4Byte,
    All8Byte,
    Prev,
    Prev2,
    Prev3,
    Prev_x2,
    Prev2_x2,
    Prev3_x2,
    Swap,
    Method
}