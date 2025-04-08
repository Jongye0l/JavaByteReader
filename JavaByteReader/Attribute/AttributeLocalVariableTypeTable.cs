namespace JavaByteReader.Attribute;

class AttributeLocalVariableTypeTable : JavaAttribute {
    public const string AttributeName = "LocalVariableTypeTable";
    public LocalVariableTypeTable[] localVariableTypeTable;

    public AttributeLocalVariableTypeTable(LocalVariableTypeTable[] localVariableTypeTable) {
        this.localVariableTypeTable = localVariableTypeTable;
    }

    public AttributeLocalVariableTypeTable(FixedBinaryReader reader) {
        localVariableTypeTable = new LocalVariableTypeTable[reader.ReadUInt16()];
        for(int i = 0; i < localVariableTypeTable.Length; i++) localVariableTypeTable[i] = new LocalVariableTypeTable(reader);
    }

    public override string Name => AttributeName;

    public struct LocalVariableTypeTable {
        public ushort startPC;
        public ushort length;
        public ushort nameIndex;
        public ushort signatureIndex;
        public ushort index;

        public LocalVariableTypeTable(ushort startPC, ushort length, ushort nameIndex, ushort signatureIndex, ushort index) {
            this.startPC = startPC;
            this.length = length;
            this.nameIndex = nameIndex;
            this.signatureIndex = signatureIndex;
            this.index = index;
        }

        public LocalVariableTypeTable(FixedBinaryReader reader) {
            startPC = reader.ReadUInt16();
            length = reader.ReadUInt16();
            nameIndex = reader.ReadUInt16();
            signatureIndex = reader.ReadUInt16();
            index = reader.ReadUInt16();
        }
    }
}