using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
    
    private String  SqlUser;
    private String  SqlPassword;
    private String  SqlServer;
    private String  SqlDatabase;
    private String  SqlPort;

    private String  _StringReport;    
    private Boolean Toolbar;
    private Boolean Statusbar;
    

    private NameValueCollection _NameValueCollection;

    private String Conn;
    private String Param;
    //private String Metadata;
    


    protected void Page_Init(object sender, EventArgs e)
    {

        // Capturo os parametros do Genexus
        HttpRequest _HttpRequest = Request;
        string v = _HttpRequest.QueryString["rpt"];
        _StringReport = v ?? "Reports/Sample.rpt";
       

        // Operador de coalescência nula.        

        //// Busca da Sessão os valores      

        Conn = Session["CrystalConn"].ToString();
        Param = Session["CrystalParam"].ToString();
       // Metadata = "";//Session["CrystalMetada"].ToString();
        
        // Seto Valores de Conexão        
        SetConn(Conn);
        
        // Armazena a QueryString em um collection.
        _NameValueCollection = Request.QueryString;

        // Tenta carregar o Relatório.
        try
        {
            // Instancia o relatório.
            ReportDocument _ReportDocument = new ReportDocument();

            // Carrega o relatório.
             _ReportDocument.Load(_StringReport);
            //_ReportDocument.Load(Server.MapPath(_StringReport));


            // Configuro o editor
            _ReportDocument.DataSourceConnections[0].IntegratedSecurity = false;
            _ReportDocument.DataSourceConnections[0].SetConnection(SqlServer, SqlDatabase, SqlUser, SqlPassword);
           // _ReportDocument.SetDatabaseLogon(SqlUser, SqlPassword, SqlServer, SqlDatabase, true);


            // Configurando o Viewer do Crystal
            CrystalReportViewer1.Visible = true;
            CrystalReportViewer1.Enabled = true;

            v = _HttpRequest.QueryString["toolbar"];
            if (Boolean.TryParse(v, out Toolbar))
            {
                CrystalReportViewer1.DisplayToolbar = Toolbar;
            }
            v = _HttpRequest.QueryString["statusbar"];
            if (Boolean.TryParse(v, out Statusbar))
            {
                CrystalReportViewer1.DisplayStatusbar = Statusbar;
            }
            CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;
            CrystalReportViewer1.EnableParameterPrompt = true;
            CrystalReportViewer1.EnableDatabaseLogonPrompt = false;
            CrystalReportViewer1.SeparatePages = true;            
            CrystalReportViewer1.HasToggleParameterPanelButton = true;
            
            //Set Parameters                    
            SetParm(Param, _ReportDocument);
            
            CrystalReportViewer1.ReportSource = _ReportDocument;
            

        }
        catch (Exception _Exception)
        {
            TextBox1.Text = _Exception.Message;
        }
    }

    public void SetParm(string param, ReportDocument _ReportDocument)
    {
        // Desserializa dados.
        JavaScriptSerializer _Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        // Cada collection dentro do objeto desserializado representa um parâmetro do relatório.
        foreach (object _ItemObject in (_Serializer.DeserializeObject(param) as object[]))
        {
            // Trata a collection dentro de cada item desserializado.
            ReportParameter _ReportParameter = new ReportParameter(_ItemObject as Dictionary<String, object>);
            // Atribui cada parâmetro.
            _ReportDocument.SetParameterValue(_ReportParameter.Name, _ReportParameter.Value);
          
        }
    }
    
    public void SetConn(string json)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        dynamic resultado = serializer.DeserializeObject(json);
        
        foreach (KeyValuePair<string, object> entry in resultado)
        {
            var key   = entry.Key;
            var value = entry.Value as string;

            switch (key)
            {
                case "User":
                    SqlUser     = value;                    
                    break;
                case "Password":
                    SqlPassword = value;                    
                    break;
                case "Server":
                    SqlServer   = value;                    
                    break;
                case "DataBase":
                    SqlDatabase = value;                    
                    break;
                case "Port":
                    SqlPort     = value;                    
                    break;
            }

        }

    }

    private class ReportParameter
    {
        #region Private Properties.

        private String _Name;
        private object _Value;

        #endregion

        #region Public Properties.

        public String Name
        {
            get { return _Name; }
        }
        public object Value
        {
            get { return _Value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Trata uma collection de três objetos contendo Name, Value e Type para 
        /// adicionar às propriedades de um relatório do Crystal Reports.
        /// </summary>
        /// <param name="_ObjectCollection02">Dicionário contendo três objetos contendo Name, Value e Type.</param>
        public ReportParameter(Dictionary<String, object> _ObjectCollection02)
        {
            object _ObjectName  = new object();
            object _ObjectValue = new object();
            object _ObjectType  = new object();
            // Tenta converter o valor da chave Name.
            if (_ObjectCollection02.TryGetValue("Name", out _ObjectName))
            {
                _Name = _ObjectName.ToString();
            }
            else
            {
                // Erro de leitura/conversão da coluna Name.
            }
            // Tenta converter o valor das chaves Value e Type e tenta instanciá-las em um object.
            if (_ObjectCollection02.TryGetValue("Value", out _ObjectValue) && _ObjectCollection02.TryGetValue("Type", out _ObjectType))
            {
                try
                {
                  _Value = (String)_ObjectValue; //Convert.ChangeType(_ObjectValue, Type.GetType((String)_ObjectType));
                }
                catch
                {
                    // Erro de instanciação envolvendo as colunas Value e Type.
                }
            }
            else
            {
                // Erro de leitura/conversão da coluna Value ou Type
            }
        }

        #endregion
    }

}
