using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System.Net.Mail;
using Npgsql;




namespace WebScraper
{
    public partial class Form1 : Form
    {
        string  mensaje="";
        Boolean cargourl = false;
        Boolean entroelclik = false;
        string trinitytxt = "";
        Int16  esperatiempo=0;
        MailMessage mail = new MailMessage();


        public Form1()
        {
            InitializeComponent();
            SetBrowserEmulationVersion();
            cargaellog();
           
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            lblbienvenido.Visible = false;
            fondo.Visible = false; 
            mensaje = "Comienza a cargar datos ......" +"\n";
            txtlog.Text = ""; 
            leetxt();

            txtlog.Text = mensaje;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            HtmlElement estext = this.webBrowser1.Document.GetElementById("frmPrincipal:lnkTxtlistado");             
            estext.InvokeMember("Click");            
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            string claveacceso = "", id_empresa = "", id_cliente = "", tipodocumento = "";
            string rutaarchivo = "";
            string formoSQL = "";
            string formoclave = "";
            string quitaclave = "";
            string sqlbuscaclave = "";
            string sqlfinal = "";
            bool  enbase=false ;


            // codigo para abrir el cuadro de dialogo
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = openFileDialog1.FileName;
                    rutaarchivo = str_RutaArchivo;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            // si no encuentra el archivo
            if (rutaarchivo == "")
            {
                return;
            }
           // Aqui se lee el archivo txt
            string[] lines = System.IO.File.ReadAllLines(rutaarchivo );
                       
            foreach (string line in lines)
            {
                int index1 = line.IndexOf("Factura");
                int index2 = line.IndexOf("Comprobante");
                int index3 = line.IndexOf("Notas");

                if (index1 >= 0 || index2 >= 0 || index3 >= 0)
                {                  
                    String[] elements = System.Text.RegularExpressions.Regex.Split(line, "\t");
                    id_empresa = elements[2];
                    claveacceso = elements[9];
                    id_cliente = elements[8];
                    formoclave = formoclave + ",'" + claveacceso + "'";
                    tipodocumento = claveacceso.Substring(8, 2);
                    formoSQL = formoSQL + "insert into compraselectronicas(claveacceso,id_empresa,id_cliente,tipodocumento) values ('" + claveacceso + "','" + id_empresa + "','" + id_cliente + "'," + tipodocumento + ");\r\n";
                }
            }
            // Conexion para ingresar a la base de datos
            formoclave = formoclave.Substring(1);
            String[] buscasql = System.Text.RegularExpressions.Regex.Split(formoSQL, "\r\n");
            NpgsqlConnection conn = new NpgsqlConnection("Server=138.197.78.218;User Id=postgres;Password=Xohpq7012@;Database=Automatizaciones;");
            conn.Open();
            sqlbuscaclave = "select claveacceso from compraselectronicas where claveacceso in (" + formoclave + ")";
            NpgsqlCommand cmdbusca = new NpgsqlCommand(sqlbuscaclave, conn);
            NpgsqlDataReader reader = cmdbusca.ExecuteReader();
            while (reader.Read())
            {
                quitaclave = quitaclave +  "," + reader[0].ToString();
            }
            // Estas son las clavesde acceso que estan en la base
            if (quitaclave ==""){
                sqlfinal = formoSQL;
            } else{
            quitaclave = quitaclave.Substring(1);
            String[] compara = System.Text.RegularExpressions.Regex.Split(quitaclave , ",");              
                foreach (string lineclave in buscasql)//Comparo las claves en base con los nuevos insert
                {
                    enbase = false;
                    foreach (string clavecompara in compara)
                    {
                        int buca1 = lineclave.IndexOf(clavecompara);
                        if (buca1 >= 0)
                        {
                            enbase = true;
                            break;
                        }
                    }
                    if (enbase == false)
                    {
                        sqlfinal = sqlfinal + lineclave  + "\r\n";
                    }                 
                }  
        }
            // inserto las compras que no existen
            if (sqlfinal!=""){ 
            NpgsqlCommand cmd = new NpgsqlCommand(sqlfinal , conn);
            cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Las compras se ingresaron correctamente.","Compras Automaticas");
            return;

        }

        private void btnrecarga_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Cookie.Remove(0, webBrowser1.Document.Cookie.Count() - 1);
            webBrowser1.Document.Cookie = "";
            webBrowser1.Navigate("javascript:location.replace('https://srienlinea.sri.gob.ec/tuportal-internet/salir.jspa')");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(3000);
            }
            cargourl = false;
            entroelclik = false;
            lblbienvenido.Visible = true; 
            fondo.Visible = true;
        }

