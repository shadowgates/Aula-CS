using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Conexao
/// </summary>
public class Conexao
{

    private string conexao;
    private AppDatabase.OleDBTransaction db;

    /// <summary>
    /// String de conexão com o banco de dados 
    /// </summary>
    public Conexao()
    {
        conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/ADS-DB.accdb") + ";Persist Security Info=False;";
    }

    /// <summary>
    /// Retorna uma instancia da classe OleDbTransaction conectada ao banco de dados 
    /// </summary>
    /// <returns></returns>
    public AppDatabase.OleDBTransaction GetConnection()
    {
        db = new AppDatabase.OleDBTransaction();
        db.ConnectionString = conexao;
        return db;
    }
}