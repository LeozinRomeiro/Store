using Store.Domain.Entities;
using Store.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private IList<Product> _products;

        public ProductQueriesTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto 01", 10, true));
            _products.Add(new Product("Produto 02", 10, true));
            _products.Add(new Product("Produto 03", 10, true));
            _products.Add(new Product("Produto 04", 10, false));
            _products.Add(new Product("Produto 05", 10, false));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void DadoAConsultaDeProdutosAtivosDeveRetornar3()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void DadoAConsultaDeProdutosInativosDeveRetornar2()
        {

            var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(result.Count(), 2);
        }
    }

}
