using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Data
{
    public int id;
    public string namaLiquid;
    public float ph;

    public Data(int id, string namaLiquid, float ph)
    {
        this.id = id;
        this.namaLiquid = namaLiquid;
        this.ph = ph;
    }
}

public class SQLite : MonoBehaviour
{
    private const string databaseName = "simulasilab_db";
    private const string tableName = "liquidPh";
    private const string keyId = "_id";
    private const string keyNamaLiquid = "nama_liquid";
    private const string keyPh = "ph";
    private const string keyKonsentrasiMolaritas = "km";

    private IDbConnection dbconnect;

    // Start is called before the first frame update
    void Awake()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/" + databaseName;
        dbconnect = new SqliteConnection(connection);
        dbconnect.Open();

        CreateTable();
    }

    public void CreateTable()
    {
        DeleteAllData();

        IDbCommand dbcmd = dbconnect.CreateCommand();
        string statement = "CREATE TABLE IF NOT EXISTS " + tableName + " (" +
            keyId + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
            keyNamaLiquid + " TEXT, " +
            keyPh + " REAL" +
            keyKonsentrasiMolaritas + " REAL" + ")";
        dbcmd.CommandText = statement;
        dbcmd.ExecuteNonQuery();
    }

    public void InsertLiquid(string namaLiquid, float ph, float konsentrasiMoralitas)
    {
        IDbCommand dbcmd = dbconnect.CreateCommand();
        string statement = "INSERT INTO " + tableName + " (" +
            keyNamaLiquid + ", " +
            keyPh + ") " +
            "VALUES (" +
            "'" + namaLiquid + "', " +
            "'" + ph + "'" +
            "'" + konsentrasiMoralitas + "'" + ")";
        dbcmd.CommandText = statement;
        dbcmd.ExecuteNonQuery();
    }

    public IDataReader GetAllData()
    {
        IDbCommand dbcmd = dbconnect.CreateCommand();
        string statement = "SELECT * FROM " + tableName;
        dbcmd.CommandText = statement;
        return dbcmd.ExecuteReader();
    }

    public IDataReader SearchData(string namaLiquid)
    {
        IDbCommand dbcmd = dbconnect.CreateCommand();
        string statement = "SELECT * FROM " + tableName +
            " WHERE " + keyNamaLiquid + " LIKE '%" + namaLiquid + "%'";
        dbcmd.CommandText = statement;
        return dbcmd.ExecuteReader();
    }

    public int GetNumberRecord()
    {
        IDbCommand dbcmd = dbconnect.CreateCommand();
        string statement = "SELECT COUNT(" + keyId + ") FROM " + tableName;
        dbcmd.CommandText = statement;
        IDataReader reader = dbcmd.ExecuteReader();

        if (reader.Read())
        {
            return reader.GetInt32(0);
        }
        return 0;
    }

    public void UpdateData(int id, string namaLiquid, float ph, float konsentrasiMoralitas)
    {
        IDbCommand dbcmd = dbconnect.CreateCommand();
        string statement = "UPDATE " + tableName + " SET " +
            keyNamaLiquid + " = '" + namaLiquid + "', " +
            keyPh + " = '" + ph + "'" +
            keyKonsentrasiMolaritas + " = '" + konsentrasiMoralitas + "'" +
            " WHERE " + keyId + " = " + id;
        dbcmd.CommandText = statement;
        dbcmd.ExecuteNonQuery();
    }

    public void DeleteAllData()
    {
        IDbCommand dbcmd = dbconnect.CreateCommand();
        string statement = "DROP TABLE IF EXISTS " + tableName;
        dbcmd.CommandText = statement;
        dbcmd.ExecuteNonQuery();
    }

    ~SQLite()
    {
        dbconnect.Close();
    }
}