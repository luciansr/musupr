using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musupr.Service;
using Musupr.Infrastructure;
using Musupr.Domain.Models;

namespace Musupr.Tests
{
    [TestClass]
    public class TestesGoogleApi
    {
        [TestMethod]
        public void TestDistanciaFundaoBarra()
        {
            //https://www.google.com.br/maps/dir/-22.8580108,-43.2322284/-22.9965259,-43.3564107 

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            Usuario usuario = new Usuario { Latitude = -22.8580108, Longitude = -43.2322284 };
            Vaga vaga = new Vaga { Latitude = -22.9965259, Longitude = -43.3564107 };

            double distancia = rService.CalculaDistanciaEntreUsuarioEVaga(usuario, vaga);
            Assert.IsTrue(distancia > 25 && distancia < 30, "Esperando entre 25 e 30, retornado: " +  distancia);
        }


        
    }
}
