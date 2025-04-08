using JavaByteReader.Attribute.Data;

namespace JavaByteReader.Attribute;

class AttributeRuntimeVisibleAnnotations : JavaAttribute {
    public const string AttributeName = "RuntimeVisibleAnnotations";
    public Annotation[] annotations;

    public AttributeRuntimeVisibleAnnotations(Annotation[] annotations) {
        this.annotations = annotations;
    }

    internal AttributeRuntimeVisibleAnnotations(FixedBinaryReader reader) {
        ushort numAnnotations = reader.ReadUInt16();
        annotations = new Annotation[numAnnotations];
        for(int i = 0; i < numAnnotations; i++) annotations[i] = new Annotation(reader);
    }

    public override string Name => AttributeName;
}