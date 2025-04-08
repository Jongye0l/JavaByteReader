namespace JavaByteReader;

public abstract class Class {
    public abstract string Name { get; set; }
    public abstract ClassDef ToDef();
}