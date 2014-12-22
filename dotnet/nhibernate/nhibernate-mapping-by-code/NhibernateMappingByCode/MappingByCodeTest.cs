using System;
using NhibernateMappingByCode.Mappings;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NhibernateMappingByCode {

    [TestFixture]
    public class MappingByCodeTest {

        [Test]
        public void TestExportSchemaByCode() {
            var config = new Configuration();
            config.Configure("MySql.cfg.xml");
            var mapper = new ConventionModelMapper();
            mapper.AddMapping(new EmployeeMapping());
            mapper.AddMapping(new StoreMapping());
            mapper.AddMapping(new ProductMapping());
            
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            Assert.IsNotNull(mapping);
            Console.WriteLine(mapping.AsString());
            config.AddMapping(mapping);

            // test build schema
            var schemaExport = new SchemaExport(config);
            schemaExport.SetDelimiter(";");
            //schemaExport.SetOutputFile("R:\\test.sql");
            schemaExport.Execute(true, true, false);
        }

        [Test]
        public void TestExportSchemaByXml() {
            var config = new Configuration();
            config.Configure("MySql.cfg.xml");

            config.AddXmlFile("Hbm\\Test.hbm.xml");

            // test build schema
            var schemaExport = new SchemaExport(config);
            schemaExport.SetDelimiter(";");
            //schemaExport.SetOutputFile("R:\\test.sql");
            schemaExport.Execute(true, true, false);
        }
    }
}
