namespace JavaByteReader.Attribute;

class AttributeLineNumberTable : JavaAttribute {
    public const string AttributeName = "LineNumberTable";
    public LineNumberTable[] lineNumberTable;

    public AttributeLineNumberTable(LineNumberTable[] lineNumberTable) {
        this.lineNumberTable = lineNumberTable;
    }

    public AttributeLineNumberTable(FixedBinaryReader reader) {
        lineNumberTable = new LineNumberTable[reader.ReadUInt16()];
        for(int i = 0; i < lineNumberTable.Length; i++) lineNumberTable[i] = new LineNumberTable(reader);
    }

    public override string Name => AttributeName;

    public struct LineNumberTable {
        public ushort startPC;
        public ushort lineNumber;

        public LineNumberTable(ushort startPC, ushort lineNumber) {
            this.startPC = startPC;
            this.lineNumber = lineNumber;
        }

        public LineNumberTable(FixedBinaryReader reader) {
            startPC = reader.ReadUInt16();
            lineNumber = reader.ReadUInt16();
        }
    }
}