namespace JavaByteReader.Attribute.Data;

struct ElementValuePair {
    public ushort elementNameIndex;
    public ElementValue value;

    public ElementValuePair(ushort elementNameIndex, ElementValue value) {
        this.elementNameIndex = elementNameIndex;
        this.value = value;
    }

    public ElementValuePair(FixedBinaryReader reader) {
        elementNameIndex = reader.ReadUInt16();
        value = new ElementValue(reader);
    }
}