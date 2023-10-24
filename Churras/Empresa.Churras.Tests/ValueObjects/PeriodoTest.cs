using Empresa.Churras.Domain.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Empresa.Churras.Tests.ValueObjects
{
    [TestClass]
    public class PeriodoTest
    {
        [TestMethod]
        public void QuantoDuraEmHoras_Test()
        {
            var periodo = new Periodo
            {
                Inicio = new DateTime(2023, 10, 28, 12, 0, 0),
                Fim = new DateTime(2023, 10, 28, 18, 0, 0),
            };

            int horas = periodo.QuantoDuraEmHoras();

            Assert.AreEqual(6, horas);
        }

        [TestMethod]
        public void FaltaQuantoTempoParaComecar_Dias_Test()
        {
            var dtInicio = DateTime.Now.AddDays(3).AddHours(5);
            var dtFim = dtInicio.AddHours(6);

            var periodo = new Periodo
            {
                Inicio = dtInicio,
                Fim = dtFim,
            };

            string quantoFalta = periodo.QuantoFaltaParaComecar();

            Assert.AreEqual("Começa em 3 dias e 4 horas", quantoFalta);
        }

        [TestMethod]
        public void FaltaQuantoTempoParaComecar_Horas_Test()
        {
            var dtInicio = DateTime.Now.AddHours(5);
            var dtFim = dtInicio.AddHours(6);

            var periodo = new Periodo
            {
                Inicio = dtInicio,
                Fim = dtFim,
            };

            string quantoFalta = periodo.QuantoFaltaParaComecar();

            Assert.AreEqual("Começa em 4 horas", quantoFalta);
        }

        [TestMethod]
        public void FaltaQuantoTempoParaComecar_JaComecou_Test()
        {
            var dtInicio = DateTime.Now.AddHours(-1);
            var dtFim = dtInicio.AddHours(6);

            var periodo = new Periodo
            {
                Inicio = dtInicio,
                Fim = dtFim,
            };

            string quantoFalta = periodo.QuantoFaltaParaComecar();

            Assert.AreEqual("Já começou!", quantoFalta);
        }
    }
}
