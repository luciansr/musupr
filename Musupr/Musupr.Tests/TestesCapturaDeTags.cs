using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Musupr.Service;
using Musupr.Infrastructure;
using System.Collections.Generic;
using Musupr.Domain.DTModels;
using Musupr.Domain.Models;

namespace Musupr.Tests
{
    [TestClass]
    public class TestesCapturaDeTags
    {
        [TestMethod]
        public void TestTags1()
        {
            VagasService vagasService = Factory.Instance.Get<VagasService>();
            List<Vaga> vagas = new List<Vaga>();

            vagas.Add(new Vaga
            {
                DescricaoMarkdown = "TesteTag, teste"
            });

            List<string> tags = vagasService.GetTagsFromVagas(vagas, 2).ToList();

            Assert.AreEqual("TesteTag", tags[1]);
        }

        [TestMethod]
        public void TestTagsRepetida()
        {
            VagasService vagasService = Factory.Instance.Get<VagasService>();
            List<Vaga> vagas = new List<Vaga>();

            vagas.Add(new Vaga
            {
                DescricaoMarkdown = "TesteTag, TesteTag.teste"
            });

            List<string> tags = vagasService.GetTagsFromVagas(vagas, 5).ToList();

            Assert.AreEqual("TesteTag", tags[0]);
            Assert.AreNotEqual("TesteTag", tags[1]);
            Assert.AreEqual("teste", tags[1]);
        }
    }
}
