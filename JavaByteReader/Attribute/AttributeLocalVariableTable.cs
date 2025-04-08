namespace JavaByteReader.Attribute;

class AttributeLocalVariableTable : JavaAttribute {
    public const string AttributeName = "LocalVariableTable";
    public LocalVariableTable[] localVariableTable;

    public AttributeLocalVariableTable(LocalVariableTable[] localVariableTable) {
        this.localVariableTable = localVariableTable;
    }

    public AttributeLocalVariableTable(FixedBinaryReader reader) {
        localVariableTable = new LocalVariableTable[reader.ReadUInt16()];
        for(int i = 0; i < localVariableTable.Length; i++) localVariableTable[i] = new LocalVariableTable(reader);
    }

    public override string Name => AttributeName;

    public struct LocalVariableTable {
        public ushort startPC;
        public ushort length;
        public ushort nameIndex;
        public ushort descriptorIndex;
        public ushort index;

        public LocalVariableTable(ushort startPC, ushort length, ushort nameIndex, ushort descriptorIndex, ushort index) {
            this.startPC = startPC;
            this.length = length;
            this.nameIndex = nameIndex;
            this.descriptorIndex = descriptorIndex;
            this.index = index;
        }

        public LocalVariableTable(FixedBinaryReader reader) {
            startPC = reader.ReadUInt16();
            length = reader.ReadUInt16();
            nameIndex = reader.ReadUInt16();
            descriptorIndex = reader.ReadUInt16();
            index = reader.ReadUInt16();
        }
    }
}