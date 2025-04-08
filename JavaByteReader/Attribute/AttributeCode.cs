namespace JavaByteReader.Attribute;

class AttributeCode : JavaAttribute {
    public const string AttributeName = "Code";
    private ushort maxStack;
    private ushort maxLocals;
    public byte[] code;
    public ExceptionTable[] exceptionTable;
    public JavaAttribute[] attributes;

    public struct ExceptionTable {
        public ushort startPc;
        public ushort endPc;
        public ushort handlerPc;
        public ushort catchType;

        public ExceptionTable(ushort startPc, ushort endPc, ushort handlerPc, ushort catchType) {
            this.startPc = startPc;
            this.endPc = endPc;
            this.handlerPc = handlerPc;
            this.catchType = catchType;
        }

        public ExceptionTable(FixedBinaryReader reader) {
            startPc = reader.ReadUInt16();
            endPc = reader.ReadUInt16();
            handlerPc = reader.ReadUInt16();
            catchType = reader.ReadUInt16();
        }
    }

    public AttributeCode() {
    }

    internal AttributeCode(FixedBinaryReader reader, Constant[] constants) {
        maxStack = reader.ReadUInt16();
        maxLocals = reader.ReadUInt16();
        code = reader.ReadBytes((int) reader.ReadUInt32());
        exceptionTable = new ExceptionTable[reader.ReadUInt16()];
        for(int i = 0; i < exceptionTable.Length; i++) exceptionTable[i] = new ExceptionTable(reader);
        attributes = new JavaAttribute[reader.ReadUInt16()];
        for(int i = 0; i < attributes.Length; i++) attributes[i] = ReadAttribute(reader, constants);
    }

    public override string Name => AttributeName;
}