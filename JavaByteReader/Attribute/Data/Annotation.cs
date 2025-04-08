namespace JavaByteReader.Attribute.Data;

struct Annotation {
    public ushort typeIndex;
    public ElementValuePair[] elementValuePairs;

    public Annotation(ushort typeIndex, ElementValuePair[] elementValuePairs) {
        this.typeIndex = typeIndex;
        this.elementValuePairs = elementValuePairs;
    }

    public Annotation(FixedBinaryReader reader) {
        typeIndex = reader.ReadUInt16();
        ushort numElementValuePairs = reader.ReadUInt16();
        elementValuePairs = new ElementValuePair[numElementValuePairs];
        for(int i = 0; i < numElementValuePairs; i++) {
            elementValuePairs[i] = new ElementValuePair(reader);
        }
    }
}