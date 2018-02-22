using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancoImobiliario.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoImobiliario.Dominio.Tests
{
    [TestClass()]
    public class DadoTests
    {
        [TestMethod()]
        public void DadoTest()
        {
            //Arrange
            var dados = new Dado(2);

            //Assert
            Assert.IsTrue(dados.Resultados.Count() == 2);
            Console.WriteLine(dados.Resultados[0]);
            Console.WriteLine(dados.Resultados[1]);

            //jogar dado 100 vezes e verifica se soma passou de 12
            for (int i = 0; i < 100; i++)
            {
                var dados2 = new Dado(2);
                Assert.IsTrue(dados2.Soma <= 12);
                Console.WriteLine(dados2.Resultados[0] + " + " + dados2.Resultados[1] + " = " +dados2.Soma);
            }
        }
    }
}