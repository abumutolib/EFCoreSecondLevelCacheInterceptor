using System;
using System.Collections;
using System.Data;
using System.Data.Common;

namespace EFCoreSecondLevelCacheInterceptor
{
    /// <summary>
    /// Converts an EFTableRows to a DbDataReader.
    /// </summary>
    public class EFTableRowsDataReader : DbDataReader
    {
        private readonly EFTableRows _tableRows;

        private int _currentRow;

        private object[] _rowValues;

        private bool _isClosed;

        private readonly int _rowsCount;

        /// <summary>
        /// Gets the number of columns in the current row.
        /// </summary>
        public override int FieldCount { get; }

        /// <summary>
        /// Gets a value that indicates whether the SqlDataReader contains one or more rows.
        /// </summary>
        public override bool HasRows => _rowsCount > 0;

        /// <summary>
        /// Retrieves a Boolean value that indicates whether the specified SqlDataReader instance has been closed.
        /// </summary>
        public override bool IsClosed => _isClosed;

        /// <summary>
        /// Gets a value that indicates the depth of nesting for the current row.
        /// </summary>
        public override int Depth => _tableRows.Get(_currentRow)?.Depth ?? 0;

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of the Transact-SQL statement.
        /// </summary>
        public override int RecordsAffected => -1;


        /// <summary>
        /// The TableName's unique ID.
        /// </summary>
        public string TableName => _tableRows.TableName;

        /// <summary>
        /// Converts an EFTableRows to a DbDataReader.
        /// </summary>
        public EFTableRowsDataReader(EFTableRows tableRows)
        {
            _tableRows = tableRows;
            _rowsCount = _tableRows.RowsCount;
            FieldCount = _tableRows?.FieldCount ?? 0;
        }

        /// <summary>
        /// Gets a string representing the data type of the specified column.
        /// </summary>
        public override string GetDataTypeName(int ordinal) => _tableRows.GetDataTypeName(ordinal);

        /// <summary>
        /// Gets the Type that is the data type of the object.
        /// </summary>
        public override Type GetFieldType(int ordinal) => _tableRows.GetFieldType(ordinal);

        /// <summary>
        /// Gets the name of the specified column.
        /// </summary>
        public override string GetName(int ordinal) => _tableRows.GetName(ordinal);

        /// <summary>
        /// Gets the column ordinal, given the name of the column.
        /// </summary>
        public override int GetOrdinal(string name) => _tableRows.GetOrdinal(name);

        /// <summary>
        /// Returns a DataTable that describes the column metadata of the SqlDataReader.
        /// </summary>
        public override DataTable GetSchemaTable() => throw new NotImplementedException();

        /// <summary>
        /// Advances the data reader to the next result, when reading the results of batch Transact-SQL statements.
        /// </summary>
        public override bool NextResult() => false;

        /// <summary>
        /// Closes the SqlDataReader object.
        /// </summary>
        public override void Close() => _isClosed = true;

        /// <summary>
        /// Advances the SqlDataReader to the next record.
        /// </summary>
        public override bool Read()
        {
            if (_currentRow >= _rowsCount)
            {
                return false;
            }

            _rowValues = _tableRows.Get(_currentRow++).Values;
            return true;
        }

        /// <summary>
        /// Returns GetValue(GetOrdinal(name))
        /// </summary>
        public override object this[string name] => GetValue(GetOrdinal(name));

        /// <summary>
        /// Returns GetValue(ordinal)
        /// </summary>
        public override object this[int ordinal] => GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        public override bool GetBoolean(int ordinal) => (bool)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a byte.
        /// </summary>
        public override byte GetByte(int ordinal) => (byte)GetValue(ordinal);

        /// <summary>
        /// Reads a stream of bytes from the specified column offset into the buffer an array starting at the given buffer offset.
        /// </summary>
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) => 0L;

        /// <summary>
        /// Gets the value of the specified column as a single character.
        /// </summary>
        public override char GetChar(int ordinal) => (char)GetValue(ordinal);

        /// <summary>
        /// Reads a stream of characters from the specified column offset into the buffer as an array starting at the given buffer offset.
        /// </summary>
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length) => 0L;

        /// <summary>
        /// Gets the value of the specified column as a DateTime object.
        /// </summary>
        public override DateTime GetDateTime(int ordinal) => (DateTime)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a Decimal object.
        /// </summary>
        public override decimal GetDecimal(int ordinal) => (decimal)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a double-precision floating point number.
        /// </summary>
        public override double GetDouble(int ordinal) => (double)GetValue(ordinal);

        /// <summary>
        /// Returns an IEnumerator that iterates through the SqlDataReader.
        /// </summary>
        public override IEnumerator GetEnumerator() => throw new NotSupportedException();

        /// <summary>
        /// Gets the value of the specified column as a single-precision floating point number.
        /// </summary>
        public override float GetFloat(int ordinal) => (float)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a globally unique identifier (GUID).
        /// </summary>
        public override Guid GetGuid(int ordinal) => (Guid)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a 16-bit signed integer.
        /// </summary>
        public override short GetInt16(int ordinal) => (short)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a 32-bit signed integer.
        /// </summary>
        public override int GetInt32(int ordinal) => (int)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a 64-bit signed integer.
        /// </summary>
        public override long GetInt64(int ordinal) => (long)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column as a string.
        /// </summary>
        public override string GetString(int ordinal) => (string)GetValue(ordinal);

        /// <summary>
        /// Gets the value of the specified column in its native format.
        /// </summary>
        public override object GetValue(int ordinal) => _rowValues[ordinal];

        /// <summary>
        /// Populates an array of objects with the column values of the current row.
        /// </summary>
        public override int GetValues(object[] result)
        {
            Array.Copy(_rowValues, result, _rowValues.Length);
            return _rowValues.Length;
        }

        /// <summary>
        /// Gets a value that indicates whether the column contains non-existent or missing values.
        /// </summary>
        public override bool IsDBNull(int ordinal) => _rowValues[ordinal] is DBNull;
    }
}