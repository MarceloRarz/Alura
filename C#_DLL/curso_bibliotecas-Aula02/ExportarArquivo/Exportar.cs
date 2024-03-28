using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace ExportarArquivo
{
    public static class ExportarDados<T> where T : class
    {

        public static void SalvarDados(string caminho, FormatoArquivo formato, List<T> dados)
        {
            if (string.IsNullOrEmpty(caminho))
            {
                throw new Exception("Caminho do arquivo não informado.");
            }
            if (formato != FormatoArquivo.XML)
            {
                if (formato != FormatoArquivo.JSON)
                    throw new Exception("Formato de arquivo desejado não encontrado.");
            }
            ExportData(caminho, formato, dados);

        }

        private static void ExportData(string caminho, FormatoArquivo formato, List<T> dados)
        {
            if (formato == FormatoArquivo.XML)
            {
                //Serializar para XML      
                var serializar = new XmlSerializer(typeof(List<T>));
                try
                {
                    FileStream fs = new FileStream(caminho + "\\dados.xml", FileMode.Create);
                    using (StreamWriter streamwriter = new StreamWriter(fs))
                    {
                        serializar.Serialize(streamwriter, dados);
                    }
                    Console.WriteLine($"Arquivo salvo em {caminho}");
                }
                catch (Exception excecao)
                {
                    throw new Exception(excecao.Message);
                }
            }
            if (formato == FormatoArquivo.JSON)
            {
                string json = JsonConvert.SerializeObject(dados, Formatting.Indented);
                try
                {
                    FileStream fs = new FileStream(caminho + "\\dados.json",
                        FileMode.Create);
                    using (StreamWriter streamwriter = new StreamWriter(fs))
                    {
                        streamwriter.WriteLine(json);
                    }
                    Console.WriteLine($"Arquivo salvo em {caminho}");

                }
                catch (Exception excecao)
                {
                    throw new Exception(excecao.Message);
                }
            }
        }
    }

    public enum FormatoArquivos
    {
        Xml = 1,
        Json = 2
    }


}
}
