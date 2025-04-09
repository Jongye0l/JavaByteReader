﻿namespace JavaByteReader.Emit;

public enum JavaStackPop : byte {
    None,
    Byte,
    Char,
    Short,
    Int,
    Int2,
    Long,
    Long2,
    Float,
    Float2,
    Double,
    Double2,
    Object,
    Object2,
    Array,
    ArrayIndex,
    ArrayIndexByte,
    ArrayIndexChar,
    ArrayIndexShort,
    ArrayIndexInt,
    ArrayIndexLong,
    ArrayIndexFloat,
    ArrayIndexDouble,
    ArrayIndexObject,
    All1,
    All2,
    Swap,
    Method
}