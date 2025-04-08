using JavaByteReader.Attribute.Data;

namespace JavaByteReader.Attribute;

class AttributeAnnotationDefault : JavaAttribute {
    public const string AttributeName = "AnnotationDefault";
    public ElementValue defaultValue;

    public AttributeAnnotationDefault(ElementValue defaultValue) {
        this.defaultValue = defaultValue;
    }

    internal AttributeAnnotationDefault(FixedBinaryReader reader) {
        defaultValue = new ElementValue(reader);
    }

    public override string Name => AttributeName;
}