        public void cargaellog()
        {
            //string trinitytxt = System.IO.File.ReadAllText(@"D:\Disco Anterior\trinityrpa.txt");
            string trinitytxt = System.IO.File.ReadAllText(Application.StartupPath + @"\trinityrpa.txt");
           string[] separatrinity = trinitytxt.Split(new String[] { ";" }, System.StringSplitOptions.RemoveEmptyEntries);
           foreach (string accion in separatrinity)
           {
               mensaje = mensaje + accion;
           }
           txtlog.Text = mensaje; 
        }

       public void inicio(string laurl)
        {
            try
            {
                //SetBrowserEmulationVersion();              
                string url = laurl;
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
                webBrowser1.Navigate(new Uri(url, UriKind.Absolute));
                webBrowser1.ScriptErrorsSuppressed = true;
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
              
                //txtpagina.Text = webBrowser1.Url.ToString(); 

                mensaje = mensaje + "Entro a la pagina " + laurl + "\n";
               
            }
            catch {
                return;
            }

           }


       public void  leetxt()
       {
           string url = "";
           string cortaaccion = "";
           bool encontro = false;
           string tipo = "";
           bool sequeda = false;
           string ruta = Environment.CurrentDirectory ;
           string trinitytxt = System.IO.File.ReadAllText(ruta+"\\trinityrpa.txt");
           string[] separatrinity = trinitytxt.Split(new String[] { ";" }, System.StringSplitOptions.RemoveEmptyEntries);
           foreach (string accion in separatrinity)
           {
               cortaaccion = accion;
               encontro = cortaaccion.Contains("inicio");
               if (encontro == true)
               { // saca la url que se va a cargar
                   tipo = cortaaccion.Replace("inicio","");
                   tipo = tipo.Replace("(", "");
                   url = tipo.Replace(")", "");
                   inicio(url);
                   encontro = false;
               }
               
               encontro = cortaaccion.Contains("existe");
               if (encontro == true)
               { // saca el elemento existe 
                   tipo = cortaaccion.Replace("existe", "");
                   tipo = tipo.Replace("(", "");
                   tipo = tipo.Replace(")", "");
                   string[] tipodato = tipo.Split(new String[] { "." }, System.StringSplitOptions.RemoveEmptyEntries);
                   sequeda =existe(tipodato[0].Trim(), tipodato[1].Trim(), tipodato[2].Trim());
                   encontro = false;
                   if (sequeda ==false ){
                       return;
                   }
               }

               encontro = cortaaccion.Contains("click");
               if (encontro == true)
               { // saca el elemento existe 
                   tipo = cortaaccion.Replace("click", "");
                   tipo = tipo.Replace("(", "");
                   tipo = tipo.Replace(")", "");
                   string[] tipodato = tipo.Split(new String[] { "." }, System.StringSplitOptions.RemoveEmptyEntries);
                   envia(tipodato[0].Trim(), tipodato[1].Trim(), tipodato[2].Trim());
                   encontro = false;
               }

               encontro = cortaaccion.Contains("escribir");
               if (encontro == true)
               { // saca el elemento existe 
                   tipo = cortaaccion.Replace("escribir", "");
                   tipo = tipo.Replace("(", "");
                   tipo = tipo.Replace(")", "");
                   string[] tipodatoaux = tipo.Split(new String[] { "," }, System.StringSplitOptions.RemoveEmptyEntries);
                   string[] tipodato = tipodatoaux[0].Split(new String[] { "." }, System.StringSplitOptions.RemoveEmptyEntries);
                   escribir(tipodato[0].Trim(), tipodato[1].Trim(), tipodatoaux[1].Trim());
                   encontro = false;
               }

               encontro = cortaaccion.Contains("espera");
               if (encontro == true)
               {   // saca el elemento espera          
                   tipo = cortaaccion.Replace("espera", "");
                   tipo = tipo.Replace("(", "");
                   tipo = tipo.Replace(")", "");
                   esperar(tipo);                 
               }
           }          
           // pone el script del txt en el log
           txtscript.Text = trinitytxt;          
       }
        // Funcion para buscar al elemento html
       public Boolean existe(string tipo,string dato,string name) 
       {
           Boolean correcto = true;
           string elname = name.Replace("name:", "");
           HtmlElement estext = this.webBrowser1.Document.GetElementById(elname);

           if (estext==null){
               HtmlElementCollection esselect = this.webBrowser1.Document.GetElementsByTagName(elname);
               //namefrmPrincipal:dia
             mensaje = mensaje + "No se encontro texto -> " + elname + "\n";
             correcto = false;
           } else {  
                if (estext.GetAttribute("type").Equals("text"))
                {
                    if (estext.Name == elname)
                    {
                        mensaje = mensaje + "Encontro el texto -> " + elname + "\n";
                    }
                    else
                    {
                        mensaje = mensaje + "No se encontro texto -> " + elname + "\n";
                    }
                }

               if (estext.GetAttribute("type").Equals("button"))
               {
                   if (estext.Name == elname)
                   {
                       mensaje = mensaje + "Encontro el boton -> " + elname + "\n";
                   }
                   else
                   {
                       mensaje = mensaje + "No se encontro el boton -> " + elname + "\n";
                   }
               }

               if (estext.GetAttribute("type").Equals("password"))
               {
                   if (estext.Name == elname)
                   {
                       mensaje = mensaje + "Encontro el boton -> " + elname + "\n";
                   }
                   else
                   {
                       mensaje = mensaje + "No se encontro el boton -> " + elname + "\n";
                   }
               }

               if (estext.GetAttribute("type").Equals("select-one"))
               {
                   if (estext.Name == elname)
                   {
                       mensaje = mensaje + "Encontro el select -> " + elname + "\n";
                   }
                   else
                   {
                       mensaje = mensaje + "No se encontro el select -> " + elname + "\n";
                   }
               }          
         
           }
           return correcto;
       }

