using System;
using System.IO;
using System.Data;
using System.Text;
using System.IO.Compression;

namespace MostafaTech
{
	public class BinaryTable
	{

		public static void WriteToFile(DataTable datatable, string BinaryFile, bool compress = false)
		{
			if (File.Exists(BinaryFile)) File.Delete(BinaryFile);
			FileStream fs = new FileStream(BinaryFile, FileMode.OpenOrCreate, FileAccess.Write);
			WriteToStream(datatable, fs, compress);
			fs.Close();
		}
		public static DataTable ReadFromFile(string BinaryFile, bool compress = false)
		{
			FileStream fs = new FileStream(BinaryFile, FileMode.Open, FileAccess.Read);
			DataTable datatable = ReadFromStream(fs, compress);
			fs.Close();
			return datatable;
		}

		public static void WriteToStream(DataTable datatable, Stream stream, bool compress = false)
		{
			var mem = new MemoryStream();
			var bw = new BinaryWriter(mem);

			Encoding encoding = Encoding.UTF8;

			try
			{
				// Write Table Definition
				bw.Write((byte)datatable.Columns.Count); // one bytes
				for (int c = 0; c < datatable.Columns.Count; c++)
				{
					bw.Write((byte)encoding.GetByteCount(datatable.Columns[c].ColumnName));
					bw.Write(encoding.GetBytes(datatable.Columns[c].ColumnName));
					bw.Write((byte)encoding.GetByteCount(datatable.Columns[c].DataType.FullName));
					bw.Write(encoding.GetBytes(datatable.Columns[c].DataType.FullName));
				}
				// Write Records
				bw.Write((short)datatable.Rows.Count); // two bytes
				for (int i = 0; i < datatable.Rows.Count; i++)
				{
					for (int j = 0; j < datatable.Columns.Count; j++)
					{
						if (datatable.Columns[j].DataType == typeof(string))
						{
							string field_value = datatable.Rows[i][j].ToString();
							int field_length = encoding.GetByteCount(field_value);
							bw.Write((byte)field_length);
							bw.Write(encoding.GetBytes(field_value));
						}
						else if (datatable.Columns[j].DataType == typeof(bool))
							bw.Write((bool)datatable.Rows[i][j]);
						else if (datatable.Columns[j].DataType == typeof(byte))
							bw.Write((byte)datatable.Rows[i][j]);
						else if (datatable.Columns[j].DataType == typeof(decimal))
							bw.Write((decimal)datatable.Rows[i][j]);
						else if (datatable.Columns[j].DataType == typeof(double))
							bw.Write((double)datatable.Rows[i][j]);
						else if (datatable.Columns[j].DataType == typeof(short))
							bw.Write((short)datatable.Rows[i][j]);
						else if (datatable.Columns[j].DataType == typeof(int))
							bw.Write((int)datatable.Rows[i][j]);
						else if (datatable.Columns[j].DataType == typeof(long))
							bw.Write((long)datatable.Rows[i][j]);
						else if (datatable.Columns[j].DataType == typeof(DateTime))
							bw.Write(((DateTime)datatable.Rows[i][j]).ToBinary());
						else
						{
							throw new NotImplementedException();
						}
					}
				}

				mem.Position = 0;
				stream.Position = 0;

				if (compress)
				{
					using (var gzip = new GZipStream(stream, CompressionMode.Compress))
					{
						mem.CopyTo(gzip);
					}
				}
				else
				{
					mem.CopyTo(stream);
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				bw.Close();
				mem.Close();
				stream.Close();
			}
		}

		public static DataTable ReadFromStream(Stream stream, bool compress = false)
		{
			var datatable = new DataTable();
			Stream inStream;

			if (compress)
			{
				inStream = new MemoryStream();
				using (var bigStream = new GZipStream(stream, CompressionMode.Decompress, true))
					bigStream.CopyTo(inStream);
			}
			else inStream = stream;

			inStream.Position = 0;
			var br = new BinaryReader(inStream);
			Encoding encoding = Encoding.UTF8;

			try
			{
				int cols_count = (int)br.ReadByte();
				for (int c = 0; c < cols_count; c++)
				{
					int col_name_length = (int)br.ReadByte();
					string col_name = encoding.GetString(br.ReadBytes(col_name_length));
					int col_typename_length = (int)br.ReadByte();
					Type col_type = Type.GetType(encoding.GetString(br.ReadBytes(col_typename_length)));
					datatable.Columns.Add(col_name, col_type);
				}
				int rows_count = (int)br.ReadInt16();
				DataRow datarow;
				for (int i = 0; i < rows_count; i++)
				{
					datarow = datatable.NewRow();
					for (int j = 0; j < cols_count; j++)
					{
						if (datatable.Columns[j].DataType == typeof(string))
						{
							int field_length = (int)br.ReadByte();
							datarow[j] = encoding.GetString(br.ReadBytes(field_length));
						}
						else if (datatable.Columns[j].DataType == typeof(bool))
							datarow[j] = br.ReadBoolean();
						else if (datatable.Columns[j].DataType == typeof(byte))
							datarow[j] = br.ReadByte();
						else if (datatable.Columns[j].DataType == typeof(decimal))
							datarow[j] = br.ReadDecimal();
						else if (datatable.Columns[j].DataType == typeof(double))
							datarow[j] = br.ReadDouble();
						else if (datatable.Columns[j].DataType == typeof(short))
							datarow[j] = br.ReadInt16();
						else if (datatable.Columns[j].DataType == typeof(int))
							datarow[j] = br.ReadInt32();
						else if (datatable.Columns[j].DataType == typeof(long))
							datarow[j] = br.ReadInt64();
						else if (datatable.Columns[j].DataType == typeof(DateTime))
							datarow[j] = DateTime.FromBinary(br.ReadInt64());
						else
						{
							throw new NotImplementedException();
						}
					}
					datatable.Rows.Add(datarow);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				inStream.Close();
				stream.Close();
			}

			return datatable;
		}

	}
}
