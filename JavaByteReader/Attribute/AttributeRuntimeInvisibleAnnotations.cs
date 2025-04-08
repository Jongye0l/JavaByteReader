using JavaByteReader.Attribute.Data;

namespace JavaByteReader.Attribute;

class AttributeRuntimeInvisibleAnnotations : JavaAttribute {
    public const string AttributeName = "RuntimeInvisibleAnnotations";
    public Annotation[] annotations;

    public AttributeRuntimeInvisibleAnnotations(Annotation[] annotations) {
        this.annotations = annotations;
    }

    internal AttributeRuntimeInvisibleAnnotations(FixedBinaryReader reader) {
        ushort numAnnotations = reader.ReadUInt16();
        annotations = new Annotation[numAnnotations];
        for(int i = 0; i < numAnnotations; i++) annotations[i] = new Annotation(reader);
    }

    public override string Name => AttributeName;
}