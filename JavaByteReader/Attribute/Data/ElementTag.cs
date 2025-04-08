namespace JavaByteReader.Attribute.Data;

enum ElementTag : byte {
    Byte = (byte) 'B',
    Char = (byte) 'C',
    Double = (byte) 'D',
    Float = (byte) 'F',
    Int = (byte) 'I',
    Long = (byte) 'J',
    Short = (byte) 'S',
    Boolean = (byte) 'Z',
    String = (byte) 's',
    EnumConst = (byte) 'e',
    Class = (byte) 'c',
    Annotation = (byte) '@',
    Array = (byte) '[',
}