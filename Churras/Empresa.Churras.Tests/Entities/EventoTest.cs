﻿using Empresa.Churras.Domain.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Empresa.Churras.Tests.Entities
{
    [TestClass]
    public class EventoTest
    {
        [TestMethod]
        public void ConfirmarPresenca_Test()
        {
            var colega = new Colega
            {
                Key = 1,
                Nome = "Tião",
            };

            var evento = new Evento
            {
                Nome = "Churras na casa do Ary"
            };

            evento.ColegasConfirmados = null;

            evento.ConfirmarPresenca(colega);

            var confirmacao = evento.ColegasConfirmados.FirstOrDefault(x => x.ColegaNome == "Tião");

            Assert.IsNotNull(confirmacao, "Não encontrou Tião na lista de confirmação");
            Assert.AreEqual(colega.Key, confirmacao.ColegaKey, $"Confirmação não é do colega com o Id: {colega.Key}");
        }

        [TestMethod]
        public void CancelarPresenca_Test()
        {
            var colega = new Colega
            {
                Key = 1,
                Nome = "Tião",
            };

            var evento = new Evento
            {
                Nome = "Churras na casa do Ary"
            };

            evento.ColegasConfirmados = null;

            evento.ConfirmarPresenca(colega);
            evento.CancelarPresenca(colega);

            var confirmacao = evento.ColegasConfirmados.FirstOrDefault(x => x.ColegaNome == "Tião");

            Assert.IsNull(confirmacao, "O Tião continua na lista de presença");
        }
    }
}
