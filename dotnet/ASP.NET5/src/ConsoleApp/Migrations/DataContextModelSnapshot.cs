using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using ConsoleApp.Data;

namespace ConsoleApp.Migrations
{
    [ContextType(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("ConsoleApp.Data.Category", b =>
                    {
                        b.Property<string>("Description")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 2);
                        b.Key("Id");
                    });
                
                builder.Entity("ConsoleApp.Data.Product", b =>
                    {
                        b.Property<int?>("CategoryId")
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 0);
                        b.Property<double>("Discontinued")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<double>("Price")
                            .Annotation("OriginalValueIndex", 4);
                        b.Key("Id");
                    });
                
                builder.Entity("ConsoleApp.Data.Product", b =>
                    {
                        b.ForeignKey("ConsoleApp.Data.Category", "CategoryId");
                    });
                
                return builder.Model;
            }
        }
    }
}
