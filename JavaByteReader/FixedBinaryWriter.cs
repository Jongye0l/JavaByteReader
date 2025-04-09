using System;
using System.IO;

namespace JavaByteReader;

public class FixedBinaryWriter : IDisposable {
    private Stream _stream;
    private byte[] _buffer = new byte[8];

    public FixedBinaryWriter(Stream stream) {
        _stream = stream;
    }

    public void Write(byte value) {
        _buffer[0] = value;
        _stream.Write(_buffer, 0, 1);
    }

    public void Write(ushort value) {
        _buffer[0] = (byte) (value >> 8);
        _buffer[1] = (byte) value;
        _stream.Write(_buffer, 0, 2);
    }

    public void Write(uint value) {
        _buffer[0] = (byte) (value >> 24);
        _buffer[1] = (byte) (value >> 16);
        _buffer[2] = (byte) (value >> 8);
        _buffer[3] = (byte) value;
        _stream.Write(_buffer, 0, 4);
    }

    public void Write(ulong value) {
        _buffer[0] = (byte) (value >> 56);
        _buffer[1] = (byte) (value >> 48);
        _buffer[2] = (byte) (value >> 40);
        _buffer[3] = (byte) (value >> 32);
        _buffer[4] = (byte) (value >> 24);
        _buffer[5] = (byte) (value >> 16);
        _buffer[6] = (byte) (value >> 8);
        _buffer[7] = (byte) value;
        _stream.Write(_buffer, 0, 8);
    }

    public void Write(sbyte value) {
        _buffer[0] = (byte) value;
        _stream.Write(_buffer, 0, 1);
    }

    public void Write(short value) {
        _buffer[0] = (byte) (value >> 8);
        _buffer[1] = (byte) value;
        _stream.Write(_buffer, 0, 2);
    }

    public void Write(int value) {
        _buffer[0] = (byte) (value >> 24);
        _buffer[1] = (byte) (value >> 16);
        _buffer[2] = (byte) (value >> 8);
        _buffer[3] = (byte) value;
        _stream.Write(_buffer, 0, 4);
    }

    public void Write(long value) {
        _buffer[0] = (byte) (value >> 56);
        _buffer[1] = (byte) (value >> 48);
        _buffer[2] = (byte) (value >> 40);
        _buffer[3] = (byte) (value >> 32);
        _buffer[4] = (byte) (value >> 24);
        _buffer[5] = (byte) (value >> 16);
        _buffer[6] = (byte) (value >> 8);
        _buffer[7] = (byte) value;
        _stream.Write(_buffer, 0, 8);
    }

    public void Write(float value) {
        _buffer = BitConverter.GetBytes(value);
        Array.Reverse(_buffer, 0, 4);
        _stream.Write(_buffer, 0, 4);
    }

    public void Write(double value) {
        _buffer = BitConverter.GetBytes(value);
        Array.Reverse(_buffer, 0, 8);
        _stream.Write(_buffer, 0, 8);
    }

    public void Write(char value) {
        _buffer[0] = (byte) (value >> 8);
        _buffer[1] = (byte) value;
        _stream.Write(_buffer, 0, 2);
    }

    public void Write(string value) {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value);
        Write((ushort) bytes.Length);
        _stream.Write(bytes, 0, bytes.Length);
    }

    public void Write(byte[] bytes) {
        _stream.Write(bytes, 0, bytes.Length);
    }

    public void Write(byte[] bytes, int offset, int count) {
        _stream.Write(bytes, offset, count);
    }

    public void Dispose() {
        _stream?.Dispose();
    }
}