        // la funcion click del boton html
       public void envia(string tipo, string dato, string name)
       {
           string elname = name.Replace("name:", "");
           HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
           foreach (HtmlElement el in elc)
           {
               if ((el.GetAttribute("id").Equals(elname)) || (el.GetAttribute("name").Equals(elname))    )
               {
                   el.InvokeMember("Click");
                   entroelclik = true;
                   mensaje = mensaje + "Click en el boton ->  " + elname + "\n";
                   break;
               }
           }

           if (entroelclik == false)
           {
               HtmlElement estext = this.webBrowser1.Document.GetElementById(elname);
               if (estext != null)
               {
                   estext.InvokeMember("Click");
                   entroelclik = true;
                   mensaje = mensaje + "Click en el boton ->  " + elname + "\n";
               }
           }
           

           if (entroelclik == true)
           {
               ThreadStart delegado = new ThreadStart(CorrerProceso);
               //Creamos la instancia del hilo 
               Thread hilo = new Thread(delegado);
               txtlog.Text = mensaje;
               txtscript.Text = trinitytxt;
               //Iniciamos el hilo 
               hilo.Start();
               while ((webBrowser1.ReadyState == WebBrowserReadyState.Complete || webBrowser1.ReadyState == WebBrowserReadyState.Interactive ) && cargourl != true)
               {
                   if (cargourl != true)
                   {
                       Application.DoEvents();
                   }
               }
           }
           entroelclik = false;
        
       }


        // funcion del hilo cada ves que hace clik en el boton
       private void CorrerProceso()
       {
           Thread.Sleep(esperatiempo); 
           cargourl = true;
       }
     
        // Funcion para poner el valor en el html
       public void escribir(string tipo, string dato, string valor)
       {
           string eldato = dato.Replace("name:", "");
           HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
           foreach (HtmlElement el in elc)
           {
               if (el.GetAttribute("id").Equals(eldato))
               {                 
                   webBrowser1.Document.GetElementById(eldato).SetAttribute("Value", valor);
                   //webBrowser1.Document.GetElementById(eldato).InnerText  = valor;
                   mensaje = mensaje + "Escribio en el ->  " + eldato  + " : " + valor + "\n";
               }
           }

           HtmlElementCollection els = this.webBrowser1.Document.GetElementsByTagName("select");
           foreach (HtmlElement el in els)
           {
               if (el.GetAttribute("id").Equals(eldato))
               {
                   el.SetAttribute("selectedIndex", "0"); 
                   mensaje = mensaje + "Escribio en el ->  " + eldato + " : " + valor + "\n";
               }
           }

       }

