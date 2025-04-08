namespace JavaByteReader.Attribute;

class AttributeInnerClasses : JavaAttribute {
    public const string AttributeName = "InnerClasses";

    public Classes[] classes;

    public AttributeInnerClasses(Classes[] classes) {
        this.classes = classes;
    }

    public AttributeInnerClasses(FixedBinaryReader reader) {
        classes = new Classes[reader.ReadUInt16()];
        for(int i = 0; i < classes.Length; i++) classes[i] = new Classes(reader);
    }

    public override string Name => AttributeName;

    public struct Classes {
        public ushort InnerClassInfoIndex;
        public ushort OuterClassInfoIndex;
        public ushort InnerNameIndex;
        public ushort InnerClassAccessFlags;

        public Classes(ushort innerClassInfoIndex, ushort outerClassInfoIndex, ushort innerNameIndex, ushort innerClassAccessFlags) {
            InnerClassInfoIndex = innerClassInfoIndex;
            OuterClassInfoIndex = outerClassInfoIndex;
            InnerNameIndex = innerNameIndex;
            InnerClassAccessFlags = innerClassAccessFlags;
        }

        public Classes(FixedBinaryReader reader) {
            InnerClassInfoIndex = reader.ReadUInt16();
            OuterClassInfoIndex = reader.ReadUInt16();
            InnerNameIndex = reader.ReadUInt16();
            InnerClassAccessFlags = reader.ReadUInt16();
        }
    }
}