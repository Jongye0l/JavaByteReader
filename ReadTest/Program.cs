using System;
using JavaByteReader;

namespace ReadTest {
    class Program {
        public static void Main(string[] args) {
            ClassDef classDef = ClassDef.Load("RepeatAction.class");

            Console.WriteLine($"Class Name: {classDef.Name}");

            foreach(MethodDef method in classDef.Methods) {
                Console.WriteLine($"Method: {method.Name}");
                Console.WriteLine($"Descriptor: {method.Descriptor}");
                Console.WriteLine($"Access Flags: {method.AccessFlags}");
                foreach(JavaAttribute customAttribute in method.CustomAttributes) {
                    Console.WriteLine($"Custom Attribute: {customAttribute.Name}");
                }
            }

            foreach(FieldDef field in classDef.Fields) {
                Console.WriteLine($"Field: {field.Name}");
                Console.WriteLine($"Descriptor: {field.Descriptor}");
                Console.WriteLine($"Access Flags: {field.AccessFlags}");
                foreach(JavaAttribute customAttribute in field.CustomAttributes) {
                    Console.WriteLine($"Custom Attribute: {customAttribute.Name}");
                }
            }

            foreach(ClassRef classRef in classDef.Interfaces) {
                Console.WriteLine($"Interface: {classRef.Name}");
            }

            foreach(JavaAttribute customAttribute in classDef.CustomAttributes) {
                Console.WriteLine($"Custom Attribute: {customAttribute.Name}");
            }
        }
    }
}