       public void esperar(string valor)
       {
           esperatiempo = Int16.Parse (valor);
       }

       private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
       {
           try {             

               //string newurl = this.webBrowser1.Url.ToString();
                //MessageBox.Show("ggggg");
           }

           catch {
               return;
           }

          
       }

       #region emula el navegador
      
        //*************************************************
       public enum BrowserEmulationVersion
       {
           Default = 0,
           Version7 = 7000,
           Version8 = 8000,
           Version8Standards = 8888,
           Version9 = 9000,
           Version9Standards = 9999,
           Version10 = 10000,
           Version10Standards = 10001,
           Version11 = 11000,
           Version11Edge = 11001
       }
       private const string InternetExplorerRootKey = @"Software\Microsoft\Internet Explorer";

       public static int GetInternetExplorerMajorVersion()
       {
           int result;

           result = 0;

           try
           {
               RegistryKey key;

               key = Registry.LocalMachine.OpenSubKey(InternetExplorerRootKey);

               if (key != null)
               {
                   object value;

                   value = key.GetValue("svcVersion", null) ?? key.GetValue("Version", null);

                   if (value != null)
                   {
                       string version;
                       int separator;

                       version = value.ToString();
                       separator = version.IndexOf('.');
                       if (separator != -1)
                       {
                           int.TryParse(version.Substring(0, separator), out result);
                       }
                   }
               }
           }
          
           catch (UnauthorizedAccessException)
           {
               // The user does not have the necessary registry rights.
           }

           return result;
       }
       private const string BrowserEmulationKey = InternetExplorerRootKey + @"\Main\FeatureControl\FEATURE_BROWSER_EMULATION";

       public static BrowserEmulationVersion GetBrowserEmulationVersion()
       {
           BrowserEmulationVersion result;

           result = BrowserEmulationVersion.Default;

           try
           {
               RegistryKey key;

               key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);
               if (key != null)
               {
                   string programName;
                   object value;

                   programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);
                   value = key.GetValue(programName, null);

                   if (value != null)
                   {
                       result = (BrowserEmulationVersion)Convert.ToInt32(value);
                   }
               }
           }
         
           catch (UnauthorizedAccessException)
           {
               // The user does not have the necessary registry rights.
           }

           return result;
       }
       public static bool SetBrowserEmulationVersion(BrowserEmulationVersion browserEmulationVersion)
       {
           bool result;

           result = false;

           try
           {
               RegistryKey key;

               key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);

               if (key != null)
               {
                   string programName;

                   programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                   if (browserEmulationVersion != BrowserEmulationVersion.Default)
                   {
                       // if it's a valid value, update or create the value
                       key.SetValue(programName, (int)browserEmulationVersion, RegistryValueKind.DWord);
                   }
                   else
                   {
                       // otherwise, remove the existing value
                       key.DeleteValue(programName, false);
                   }

                   result = true;
               }
           }
          
           catch (UnauthorizedAccessException)
           {
               // The user does not have the necessary registry rights.
           }

           return result;
       }

       public static bool SetBrowserEmulationVersion()
       {
           int ieVersion;
           BrowserEmulationVersion emulationCode;

           ieVersion = GetInternetExplorerMajorVersion();

           if (ieVersion >= 11)
           {
               emulationCode = BrowserEmulationVersion.Version11;
           }
           else
           {
               switch (ieVersion)
               {
                   case 10:
                       emulationCode = BrowserEmulationVersion.Version10;
                       break;
                   case 9:
                       emulationCode = BrowserEmulationVersion.Version9;
                       break;
                   case 8:
                       emulationCode = BrowserEmulationVersion.Version8;
                       break;
                   default:
                       emulationCode = BrowserEmulationVersion.Version7;
                       break;
               }
           }

           return SetBrowserEmulationVersion(emulationCode);
       }
       public static bool IsBrowserEmulationSet()
       {
           return GetBrowserEmulationVersion() != BrowserEmulationVersion.Default;
       }

       #endregion

       private void lbllog_Click(object sender, EventArgs e)
       {

       }

    }
}
