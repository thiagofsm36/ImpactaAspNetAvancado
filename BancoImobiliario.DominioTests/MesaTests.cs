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
    public class MesaTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuantidadeIncorretaJogadoresTest()
        {
            //Arrange /Act
            var mesa1 = new Mesa(1);
            var mesa2 = new Mesa(7);
        }
        [TestMethod]
        public void InicializarJogoTeste()
        {
            //Arrange /Act
            var mesa = new Mesa(5);

            //Assert
            Assert.IsTrue(mesa.Jogadores.Count == 5);
            Assert.IsTrue(mesa.Jogadores.First().Saldo == Jogador.SaldoInicial);

            //verifica se todos os 5 jogadores tem saldo inicial correto
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(mesa.Jogadores[i].Saldo == Jogador.SaldoInicial);
            }
            Assert.IsTrue(mesa.Jogadores[0].Cor == Cor.Preto);

        }
    }


}