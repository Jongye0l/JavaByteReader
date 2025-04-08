using JavaByteReader.Attribute.Data;

namespace JavaByteReader.Attribute;

class AttributeRuntimeInvisibleParameterAnnotations : JavaAttribute {
    public const string AttributeName = "RuntimeInvisibleParameterAnnotations";
    public ParameterAnnotation[] parameterAnnotations;

    public AttributeRuntimeInvisibleParameterAnnotations(ParameterAnnotation[] parameterAnnotations) {
        this.parameterAnnotations = parameterAnnotations;
    }

    internal AttributeRuntimeInvisibleParameterAnnotations(FixedBinaryReader reader) {
        ushort parameterCount = reader.ReadUInt16();
        parameterAnnotations = new ParameterAnnotation[parameterCount];
        for(int i = 0; i < parameterCount; i++) parameterAnnotations[i] = new ParameterAnnotation(reader);
    }

    public override string Name => AttributeName;
}